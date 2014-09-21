using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace ChiuMartSAIS2.Classes
{
    class ActionLogger
    {

        public static void LogAction(string message, string log_type, string relationId, string clientId)
        {
            Classes.Configuration conf = new Classes.Configuration();

            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sql = "INSERT INTO logs(message, log_type, relationId, username, clientId) VALUES(@message, @log_type, @relationId, @username, @clientId)";
                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);

                    sqlCmd.Parameters.AddWithValue("message", message);
                    sqlCmd.Parameters.AddWithValue("log_type", log_type);
                    sqlCmd.Parameters.AddWithValue("relationId", relationId);
                    sqlCmd.Parameters.AddWithValue("username", Classes.Authentication.Instance.username);
                    sqlCmd.Parameters.AddWithValue("clientId", clientId);

                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show("Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
