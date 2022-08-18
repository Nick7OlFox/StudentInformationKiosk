using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationKiosk
{
    class Services
    {
        private int serviceID, capacity;
        private String name, providerID, placeID, date, startTime, description, duration;

        public Services()
        {

        }

        public int ID
        {
            get { return serviceID; }
            set { serviceID = value; }
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

        public String Provider
        {
            get { return providerID; }
            set { providerID = value; }
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
