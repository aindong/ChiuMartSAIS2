using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ChiuMartSAIS2.Classes
{
    class Authentication
    {
        // Apply singleton pattern
        private static Authentication instance;

        // Configuration class
        private Classes.Configuration conf = new Classes.Configuration();

        // File Maintenance Authentication
        public int products { get; set; }
        public int categories { get; set; }
        public int units { get; set; }
        public int suppliers { get; set; }
        public int clients { get; set; }
        public int users { get; set; }
        public int permissions { get; set; }

        // Transaction Authentication
        public int pointOfSale { get; set; }
        public int inventoryMonitoring { get; set; }
        public int purchaseOrder { get; set; }
        public int chequeMonitoring { get; set; }

        // Reports Authentication
        public int inventoryReport { get; set; }
        public int salesReport { get; set; }
        public int usersReport { get; set; }
        public int logsReport { get; set; }
        public int clientReport { get; set; }
        public int supplierReport { get; set; }
        public int manualInventoryReport { get; set; }

        // Others Authentication
        public int systemUtilities { get; set; }

        // User profile
        public string userFullName = "";
        public string username = "";
        public string role = "";

        /// <summary>
        /// Singleton pattern application
        /// to make sure that only one instance of this class will be created
        /// </summary>
        public static Authentication Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Authentication();
                }
                return instance;
            }
        }

        /// <summary>
        /// User login/authentication function
        /// </summary>
        public void userLogin(string password)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "SELECT u.*, p.* FROM user as u INNER JOIN permission as p ON u.permissionId = p.permissionId WHERE u.status = 'active' AND u.password = @password";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);

                    sqlCmd.Parameters.AddWithValue("username", username);
                    sqlCmd.Parameters.AddWithValue("password", password);
                    
                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            //TODO: CALL THE ASSIGN AUTHENTICATE FUNCTION
                            username = reader["username"].ToString();
                            userFullName = reader["fullname"].ToString();
                            role = reader["role"].ToString();

                            products = (int)reader["products"];
                            categories = (int)reader["categories"];
                            units = (int)reader["units"];
                            suppliers = (int)reader["suppliers"];
                            permissions = (int)reader["permission"];
                            clients = (int)reader["clients"];
                            users = (int)reader["users"];
                            pointOfSale = (int)reader["pos"];
                            inventoryMonitoring = (int)reader["inventorymonitoring"];
                            purchaseOrder = (int)reader["purchaseorder"];
                            chequeMonitoring = (int)reader["chequemonitoring"];
                            inventoryReport = (int)reader["inventoryreport"];
                            salesReport = (int)reader["salesreport"];
                            usersReport = (int)reader["usersreport"];
                            logsReport = (int)reader["logsreport"];
                            clientReport = (int)reader["clientreport"];
                            supplierReport = (int)reader["supplierreport"];
                            manualInventoryReport = (int)reader["manualInventoryReport"];
                            systemUtilities = (int)reader["systemutilities"];
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show("User authentication error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //pointOfSale = 1;
        }

        public void fullPermission()
        {
            products = 1;
            categories = 1;
            units = 1;
            suppliers = 1;
            permissions = 1;
            clients = 1;
            users = 1;
            pointOfSale = 1;
            inventoryMonitoring = 1;
            purchaseOrder = 1;
            chequeMonitoring = 1;
            inventoryReport = 1;
            salesReport = 1;
            usersReport = 1;
            logsReport = 1;
            clientReport = 1;
            supplierReport = 1;
            manualInventoryReport = 1;
            systemUtilities = 1;
        }

        public void userLogout()
        {
            userFullName = "";
            username = "";
            role = "";
        }
    }
}
