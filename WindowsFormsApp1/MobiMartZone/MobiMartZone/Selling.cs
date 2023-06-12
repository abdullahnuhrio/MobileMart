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
    public partial class Selling : Form
    {
        public Selling()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Software\source\repos\MobiMartZone\Mobiledb\MobiSoftdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Mpopulate()
        {
            Con.Open();
            string query = "select Mbrand,MModel,MPrice from MobileTb";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            MobileDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Apopulate()
        {
            Con.Open();
            String query = "select ABrand,AModel,APrice from ATb";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            AccessoriesDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void insertbill()
        {
            if (BId.Text == "" || BClienttb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                
                int amount = Convert.ToInt32(Samttb.Text);
                try
                {
                    Con.Open();
                    String sql = "insert into BillTb values(" + BId.Text + ",'" + BClienttb.Text + "'," + amount + ")";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void Selling_Load(object sender, EventArgs e)
        {
            Mpopulate();
            Apopulate();
            Sum();
        }
        private void Sum()
        {
            string query = "select sum(Amt) from BillTb";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Atmlb1.Text = dt.Rows[0][0].ToString();

            Con.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MobileDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Bprotb.Text = MobileDGV.SelectedRows[0].Cells[0].Value.ToString() + MobileDGV.SelectedRows[0].Cells[1].Value.ToString();
            BpriceTb.Text = MobileDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void AccessoriesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Bprotb.Text = AccessoriesDGV.SelectedRows[0].Cells[0].Value.ToString() + AccessoriesDGV.SelectedRows[0].Cells[1].Value.ToString();
            BpriceTb.Text = AccessoriesDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        int prodid, prodqty, prodprice, tottal, pos = 60;
        string prodname;

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            home home = new home();
            home.Show();
            this.Hide();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Bprotb.Text = MobileDGV.SelectedRows[0].Cells[0].Value.ToString() + MobileDGV.SelectedRows[0].Cells[1].Value.ToString();
            BpriceTb.Text = MobileDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void gunaDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Bprotb.Text = AccessoriesDGV.SelectedRows[0].Cells[0].Value.ToString() + AccessoriesDGV.SelectedRows[0].Cells[1].Value.ToString();
            BpriceTb.Text = AccessoriesDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void BILLDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("MOBISOFT 1.0", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.OrangeRed, new Point(90,15));
            e.Graphics.DrawString("ID PRODUCT PRICE QUANTITY TOTAL", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.OrangeRed, new Point(26,40));
            foreach (DataGridViewRow row in BILLDGV.Rows)
            {
                prodid = Convert.ToInt32(row.Cells["Column1"].Value);
                prodname = ""+ row.Cells["Column2"].Value;
                prodprice = Convert.ToInt32(row.Cells["Column3"].Value);
                prodqty = Convert.ToInt32(row.Cells["Column4"].Value);
                tottal = Convert.ToInt32(row.Cells["Column5"].Value);
                e.Graphics.DrawString("" + prodid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.OrangeRed, new Point(26, pos));
                e.Graphics.DrawString("" + prodname, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.OrangeRed, new Point(45, pos));
                e.Graphics.DrawString("" + prodprice, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.OrangeRed, new Point(120, pos));
                e.Graphics.DrawString("" + prodqty, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.OrangeRed, new Point(170, pos));
                e.Graphics.DrawString("" + tottal, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.OrangeRed, new Point(235, pos));
            }
            e.Graphics.DrawString("Grandtotal: RS" + Grandtotal, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(50, pos+50));
            e.Graphics.DrawString("**********MOBISOFT**********", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(10, pos+ 85));
            BILLDGV.Rows.Clear();
            BILLDGV.Refresh();
            pos = 100;
            Grandtotal = 0;
            n = 0;
            insertbill();
            Sum();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm",285,600);
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        int n = 0, Grandtotal = 0;
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
            if (BQuantityTb.Text == ""|| BpriceTb.Text == "")
            {
                MessageBox.Show("Enter the Quantity");
            }
            else
            {
                int total = Convert.ToInt32(BQuantityTb.Text)* Convert.ToInt32(BpriceTb.Text);
                DataGridViewRow newrow = new DataGridViewRow();
                newrow.CreateCells(BILLDGV);
                newrow.Cells[0].Value = n + 1;
                newrow.Cells[1].Value = Bprotb;
                newrow.Cells[2].Value = BpriceTb;
                newrow.Cells[2].Value = BQuantityTb;
                newrow.Cells[2].Value = total;
                BILLDGV.Rows.Add(newrow);
                n++;
                Grandtotal = Grandtotal + total;
                Samttb.Text = "" + Grandtotal;
            }
        }
    }
}
