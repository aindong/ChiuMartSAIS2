using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace ChiuMartSAIS2.App.ReportDialog
{
    public partial class dlgIndividualLog : Form
    {

        private Classes.Configuration conf;
        public string logType;
        public string relationId;
        public double quantity = 0;

        public dlgIndividualLog()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        private void populateLogByType()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sql = "";

                    if (logType == "transaction")
                    {
                        sql = "SELECT l.id, l.username, l.quantity, l.created_date, l.log_type, u.unitDesc, p.productName, c.clientName FROM logs as l INNER JOIN units as u ON l.unit_Id = u.unitId INNER JOIN products as p ON l.product_id = p.productId INNER JOIN client as c ON l.clientId = c.clientId WHERE l.log_type = 'transaction' AND l.relationId = @relationId";
                    }
                    else if (logType == "client")
                    {
                        sql = "SELECT l.id, l.username, l.quantity, l.created_date, l.log_type, u.unitDesc, p.productName, c.clientName FROM logs as l INNER JOIN units as u ON l.unit_Id = u.unitId INNER JOIN products as p ON l.product_id = p.productId INNER JOIN client as c ON l.clientId = c.clientId WHERE l.log_type = 'transaction' AND c.clientId = @relationId";
                    }
                    else if (logType == "supplier")
                    {
                        sql = "SELECT l.id, l.username, l.quantity, l.created_date, l.log_type, u.unitDesc, p.productName, s.supplierName FROM logs as l INNER JOIN units as u ON l.unit_Id = u.unitId INNER JOIN products as p ON l.product_id = p.productId INNER JOIN supplier as s ON l.supplierId = s.supplierId WHERE l.log_type = 'transaction' c.clientId = @relationId";
                    }

                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);
                    sqlCmd.Parameters.AddWithValue("logType", logType);
                    sqlCmd.Parameters.AddWithValue("relationId", relationId);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();
                    quantity = 0;
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["id"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["username"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["quantity"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["unitDesc"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["productName"].ToString());
                        if (logType == "supplier")
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());
                        }
                        else
                        {
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["clientName"].ToString());
                        }
                        
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["log_type"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["created_date"].ToString());
                        quantity += double.Parse(reader["quantity"].ToString());
                    }
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database" , errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dlgIndividualLog_Load(object sender, EventArgs e)
        {
            populateLogByType();
            lblQuantity.Text = quantity.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
