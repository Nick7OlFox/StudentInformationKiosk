using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace StudentInformationKiosk
{
    public partial class Form3 : Form
    {

        private Form1 login;
        private Form4 serviceDetail;
        private Form5 eventDetail;
        private Form6 passwordCheck;
        private Form7 passwordUpdate;
        private List<Services> serviceList;
        private List<Events> eventList;
        private List<BookedService> bookSList;
        private List<BookedEvent> bookEList;
        private List<Place> allRooms;
        private List<String> allProviders;
        private List<Log> log;
        private User user = new User();
        private User userA;
        private Database db = new Database();
        private String day, month, year, countryCode, number, doB;
        public Form3(String username)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Icon;
            this.BackgroundImage = Properties.Resources.Form3Bckg;

            logOutBtn.BackgroundImage = Properties.Resources.LogOutBtn;
            homeBtn.BackgroundImage = Properties.Resources.HomeRedBtn;
            servicesBtn.BackgroundImage = Properties.Resources.ServicesWhiteBtn;
            eventBtn.BackgroundImage = Properties.Resources.EventsWhiteBtn;
            bookingsBtn.BackgroundImage = Properties.Resources.BookingWhiteBtn;
            accountBtn.BackgroundImage = Properties.Resources.AccountWhiteBtn;

            homePanel.BackgroundImage = Properties.Resources.HomePanel;
            homeServiceBtn.BackgroundImage = Properties.Resources.HomeServiceBtn;
            homeEventBtn.BackgroundImage = Properties.Resources.HomeEventBtn;
            homeNotificationBtn.BackgroundImage = Properties.Resources.HomeBookingBtn;
            homeAccountBtn.BackgroundImage = Properties.Resources.HomeAccountBtn;

            servicesPanel.BackgroundImage = Properties.Resources.ServicePanel;
            addServiceBtn.BackgroundImage = Properties.Resources.AddServiceBtn;

            eventPanel.BackgroundImage = Properties.Resources.EventPanel;
            addEventBtn.BackgroundImage = Properties.Resources.AddEventBtn;

            bookingPanel.BackgroundImage = Properties.Resources.BookingPanel;

            accountPanel.BackgroundImage = Properties.Resources.AccountPanel;
            updateBtn.BackgroundImage = Properties.Resources.UpdateAccountBtn;
            passwordBtn.BackgroundImage = Properties.Resources.UpdatePasswordBtn;
            deleteBtn.BackgroundImage = Properties.Resources.DeleteBtn;

            adminPanel.BackgroundImage = Properties.Resources.AdminPanelBckg;
            userBtn.BackgroundImage = Properties.Resources.UsersRedBtn;
            providerBtn.BackgroundImage = Properties.Resources.ProvidersWhiteBtn;
            roomBtn.BackgroundImage = Properties.Resources.RoomWhiteBtn;
            logBtn.BackgroundImage = Properties.Resources.LogWhiteBtn;

            userPanel.BackgroundImage = Properties.Resources.UserPanel;
            getDetailsBtn.BackgroundImage = Properties.Resources.GetDetailBtn;

            roomPanel.BackgroundImage = Properties.Resources.BlankPanel;
            roomPlusBtn.BackgroundImage = Properties.Resources.PlusBtn;

            providerPanel.BackgroundImage = Properties.Resources.BlankPanel;

            logPanel.BackgroundImage = Properties.Resources.BlankPanel;

            user.UserName = username;
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            user = db.getUserInfo(user.UserName);
            db.Log(user.UserID, "User logged in");

            if (user.Priviledge.Equals("Administrator"))
            {
                addServiceBtn.Visible = true;
                addEventBtn.Visible = true;
                adminBtn.Visible = true;
            }

            else if (user.Priviledge.Equals("Contributor"))
            {
                addEventBtn.Visible = true;
            }
        }

        private void homeServiceBtn_Click(object sender, EventArgs e)
        {
            getServicePanel();
        }

        private void homeEventBtn_Click(object sender, EventArgs e)
        {
            getEventPanel();
        }

        private void homeBookingBtn_Click(object sender, EventArgs e)
        {
            getBookPanel();
        }

        private void homeAccountBtn_Click(object sender, EventArgs e)
        {
            getAccountPanel();
        }

        private void servicesBtn_Click(object sender, EventArgs e)
        {
            getServicePanel();
        }

        private void getHomePanel()
        {
            homeBtn.BackgroundImage = Properties.Resources.HomeRedBtn;
            servicesBtn.BackgroundImage = Properties.Resources.ServicesWhiteBtn;
            eventBtn.BackgroundImage = Properties.Resources.EventsWhiteBtn;
            bookingsBtn.BackgroundImage = Properties.Resources.BookingWhiteBtn;
            accountBtn.BackgroundImage = Properties.Resources.AccountWhiteBtn;
            adminBtn.BackgroundImage = Properties.Resources.AdminWhiteBtn;

            homePanel.Visible = true;
            servicesPanel.Visible = false;
            eventPanel.Visible = false;
            bookingPanel.Visible = false;
            accountPanel.Visible = false;
            adminPanel.Visible = false;
        }

        public void getServicePanel()
        {
            homeBtn.BackgroundImage = Properties.Resources.HomeWhiteBtn;
            servicesBtn.BackgroundImage = Properties.Resources.ServicesRedBtn;
            eventBtn.BackgroundImage = Properties.Resources.EventsWhiteBtn;
            bookingsBtn.BackgroundImage = Properties.Resources.BookingWhiteBtn;
            accountBtn.BackgroundImage = Properties.Resources.AccountWhiteBtn;
            adminBtn.BackgroundImage = Properties.Resources.AdminWhiteBtn;

            serviceGrid.Rows.Clear();

            serviceList = db.getServices(user.Priviledge);
            var serviceArray = serviceList.ToArray();

            for(int i=0; i<serviceArray.Length; i++)
            {
                serviceGrid.Rows.Add();
                serviceGrid.Rows[i].Cells[0].Value = serviceArray[i].ID;
                serviceGrid.Rows[i].Cells[1].Value = serviceArray[i].Name;
                serviceGrid.Rows[i].Cells[2].Value = serviceArray[i].Description;
            }

            serviceGrid.ClearSelection();

            homePanel.Visible = false;
            servicesPanel.Visible = true;
            eventPanel.Visible = false;
            bookingPanel.Visible = false;
            accountPanel.Visible = false;
            adminPanel.Visible = false;
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            getHomePanel();
        }

        private void addServiceBtn_Click(object sender, EventArgs e)
        {
            openServiceDetail("Yes", null, "Service");
        }

        private void openServiceDetail(String info, String ID, String a)
        {
            this.Enabled = false;
            serviceDetail = new Form4(user.Priviledge, info, ID, user.UserID, this,a);

            serviceDetail.Show();
        }

        private void openEventDetail(String info, String ID, String a)
        {
            try
            {
                eventDetail = new Form5(user.Priviledge, info, ID, user.UserID, user.UserName, this, a);
                this.Enabled = false;
                eventDetail.Show();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void serviceGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (e.ColumnIndex < 3)
            {
                // Do nothing
            }

            // Add button
            else if (e.ColumnIndex == 3)
            {
                openServiceDetail("No", serviceGrid.Rows[row].Cells[0].Value.ToString(), "Service");
            }
        }

        private void eventBtn_Click(object sender, EventArgs e)
        {

            getEventPanel();
        }

        public void getEventPanel()
        {
            homeBtn.BackgroundImage = Properties.Resources.HomeWhiteBtn;
            servicesBtn.BackgroundImage = Properties.Resources.ServicesWhiteBtn;
            eventBtn.BackgroundImage = Properties.Resources.EventsRedBtn;
            bookingsBtn.BackgroundImage = Properties.Resources.BookingWhiteBtn;
            accountBtn.BackgroundImage = Properties.Resources.AccountWhiteBtn;
            adminBtn.BackgroundImage = Properties.Resources.AdminWhiteBtn;

            eventGrid.Rows.Clear();

            eventList = db.getEvent(user.Priviledge, user.UserID);
            var eventArray = eventList.ToArray();

            for (int i = 0; i < eventArray.Length; i++)
            {
                eventGrid.Rows.Add();
                eventGrid.Rows[i].Cells[0].Value = eventArray[i].ID;
                eventGrid.Rows[i].Cells[1].Value = eventArray[i].Name;
                eventGrid.Rows[i].Cells[2].Value = eventArray[i].Description;
            }

            eventGrid.ClearSelection();


            homePanel.Visible = false;
            servicesPanel.Visible = false;
            eventPanel.Visible = true;
            bookingPanel.Visible = false;
            accountPanel.Visible = false;
            adminPanel.Visible = false;
        }

        private void addEventBtn_Click(object sender, EventArgs e)
        {
            openEventDetail("Yes", null, "Event");
        }

        private void eventGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (e.ColumnIndex < 3)
            {
                // Do nothing
            }

            // Add button
            else if (e.ColumnIndex == 3)
            {
                openEventDetail("No", eventGrid.Rows[row].Cells[0].Value.ToString(), "Event");
            }
        }

        private void bookingsBtn_Click(object sender, EventArgs e)
        {
            getBookPanel();
        }

        public void getBookPanel()
        {
            homeBtn.BackgroundImage = Properties.Resources.HomeWhiteBtn;
            servicesBtn.BackgroundImage = Properties.Resources.ServicesWhiteBtn;
            eventBtn.BackgroundImage = Properties.Resources.EventsWhiteBtn;
            bookingsBtn.BackgroundImage = Properties.Resources.BookingRedBtn;
            accountBtn.BackgroundImage = Properties.Resources.AccountWhiteBtn;
            adminBtn.BackgroundImage = Properties.Resources.AdminWhiteBtn;

            bookSGrid.Rows.Clear();
            bookEGrid.Rows.Clear();

            bookSList = db.GetBookedService(user.UserID.ToString());
            bookEList = db.GetBookedEvent(user.UserID.ToString());

            var bookSArray = bookSList.ToArray();
            var bookEArray = bookEList.ToArray();

            for (int i = 0; i < bookSArray.Length; i++)
            {
                bookSGrid.Rows.Add();
                bookSGrid.Rows[i].Cells[0].Value = bookSArray[i].ID;
                bookSGrid.Rows[i].Cells[1].Value = bookSArray[i].Name;
                bookSGrid.Rows[i].Cells[2].Value = bookSArray[i].Date;
            }

            for (int i = 0; i < bookEArray.Length; i++)
            {
                bookEGrid.Rows.Add();
                bookEGrid.Rows[i].Cells[0].Value = bookEArray[i].ID;
                bookEGrid.Rows[i].Cells[1].Value = bookEArray[i].Name;
                bookEGrid.Rows[i].Cells[2].Value = bookEArray[i].Date;
            }

            bookSGrid.ClearSelection();
            bookEGrid.ClearSelection();

            homePanel.Visible = false;
            servicesPanel.Visible = false;
            eventPanel.Visible = false;
            bookingPanel.Visible = true;
            accountPanel.Visible = false;
            adminPanel.Visible = false;
        }

        private void bookSGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (e.ColumnIndex < 3)
            {
                // Do nothing
            }

            // Add button
            else if (e.ColumnIndex == 3)
            {
                openServiceDetail("No", bookSList[row].ServID, "Book");
            }

            else if (e.ColumnIndex == 4)
            {
                var confirmation = MessageBox.Show("Are you sure you want to delete this Booking?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmation == DialogResult.Yes)
                {

                    db.deleteBookS(bookSGrid.Rows[row].Cells[0].Value.ToString(), user.UserID, bookSList[row].ServID);
                    db.Log(user.UserID, "The user deleted the Booking with the ID :" + bookSGrid.Rows[row].Cells[0].Value.ToString() + ".");
                    getBookPanel();
                }
                else
                {

                }
            }
        }

        private void bookEGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (e.ColumnIndex < 3)
            {
                // Do nothing
            }

            // Add button
            else if (e.ColumnIndex == 3)
            {
                openEventDetail("No", bookEList[row].EventID, "Book");
            }

            else if (e.ColumnIndex == 4)
            {
                var confirmation = MessageBox.Show("Are you sure you want to delete this Booking?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmation == DialogResult.Yes)
                {

                    db.deleteBookE(bookEGrid.Rows[row].Cells[0].Value.ToString(), user.UserID, bookEList[row].EventID);
                    db.Log(user.UserID, "The user deleted the Booking with the ID :" + bookEGrid.Rows[row].Cells[0].Value.ToString() + ".");
                    getBookPanel();
                }
                else
                {

                }    
            }
        }

        private void accountBtn_Click(object sender, EventArgs e)
        {
            getAccountPanel();
        }

        public void getAccountPanel()
        {
            String month = null;

            homeBtn.BackgroundImage = Properties.Resources.HomeWhiteBtn;
            servicesBtn.BackgroundImage = Properties.Resources.ServicesWhiteBtn;
            eventBtn.BackgroundImage = Properties.Resources.EventsWhiteBtn;
            bookingsBtn.BackgroundImage = Properties.Resources.BookingWhiteBtn;
            accountBtn.BackgroundImage = Properties.Resources.AccountRedBtn;
            adminBtn.BackgroundImage = Properties.Resources.AdminWhiteBtn;

            firstNameTxt.Text = user.FirstName;
            surnameTxt.Text = user.Surname;
            dayCombo.Text = user.DateOfBirth.Substring(0, 2);

            if(user.DateOfBirth.Substring(3, 2).Equals("01"))
            {
                month = "January";
            }

            else if (user.DateOfBirth.Substring(3, 2).Equals("02"))
            {
                month = "February";
            }

            else if (user.DateOfBirth.Substring(3, 2).Equals("03"))
            {
                month = "March";
            }

            else if (user.DateOfBirth.Substring(3, 2).Equals("04"))
            {
                month = "April";
            }

            else if (user.DateOfBirth.Substring(3, 2).Equals("05"))
            {
                month = "May";
            }

            else if (user.DateOfBirth.Substring(3, 2).Equals("06"))
            {
                month = "June";
            }

            else if (user.DateOfBirth.Substring(3, 2).Equals("07"))
            {
                month = "July";
            }

            else if (user.DateOfBirth.Substring(3, 2).Equals("08"))
            {
                month = "August";
            }

            else if (user.DateOfBirth.Substring(3, 2).Equals("09"))
            {
                month = "September";
            }

            else if (user.DateOfBirth.Substring(3, 2).Equals("10"))
            {
                month = "October";
            }

            else if (user.DateOfBirth.Substring(3, 2).Equals("11"))
            {
                month = "November";
            }

            else
            {
                month = "December";
            }

            monthCombo.Text = month;
            yearCombo.Text = user.DateOfBirth.Substring(6, 4);
            emailTxt.Text = user.Email;
            countryCodeCombo.Text = user.PhoneNumber.Split(" ")[0];
            numberTxt.Text = user.PhoneNumber.Substring(user.PhoneNumber.LastIndexOf(" ") + 1);

            homePanel.Visible = false;
            servicesPanel.Visible = false;
            eventPanel.Visible = false;
            bookingPanel.Visible = false;
            accountPanel.Visible = true;
            adminPanel.Visible = false;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            updateAccount();
        }

        private void passwordBtn_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            passwordUpdate = new Form7(user, this);
            passwordUpdate.Show();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            passwordCheck = new Form6(user, this, "Delete");

            passwordCheck.Show();
        }

        private void updateAccount()
        {
            Boolean check;
            getData();

            check = translateMonth();

            if (check)
            {
                user.DateOfBirth = doB;
                check = checkPhone();

                if (check)
                {
                    this.Enabled = false;
                    passwordCheck = new Form6(user, this, "Update");

                    passwordCheck.Show();
                }

                else
                {
                    MessageBox.Show("Error with the Phone Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Error with the Date of Birth!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            login = new Form1();

            db.Log(user.UserID, "User logged out.");

            this.Hide();
            login.ShowDialog();
        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            getAdminPanel();
        }

        private void getAdminPanel()
        {
            homeBtn.BackgroundImage = Properties.Resources.HomeWhiteBtn;
            servicesBtn.BackgroundImage = Properties.Resources.ServicesWhiteBtn;
            eventBtn.BackgroundImage = Properties.Resources.EventsWhiteBtn;
            bookingsBtn.BackgroundImage = Properties.Resources.BookingWhiteBtn;
            accountBtn.BackgroundImage = Properties.Resources.AccountWhiteBtn;
            adminBtn.BackgroundImage = Properties.Resources.AdminRedBtn;

            homePanel.Visible = false;
            servicesPanel.Visible = false;
            eventPanel.Visible = false;
            bookingPanel.Visible = false;
            accountPanel.Visible = false;
            adminPanel.Visible = true;
        }

        private void userBtn_Click(object sender, EventArgs e)
        {
            userBtn.BackgroundImage = Properties.Resources.UsersRedBtn;
            roomBtn.BackgroundImage = Properties.Resources.RoomWhiteBtn;
            providerBtn.BackgroundImage = Properties.Resources.ProvidersWhiteBtn;
            logBtn.BackgroundImage = Properties.Resources.LogWhiteBtn;

            userPanel.Visible = true;
            roomPanel.Visible = false;
            providerPanel.Visible = false;
            logPanel.Visible = false;
        }

        private void providerBtn_Click(object sender, EventArgs e)
        {
            userBtn.BackgroundImage = Properties.Resources.UsersWhiteBtn;
            roomBtn.BackgroundImage = Properties.Resources.RoomWhiteBtn;
            providerBtn.BackgroundImage = Properties.Resources.ProvidersRedBtn;
            logBtn.BackgroundImage = Properties.Resources.LogWhiteBtn;

            providerGrid.Rows.Clear();

            allProviders = db.getAllProviders();
            var provArray = allProviders.ToArray();

            for (int i = 0; i < provArray.Length; i++)
            {
                providerGrid.Rows.Add();
                providerGrid.Rows[i].Cells[0].Value = provArray[i];
            }

            providerGrid.ClearSelection();

            userPanel.Visible = false;
            roomPanel.Visible = false;
            providerPanel.Visible = true;
            logPanel.Visible = false;
        }

        private void roomBtn_Click(object sender, EventArgs e)
        {
            userBtn.BackgroundImage = Properties.Resources.UsersWhiteBtn;
            roomBtn.BackgroundImage = Properties.Resources.RoomRedBtn;
            providerBtn.BackgroundImage = Properties.Resources.ProvidersWhiteBtn;
            logBtn.BackgroundImage = Properties.Resources.LogWhiteBtn;

            roomsGrid.Rows.Clear();

            allRooms = db.getAllRooms();
            var roomArray = allRooms.ToArray();

            for (int i = 0; i < roomArray.Length; i++)
            {
                roomsGrid.Rows.Add();
                roomsGrid.Rows[i].Cells[0].Value = roomArray[i].Number;
                roomsGrid.Rows[i].Cells[1].Value = roomArray[i].Campus;
                roomsGrid.Rows[i].Cells[2].Value = roomArray[i].Capacity;
            }

            roomsGrid.ClearSelection();

            userPanel.Visible = false;
            roomPanel.Visible = true;
            providerPanel.Visible = false;
            logPanel.Visible = false;
        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            userBtn.BackgroundImage = Properties.Resources.UsersWhiteBtn;
            roomBtn.BackgroundImage = Properties.Resources.RoomWhiteBtn;
            providerBtn.BackgroundImage = Properties.Resources.ProvidersWhiteBtn;
            logBtn.BackgroundImage = Properties.Resources.LogRedBtn;

            logGrid.Rows.Clear();

            log = db.getLog();
            var logArray = log.ToArray();

            for (int i = 0; i < logArray.Length; i++)
            {
                logGrid.Rows.Add();
                logGrid.Rows[i].Cells[0].Value = logArray[i].User;
                logGrid.Rows[i].Cells[1].Value = logArray[i].Time;
                logGrid.Rows[i].Cells[2].Value = logArray[i].Data;
            }

            logGrid.ClearSelection();

            userPanel.Visible = false;
            roomPanel.Visible = false;
            providerPanel.Visible = false;
            logPanel.Visible = true;
        }

        private void typeATxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            userA.Priviledge = typeATxt.Text;
            db.updatePriviledge(userA);
        }

        private void getDetailsBtn_Click(object sender, EventArgs e)
        {
            userA = new User();

            userA.UserID = userIDATxt.Text;
            db.GetUser(userA);

            userNameATxt.Text = userA.UserName;
            nameATxt.Text = userA.FirstName + " " + userA.Surname;
            doBATxt.Text = userA.DateOfBirth;
            emailATxt.Text = userA.Email;
            phoneATxt.Text = userA.DateOfBirth;
            typeATxt.Text = userA.Priviledge;
        }

        private void getData()
        {
            user.FirstName = firstNameTxt.Text;
            user.Surname = surnameTxt.Text;
            day = dayCombo.Text;
            month = monthCombo.Text;
            year = yearCombo.Text;
            user.Email = emailTxt.Text;
            countryCode = countryCodeCombo.Text;
            number = numberTxt.Text;
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
                        user.PhoneNumber = countryCode + " " + number;
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
    }
}
