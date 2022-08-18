using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudentInformationKiosk
{
    public partial class Form2 : Form
    {
        private String firstName, surname, day, month, year, doB, userID, email, countryCode, number, phoneNumber, userName, password, confirm;
        private Database db = new Database();
        private Form1 login;
        public Form2()
        {
            InitializeComponent();
            this.Hide();
            this.Icon = Properties.Resources.Icon;
            this.BackgroundImage = Properties.Resources.RegisterBckg;

            cancelBtn.BackgroundImage = Properties.Resources.CancelBtn;
            registerBtn.BackgroundImage = Properties.Resources.RegisterRedBtn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            login = new Form1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Boolean check;
            getData();

            check = translateMonth();

            if (check)
            {
                check = checkID();

                if (check)
                {
                    check = checkPhone();

                    if (check)
                    {
                        check = checkUserName();

                        if (check)
                        {
                            check = checkPassword();

                            if (check)
                            {
                                register();
                            }

                            else
                            {
                                MessageBox.Show("The passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }

                        else
                        {
                            MessageBox.Show("This username is already registered to an account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                    else
                    {
                        MessageBox.Show("Error with the Phone Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else
                {
                    MessageBox.Show("This ID is already registered to an account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Error with the Date of Birth!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getData()
        {
            firstName = firstNameTxt.Text;
            surname = surnameTxt.Text;
            day = dayBox.Text;
            month = monthBox.Text;
            year = yearBox.Text;
            userID = userIDTxt.Text;
            email = emailTxt.Text;
            countryCode = countryCodeTxt.Text;
            number = phoneTxt.Text;
            userName = usernameTxt.Text;
            password = passwordTxt.Text;
            confirm = confirmTxt.Text;
        }

        private Boolean translateMonth()
        {
            Boolean check;
            Boolean dateCheck = true;

            if (month.Equals("January"))
            {
                doB = "01/";
            }

            else if (month.Equals("February"))
            {
                doB = "02/";
            }

            else if (month.Equals("March"))
            {
                doB = "03/";
            }

            else if (month.Equals("April"))
            {
                doB = "04/";
            }

            else if (month.Equals("May"))
            {
                doB = "05/";
            }

            else if (month.Equals("June"))
            {
                doB = "06/";
            }

            else if (month.Equals("July"))
            {
                doB = "07/";
            }

            else if (month.Equals("August"))
            {
                doB = "08/";
            }

            else if (month.Equals("September"))
            {
                doB = "09/";
            }

            else if (month.Equals("October"))
            {
                doB = "10/";
            }

            else if (month.Equals("November"))
            {
                doB = "11/";
            }

            else if (month.Equals("December"))
            {
                doB = "12/";
            }

            else
            {
                dateCheck = false;
            }

            if (dateCheck)
            {
                check = translateDay();
                return check;
            }

            else
            {
                return false;
            }
        }

        private Boolean translateDay()
        {
            Boolean check;
            try
            {
                int result = Int32.Parse(day);
                doB = day + "/" + doB;
                check = translateYear();
                return check;
            }

            catch
            {
                return false;
            }
        }

        private Boolean translateYear()
        {
            try
            {
                int result = Int32.Parse(year);
                doB = doB + year;
                return true;
            }

            catch
            {
                return false;
            }
        }
        private Boolean checkPassword()
        {
            if (password.Equals(confirm))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private Boolean checkID()
        {
            String check;

            check = db.getID(userID);

            if (check.Equals("Free"))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private Boolean checkPhone()
        {
            try
            {
                long Test = (long)Convert.ToDouble(number);
                if (countryCode.StartsWith("+"))
                {
                    try
                    {
                        int nTest = Int32.Parse(countryCode.Remove(0, 1));
                        phoneNumber = countryCode + number;
                        return true;
                    }
                    
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private Boolean checkUserName()
        {
            String check;

            check = db.getpassword(userName);

            if (check.Equals("Error"))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private void register()
        {
            String message;
            try
            {
                db.register(userID, userName, firstName, surname, doB, email, phoneNumber, password);

                message = "A new user with the ID: " + userID + " was registered.";
                db.Log(userID, message);
                MessageBox.Show("Registered Successfully!", "Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                login.ShowDialog();
                this.Close();
            }

            catch
            {
                MessageBox.Show("Error connecting to the database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
