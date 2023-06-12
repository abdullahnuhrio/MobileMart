using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MobiMartZone
{
    public partial class Accessories : Form
    {
        public Accessories()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Software\source\repos\MobiMartZone\Mobiledb\MobiSoftdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            String query = "select * from ATb";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            AccessoriesDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Accessories_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (AId.Text == "" || AbrandTb.Text == "" || AmodelTb.Text == "" || ApriceTb.Text == "" || AstockTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "insert into ATb values(" + AId.Text + ",'" + AbrandTb.Text + "','" + AmodelTb.Text + "'," + ApriceTb.Text + "," + AstockTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessories Added Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            AId.Text = "";
            AbrandTb.Text = "";
            AmodelTb.Text = "";
            ApriceTb.Text = "";
            AstockTb.Text = "";
        }

        private void AccessoriesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AId.Text = AccessoriesDGV.SelectedRows[0].Cells[0].Value.ToString();
            AbrandTb.Text = AccessoriesDGV.SelectedRows[0].Cells[1].Value.ToString();
            AmodelTb.Text = AccessoriesDGV.SelectedRows[0].Cells[2].Value.ToString();
            ApriceTb.Text = AccessoriesDGV.SelectedRows[0].Cells[3].Value.ToString();
            AstockTb.Text = AccessoriesDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (AId.Text == "")
            {
                MessageBox.Show("Enter the Accessories to be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "delete from ATb where AId=" + AId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessories Deleted");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (AId.Text == "" || AbrandTb.Text == "" || AmodelTb.Text == "" || ApriceTb.Text == "" || AstockTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "update ATb set ABrand='" + AbrandTb.Text + "', AModel='" + AmodelTb + "', APrice=" + ApriceTb + ", AStock=" + AstockTb.Text + " where AId=" + AId.Text + "";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile EDIT Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            home home = new home();
            home.Show();
            this.Hide();
        }

        private void AccessoriesDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            AId.Text = AccessoriesDGV.SelectedRows[0].Cells[0].Value.ToString();
            AbrandTb.Text = AccessoriesDGV.SelectedRows[0].Cells[1].Value.ToString();
            AmodelTb.Text = AccessoriesDGV.SelectedRows[0].Cells[2].Value.ToString();
            ApriceTb.Text = AccessoriesDGV.SelectedRows[0].Cells[3].Value.ToString();
            AstockTb.Text = AccessoriesDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void s_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
