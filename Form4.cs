using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudentInformationKiosk
{
    public partial class Form4 : Form
    {
        private String priviledge, newService, serviceID, userID, updated, access;
        private List<String> providerList = new List<string>();
        private List<String> campusList = new List<string>();
        private Services service = new Services();
        private Database db = new Database();
        private Place place = new Place();
        private Provider provider = new Provider();
        private Form3 home;
        public Form4(String Priviledge, String newS, String ID, String uID, Form3 f, String a)
        {
            InitializeComponent();
            priviledge = Priviledge;
            newService = newS;
            serviceID = ID;
            userID = uID;
            home = f;
            access = a;

            this.BackgroundImage = Properties.Resources.ServiceDetailsBckg;
            this.Icon = Properties.Resources.Icon;
            bookBtn.BackgroundImage = Properties.Resources.BookServiceBtn;
            saveBtn.BackgroundImage = Properties.Resources.SaveChangesBtn;
            saveServiceBtn.BackgroundImage = Properties.Resources.SaveServiceBtn;
            deleteBtn.BackgroundImage = Properties.Resources.DeleteBtn;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            getData();
            if (updated.Equals("Yes"))
            {
                db.updateService(service, provider.Name, place.Campus, place.Number);
                MessageBox.Show("The service was successfully updated.", "Service Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.Log(userID, "The user updated the service with the ID: " + serviceID + ".");
                this.Close();
            }
            else
            {
                db.Log(userID, "The user failed to updated the service with the ID: " + serviceID + ".");
            }
        }

        private void saveServiceBtn_Click(object sender, EventArgs e)
        {
            getData();
            if (updated.Equals("Yes"))
            {
                db.addService(service, provider.Name, place.Campus, place.Number);
                MessageBox.Show("The service was successfully added.", "Service Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.Log(userID, "The user added the service with the ID: " + serviceID + ".");
                this.Close();
            }
            else
            {
                db.Log(userID, "The user failed to add the service with the ID: " + serviceID + ".");
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            
            var confirmation = MessageBox.Show("Are you sure you want to delete this Service?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmation == DialogResult.Yes)
            {
                
                db.deleteService(service.ID.ToString());
                db.Log(userID, "The user deleted the service with the ID :" + serviceID + ".");
                this.Close();
                    
            }
            else
            {

            }
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (access.Equals("Service"))
            {
                home.getServicePanel();
            }
            else
            {
                home.getBookPanel();
            }
            home.Enabled = true;
        }

        private void bookServices_Click(object sender, EventArgs e)
        {
            String alreadyBooked;
            alreadyBooked = db.checkSBook(userID, service.ID.ToString());
            if (alreadyBooked.Equals("No"))
            {
                if (service.Capacity - 1 >= 0)
                {

                    db.bookService(userID, service.ID.ToString());
                    db.Log(userID, "The user booked the service with the ID " + serviceID + ".");
                    MessageBox.Show("You booked this Service", "Service Booked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The service you tried to book has no more places available.", "Not enough capacity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You already booked this service", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            if (priviledge.Equals("Administrator"))
            {
                providerTxt.Visible = false;
                providerCombo.Visible = true;
                campusTxt.Visible = false;
                campusCombo.Visible = true;
                saveBtn.Visible = true;
                saveServiceBtn.Visible = false;

                providerList = db.getProviders();
                campusList = db.getCampus();

                var providerArray = providerList.ToArray();
                var campusArray = campusList.ToArray();

                providerCombo.Items.AddRange(providerArray);
                campusCombo.Items.AddRange(campusArray);
                
                if(newService.Equals("Yes"))
                {
                    bookBtn.Visible = false;
                    saveBtn.Visible = false;
                    saveServiceBtn.Visible = true;
                }

                else
                {
                    getInfo();
                    deleteBtn.Visible = true;
                }
            }

            else
            {
                providerTxt.Visible = true;
                providerCombo.Visible = false;
                campusTxt.Visible = true;
                campusCombo.Visible = false;
                bookBtn.Visible = true;
                saveBtn.Visible = false;
                saveServiceBtn.Visible = false;

                nameTxt.ReadOnly = true;
                descriptionTxt.ReadOnly = true;
                providerTxt.ReadOnly = true;
                campusTxt.ReadOnly = true;
                roomTxt.ReadOnly = true;
                capacityTxt.ReadOnly = true;
                dayTxt.ReadOnly = true;
                monthTxt.ReadOnly = true;
                yearTxt.ReadOnly = true;
                durationTxt.ReadOnly = true;
                startTxt.ReadOnly = true;
                capacityTxt.ReadOnly = true;

                getInfo();
            }
        }

        private void getInfo()
        {
            service = db.getSpecificService(serviceID);
            place = db.getRoom(service.Place);
            provider = db.GetProvider(service.Provider);

            nameTxt.Text = service.Name;
            descriptionTxt.Text = service.Description;
            roomTxt.Text = place.Number;
            capacityTxt.Text = service.Capacity.ToString();
            dayTxt.Text = service.Date.Substring(0, 2);
            monthTxt.Text = service.Date.Substring(3, 2);
            yearTxt.Text = service.Date.Substring(6, 4);
            startTxt.Text = service.Start;
            durationTxt.Text = service.Duration;
            
            if (priviledge.Equals("Administrator"))
            {
                campusCombo.Text = place.Campus;
                providerCombo.Text = provider.Name;
            }

            else
            {
                campusTxt.Text = place.Campus;
                providerTxt.Text = provider.Name;
            }
        }

        private void getData()
        {
            provider = db.GetNewProvider(providerCombo.Text);
            place = db.getNewRoom(campusCombo.Text, roomTxt.Text);

            if (Int32.Parse(capacityTxt.Text) <= place.Capacity && Int32.Parse(capacityTxt.Text) > 0)
            {
                service.Name = nameTxt.Text;
                service.Description = descriptionTxt.Text;
                service.Place = place.ID;
                service.Provider = provider.ID;
                service.Date = dayTxt.Text + "/" + monthTxt.Text + "/" + yearTxt.Text;
                service.Start = startTxt.Text;
                service.Duration = durationTxt.Text;
                service.Capacity = Int32.Parse(capacityTxt.Text);

                updated = "Yes";
            }

            else
            {
                MessageBox.Show("Not enough capacity in the selected room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                updated = "No";
            }
        }
    }
}
