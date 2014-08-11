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
        //private string _cnString = "Data Source=localhost,1433;Network Library=DBMSSOCN;Initial Catalog=ttc;User ID=sa;Password=molecules;";
        private string _cnString = "Data Source=localhost;Initial Catalog=ttc;Integrated Security=True";
        //public static user variables
        public static string username;
        public static string accessright;
        public static string fname;
        public static string lname;
        public static string mname;



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
