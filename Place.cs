using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationKiosk
{
    class Place
    {
        private String roomID, roomNumber, campus;
        private int roomCapacity;
        public Place()
        {

        }

        public String ID
        {
            get { return roomID; }
            set { roomID = value; }
        }

        public String Number
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        public String Campus
        {
            get { return campus; }
            set { campus = value; }
        }

        public int Capacity
        {
            get { return roomCapacity; }
            set { roomCapacity = value; }
        }
    }
}
