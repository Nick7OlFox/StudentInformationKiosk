using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationKiosk
{
    class Events
    {
        private int eventID, capacity;
        private String name, hostID, placeID, date, startTime, description, duration;

        public Events()
        {
            date = "";
        }

        public int ID
        {
            get { return eventID; }
            set { eventID = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public String Host
        {
            get { return hostID; }
            set { hostID = value; }
        }

        public String Place
        {
            get { return placeID; }
            set { placeID = value; }
        }

        public String Date
        {
            get { return date; }
            set { date = value; }
        }

        public String Start
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public String Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
    }
}
