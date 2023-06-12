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
    public partial class Mobile : Form
    {
        public Mobile()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Software\source\repos\MobiMartZone\Mobiledb\MobiSoftdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from MobileTb";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            MobileDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox5_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            MobIdTb.Text = "";
            brandTb.Text = "";
            modelTb.Text = "";
            priceTb.Text = "";
            stockTb.Text = "";
            
           
            cameraTb.Text = "";
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Mobile_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(MobIdTb.Text=="" || brandTb.Text == "" || modelTb.Text == "" || priceTb.Text == "" || stockTb.Text == "" || cameraTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "insert into MobileTb values("+ MobIdTb.Text + ",'" + brandTb.Text + "','" + modelTb.Text + "'," + priceTb.Text + "," + stockTb.Text + "," + ramcb.SelectedItem.ToString()+"," + romcb.SelectedItem.ToString()+","+cameraTb.Text+")";
                    SqlCommand cmd = new SqlCommand(sql,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Added Successfully");
                    Con.Close();
                    populate();
                } catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void MobileDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MobIdTb.Text = MobileDGV.SelectedRows[0].Cells[0].Value.ToString();
            brandTb.Text = MobileDGV.SelectedRows[0].Cells[1].Value.ToString();
            modelTb.Text = MobileDGV.SelectedRows[0].Cells[2].Value.ToString();
            priceTb.Text = MobileDGV.SelectedRows[0].Cells[3].Value.ToString();
            stockTb.Text = MobileDGV.SelectedRows[0].Cells[4].Value.ToString();
            ramcb.SelectedItem = MobileDGV.SelectedRows[0].Cells[5].Value.ToString();
            romcb.SelectedItem = MobileDGV.SelectedRows[0].Cells[6].Value.ToString();
            cameraTb.Text = MobileDGV.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (MobIdTb.Text == "")
            {
                MessageBox.Show("Enter the Mobile to be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "delete from MobileTb where MobIdTb=" + MobIdTb.Text+ "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Deleted");
                    Con.Close();
                    populate();
                }catch (Exception Ex)
                {
                   MessageBox.Show(Ex.Message);
                }
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (MobIdTb.Text == "" || brandTb.Text == "" || modelTb.Text == "" || priceTb.Text == "" || stockTb.Text == "" || cameraTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "update MobileTb set Mbrand='"+brandTb.Text+"', MModel='"+modelTb+"', MPrice="+priceTb+", MStock="+stockTb.Text+", MRam="+ramcb.SelectedItem.ToString()+",MRom="+romcb.SelectedItem.ToString()+",MCam="+cameraTb.Text+ "where MobId="+MobIdTb.Text+"";
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

        private void MobileDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            MobIdTb.Text = MobileDGV.SelectedRows[0].Cells[0].Value.ToString();
            brandTb.Text = MobileDGV.SelectedRows[0].Cells[1].Value.ToString();
            modelTb.Text = MobileDGV.SelectedRows[0].Cells[2].Value.ToString();
            priceTb.Text = MobileDGV.SelectedRows[0].Cells[3].Value.ToString();
            stockTb.Text = MobileDGV.SelectedRows[0].Cells[4].Value.ToString();
            ramcb.SelectedItem = MobileDGV.SelectedRows[0].Cells[5].Value.ToString();
            romcb.SelectedItem = MobileDGV.SelectedRows[0].Cells[6].Value.ToString();
            cameraTb.Text = MobileDGV.SelectedRows[0].Cells[7].Value.ToString();
        }
    }
}
