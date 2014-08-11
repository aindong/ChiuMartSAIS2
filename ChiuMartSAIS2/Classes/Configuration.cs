using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiuMartSAIS2.Classes
{
    class Configuration
    {
        //configuration variables
        private string _cnString = "Server=localhost;Database=chuisais;Uid=root;Pwd=;";

        //setters and getters
        public string connectionstring
        {
            get { return _cnString; }
            set { _cnString = value; }
        }

        //string errorCode = string.Format("Error Code : {0}", ex.Number);
        //MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
