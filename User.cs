using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationKiosk
{
    public class User
    {
        private String userID, userName, firstName, surname, doB, email, phoneNumber, userPassword, accountType;

        public User()
        {
        }

        public String UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public String Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public String DateOfBirth
        {
            get { return doB; }
            set { doB = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public String Password
        {
            get { return userPassword; }
            set { userPassword = value; }
        }

        public String Priviledge
        {
            get { return accountType; }
            set { accountType = value; }
        }
    }
}
