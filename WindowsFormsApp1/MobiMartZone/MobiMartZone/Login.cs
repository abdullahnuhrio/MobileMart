using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobiMartZone
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            UserTb.Text = "";
            PassTb.Text = "";
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (UserTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Enter the User name and Passward");
            }
            else if(UserTb.Text == "admin" && PassTb.Text == "admin")
            {
                home home = new home();
                home.Show();
                this.Hide();
            }
            else if (UserTb.Text == "Ali" && PassTb.Text == "Asad786")
            {
                home home = new home();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong User name and Passward");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
