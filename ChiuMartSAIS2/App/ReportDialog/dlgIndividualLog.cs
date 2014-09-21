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
                    string sql = "SELECT * FROM logs WHERE log_type = @logType AND relationId = @relationId";
                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);
                    sqlCmd.Parameters.AddWithValue("logType", logType);
                    sqlCmd.Parameters.AddWithValue("relationId", relationId);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["id"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["username"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["message"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["log_type"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["created_date"].ToString());
                    }
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dlgIndividualLog_Load(object sender, EventArgs e)
        {
            populateLogByType();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
