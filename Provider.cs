using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationKiosk
{
    class Provider
    {
        private string providerID, providerName;

        public Provider()
        {

        }

        public String ID
        {
            get { return providerID; }
            set { providerID = value; }
        }

        public String Name
        {
            get { return providerName; }
            set { providerName = value; }
        }
    }
}
