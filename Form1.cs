using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInformationKiosk
{
    public partial class Form1 : Form
    {
        private String userName, password, dbPassword;
        private Database db = new Database();
        private Form2 register;
        private Form3 app;

        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.LogInBckg;
            this.Icon = Properties.Resources.Icon;
            logBtn.BackgroundImage = Properties.Resources.LogInBtn;
            registerBtn.BackgroundImage = Properties.Resources.RegisterBtn;

        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            getUserData();
            dbPassword = db.getpassword(userName);
            CheckData();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            register.ShowDialog();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            register = new Form2();
        }

        private void getUserData()
        {
            userName = userNameTxt.Text;
            password = passwordTxt.Text;
        }

        private void CheckData()
        {
            if (password.Equals(dbPassword))
            {
                MessageBox.Show("Welcome", "Logged in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                logIn();
            }

            else
            {
                MessageBox.Show("Username and Password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logIn()
        {
            app = new Form3(userName);

            this.Hide();
            app.ShowDialog();
            this.Close();
        }
    }
}
