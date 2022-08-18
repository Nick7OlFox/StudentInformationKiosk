using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationKiosk
{
    class Log
    {
        private String logID, userID, logDate, logData;

        public Log()
        {
        }

        public String ID
        {
            get { return logID; }
            set { logID = value; }
        }
        public String User
        {
            get { return userID; }
            set { userID = value; }
        }
        public String Time
        {
            get { return logDate; }
            set { logDate = value; }
        }
        public String Data
        {
            get { return logData; }
            set { logData = value; }
        }
    }
}
