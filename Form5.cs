using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudentInformationKiosk
{
    public partial class Form5 : Form
    {
        private String priviledge, newEvent, eventID, userID, updated, userName, hostName, access;
        private Form3 home;
        private List<String> hostList = new List<string>();
        private List<String> campusList = new List<string>();
        private Events theEvent = new Events();
        private Database db = new Database();

        private void saveBtn_Click(object sender, EventArgs e)
        {
            getData();
            if (updated.Equals("Yes"))
            {
                db.updateEvent(theEvent, place.Campus, place.Number);
                MessageBox.Show("The event was successfully updated.", "Event Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.Log(userID, "The user updated the event with the ID: " + eventID + ".");
                this.Close();
            }
            else
            {
                db.Log(userID, "The user failed to updated the event with the ID: " + eventID + ".");
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("Are you sure you want to delete this Event?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmation == DialogResult.Yes)
            {

                db.deleteEvent(theEvent.ID.ToString());
                db.Log(userID, "The user deleted the event with the ID :" + eventID + ".");
                this.Close();

            }
            else
            {
                
            }
        }

        private void saveEventBtn_Click(object sender, EventArgs e)
        {
            getData();
            if (updated.Equals("Yes"))
            {
                db.addEvent(theEvent, userID, place.Campus, place.Number);
                MessageBox.Show("The event was successfully added.", "Event Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.Log(userID, "The user added the event with the ID: " + eventID + ".");
                this.Close();
            }
            else
            {
                db.Log(userID, "The user failed to add the event with the ID: " + eventID + ".");
            }
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (access.Equals("Event"))
            {
                home.getEventPanel();
            }
            else
            {
                home.getBookPanel();
            }
            home.Enabled = true;
        }

        private Place place = new Place();
        public Form5(String Priviledge, String newE, String ID, String uID, String uName, Form3 f, String a)
        {
            InitializeComponent();
            priviledge = Priviledge;
            newEvent = newE;
            eventID = ID;
            userID = uID;
            userName = uName;
            home = f;
            access = a;

            this.BackgroundImage = Properties.Resources.EventDetailsBckg;
            this.Icon = Properties.Resources.Icon;
            bookEventBtn.BackgroundImage = Properties.Resources.BookEventBtn;
            saveBtn.BackgroundImage = Properties.Resources.SaveChangesBtn;
            saveEventBtn.BackgroundImage = Properties.Resources.SaveEventBtn;
            deleteBtn.BackgroundImage = Properties.Resources.DeleteBtn;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            if (priviledge.Equals("Administrator"))
            {
                hostTxt.Visible = false;
                hostCombo.Visible = true;
                campusTxt.Visible = false;
                campusCombo.Visible = true;
                saveBtn.Visible = true;
                saveEventBtn.Visible = false;

                hostList = db.getHosts();
                campusList = db.getCampus();

                var hostArray = hostList.ToArray();
                var campusArray = campusList.ToArray();

                hostCombo.Items.AddRange(hostArray);
                campusCombo.Items.AddRange(campusArray);

                if (newEvent.Equals("Yes"))
                {
                    bookEventBtn.Visible = false;
                    saveBtn.Visible = false;
                    saveEventBtn.Visible = true;
                }

                else
                {
                    getInfo();
                    deleteBtn.Visible = true;
                }
            }

            else
            {
                hostTxt.Visible = true;
                hostCombo.Visible = false;
                campusTxt.Visible = true;
                campusCombo.Visible = false;
                bookEventBtn.Visible = true;
                saveBtn.Visible = false;
                saveEventBtn.Visible = false;
                deleteBtn.Visible = false;

                nameTxt.ReadOnly = true;
                descriptionTxt.ReadOnly = true;
                hostTxt.ReadOnly = true;
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

            if (priviledge.Equals("Host"))
            {
                hostTxt.Visible = true;
                hostCombo.Visible = false;
                campusTxt.Visible = false;
                campusCombo.Visible = true;
                bookEventBtn.Visible = true;
                saveBtn.Visible = true;

                nameTxt.ReadOnly = false;
                descriptionTxt.ReadOnly = false;
                hostTxt.ReadOnly = true;
                roomTxt.ReadOnly = false;
                capacityTxt.ReadOnly = false;
                dayTxt.ReadOnly = false;
                monthTxt.ReadOnly = false;
                yearTxt.ReadOnly = false;
                durationTxt.ReadOnly = false;
                startTxt.ReadOnly = false;
                capacityTxt.ReadOnly = false;

                campusList = db.getCampus();
                var campusArray = campusList.ToArray();
                campusCombo.Items.AddRange(campusArray);

                hostTxt.Text = userName;

                if (newEvent.Equals("Yes"))
                {
                    bookEventBtn.Visible = false;
                    saveBtn.Visible = false;
                    saveEventBtn.Visible = true;
                }

                else
                {
                    getInfo();
                    deleteBtn.Visible = true;
                }
            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String alreadyBooked;
            alreadyBooked = db.checkEBook(userID, theEvent.ID.ToString());
            if (alreadyBooked.Equals("No"))
            {
                if (theEvent.Capacity - 1 >= 0)
                {

                    db.bookEvent(userID, theEvent.ID.ToString());
                    db.Log(userID, "The user booked the event with the ID " + eventID + ".");
                    MessageBox.Show("You booked this Event", "Event Booked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The event you tried to book has no more places available.", "Not enough capacity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You already booked this event", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getInfo()
        {
            theEvent = db.getSpecificEvent(eventID);
            if (newEvent.Equals("Yes"))
            {
                priviledge = "Host";
            }
            else if (theEvent.Host.Equals(userID))
            {
                if (priviledge.Equals("Administrator"))
                {
                    
                }
                else
                {
                    priviledge = "Host";
                }
            }
            else
            {

            }
            place = db.getRoom(theEvent.Place);
            theEvent.Host = db.GetHost(theEvent.Host);

            nameTxt.Text = theEvent.Name;
            descriptionTxt.Text = theEvent.Description;
            roomTxt.Text = place.Number;
            capacityTxt.Text = theEvent.Capacity.ToString();
            if(theEvent.Date.Equals(""))
            {
                
            }
            else
            {
            dayTxt.Text = theEvent.Date.Substring(0, 2);
            monthTxt.Text = theEvent.Date.Substring(3, 2);
            yearTxt.Text = theEvent.Date.Substring(6, 4);
            }
            startTxt.Text = theEvent.Start;
            durationTxt.Text = theEvent.Duration;

            

            if (priviledge.Equals("Host"))
            {
                campusCombo.Text = place.Campus;
                hostTxt.Text = theEvent.Host;
            }

            else if (priviledge.Equals("Administrator"))
            {
                campusCombo.Text = place.Campus;
                hostCombo.Text = theEvent.Host;
            }

            else
            {
                campusTxt.Text = place.Campus;
                hostTxt.Text = theEvent.Host;
            }
        }

        private void getData()
        {
            place = db.getNewRoom(campusCombo.Text, roomTxt.Text);

            if (Int32.Parse(capacityTxt.Text) <= place.Capacity && Int32.Parse(capacityTxt.Text) > 0)
            {
                theEvent.Name = nameTxt.Text;
                theEvent.Description = descriptionTxt.Text;
                theEvent.Place = place.ID;;
                theEvent.Date = dayTxt.Text + "/" + monthTxt.Text + "/" + yearTxt.Text;
                theEvent.Start = startTxt.Text;
                theEvent.Duration = durationTxt.Text;
                theEvent.Capacity = Int32.Parse(capacityTxt.Text);

                if(priviledge.Equals("Administrator"))
                {
                    theEvent.Host = hostCombo.Text;
                }
                else
                {
                    theEvent.Host = hostTxt.Text;
                }

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
