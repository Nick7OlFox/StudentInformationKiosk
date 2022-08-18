using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudentInformationKiosk
{
    public partial class Form6 : Form
    {
        private User user = new User();
        private Database db = new Database();
        private Form3 home;
        private Form1 logIn;
        private String purpose, message;
        public Form6(User u, Form3 f, String p)
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.PasswordCheckBckg;
            submitBtn.BackgroundImage = Properties.Resources.SubmitButton;
            cancelBtn.BackgroundImage = Properties.Resources.CancelWhiteBtn;

            user = u;
            home = f;
            purpose = p;

            message = "Are you sure you want to delete your account!@THERE IS NO WAY TO REVERSE THIS DECISION!";
            message = message.Replace("@", System.Environment.NewLine);
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if(purpose.Equals("Update"))
            {
                checkPasswordUpdate();
            }
            else
            {
                checkPasswordDelete();
            }
        }

        private void checkPasswordUpdate()
        {
            if(passwordTxt.Text.Equals(user.Password))
            {
                db.updateAccount(user);
                MessageBox.Show("You have updated your account!", "Account Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.Log(user.UserID, "The user updated their account.");
                home.Enabled = true;
                home.getAccountPanel();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkPasswordDelete()
        {
            if (passwordTxt.Text.Equals(user.Password))
            {
                var confirmation = MessageBox.Show(message, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmation == DialogResult.Yes)
                {
                    db.Log(user.UserID, "The user deleted their account.");
                    db.deleteAccount(user);
                    MessageBox.Show("Your Account was deleted!", "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logIn = new Form1();
                    this.Hide();
                    home.Hide();
                    logIn.ShowDialog();
                    this.Close();
                    home.Close();
                }
                else
                {
                    home.Enabled = true;
                    this.Close();
                }  
            }
            else
            {
                MessageBox.Show("Wrong Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            home.Enabled = true;
            this.Close();        
        }
    }
}
