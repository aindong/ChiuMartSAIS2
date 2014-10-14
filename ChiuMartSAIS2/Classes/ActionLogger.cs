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

        public static void LogAction(string quantity, string unit_id, string product_id, string log_type, string relationId, string clientId, string paymentMethod, string price, string supplierPrice)
        {
            Classes.Configuration conf = new Classes.Configuration();

            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sql = "INSERT INTO logs(quantity, unit_id, product_id, log_type, relationId, username, clientId, paymentMethod, price, supplierPrice) VALUES(@quantity, @unit_id, @product_id, @log_type, @relationId, @username, @clientId, @paymentMethod, @price, @supplierPrice)";
                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);

                    sqlCmd.Parameters.AddWithValue("quantity", quantity);
                    sqlCmd.Parameters.AddWithValue("unit_id", unit_id);
                    sqlCmd.Parameters.AddWithValue("product_id", product_id);
                    sqlCmd.Parameters.AddWithValue("log_type", log_type);
                    sqlCmd.Parameters.AddWithValue("relationId", relationId);
                    sqlCmd.Parameters.AddWithValue("username", Classes.Authentication.Instance.username);
                    sqlCmd.Parameters.AddWithValue("clientId", clientId);
                    sqlCmd.Parameters.AddWithValue("paymentMethod", paymentMethod);
                    sqlCmd.Parameters.AddWithValue("price", price);
                    sqlCmd.Parameters.AddWithValue("supplierPrice", supplierPrice);

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
