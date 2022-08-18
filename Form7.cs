using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudentInformationKiosk
{
    public partial class Form7 : Form
    {
        private User user;
        private Database db = new Database();
        private Form3 home;
        private Form1 logIn;
        private String old, newPass, confirm, message;
        public Form7(User u, Form3 f)
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.UpdatePasswordBckg;
            submitBtn.BackgroundImage = Properties.Resources.SubmitButton;
            cancelBtn.BackgroundImage = Properties.Resources.CancelWhiteBtn;

            user = u;
            home = f;
            message = "You updated your password!@You will now be logged out.";
            message = message.Replace("@", System.Environment.NewLine);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            home.Enabled = true;
            this.Close();     
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            CheckPass();
        }

        private void CheckPass()
        {
            old = oldPassTxt.Text;
            newPass = newPassTxt.Text;
            confirm = confirmTxt.Text;

            if(old.Equals(user.Password))
            {
                if(newPass.Equals(confirm))
                {
                    if(newPass.Equals(old))
                    {
                        MessageBox.Show("The new password can't be the same as the old one!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        user.Password = newPass;
                        db.updatePassword(user);
                        MessageBox.Show(message, "Password Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.Log(user.UserID, "The user updated their password.");
                        db.Log(user.UserID, "The user logged out.");
                        logIn = new Form1();
                        this.Hide();
                        home.Hide();
                        logIn.ShowDialog();
                        this.Close();
                        home.Close();
                    }
                }
                else
                {
                    MessageBox.Show("The new passwords don't match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Wrong Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
