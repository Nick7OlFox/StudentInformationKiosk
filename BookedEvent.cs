using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationKiosk
{
    class BookedEvent
    {
        private String bookingID, userID, eventID, eventName, eventDate;

        public BookedEvent()
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

        public String EventID
        {
            get { return eventID; }
            set { eventID = value; }
        }

        public String Name
        {
            get { return eventName; }
            set { eventName = value; }
        }

        public String Date
        {
            get { return eventDate; }
            set { eventDate = value; }
        }
    }
}
