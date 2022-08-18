using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationKiosk
{
    class BookedService
    {
        private String bookingID, userID, serviceID, serviceName, serviceDate;

        public BookedService()
        {
        }

        public String ID
        {
            get { return bookingID; }
            set { bookingID = value; }
        }

        public String User
        {
            get { return userID; }
            set { userID = value; }
        }

        public String ServID
        {
            get { return serviceID; }
            set { serviceID = value; }
        }

        public String Name
        {
            get { return serviceName; }
            set { serviceName = value; }
        }

        public String Date
        {
            get { return serviceDate; }
            set { serviceDate = value; }
        }
    }
}
