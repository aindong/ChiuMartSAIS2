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

namespace ChiuMartSAIS2.App
{
    public partial class frmChiumartRetail : Form
    {

        private Classes.Configuration conf;

        public frmChiumartRetail()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        // populate the listview with data from the database
        private void populateListview()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sql = "SELECT u.*, c.* FROM conversion c INNER JOIN user u ON c.username = u.username WHERE created_date BETWEEN @from AND @to";
                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);

                    sqlCmd.Parameters.AddWithValue("from", dtpFrom.Value.AddDays(-1));
                    sqlCmd.Parameters.AddWithValue("to", dtpTo.Value);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["id"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["fullname"].ToString());
                        DateTime tmpDate;
                        DateTime.TryParse(reader["created_at"].ToString(), out tmpDate);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(tmpDate.ToString("MMMM dd, yyyy"));
                    }
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Restoring client error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // insert new conversion history
        private void insertConversion()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sql = "INSERT INTO conversion(username) VALUES(@username)";
                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);
                    sqlCmd.Parameters.AddWithValue("username", Classes.Authentication.Instance.username);

                    sqlCmd.ExecuteNonQuery();

                    MessageBox.Show("New conversion of products was made successfully", "Conversion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Restoring client error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgConversionForm dlg = new Dialogs.dlgConversionForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Insert the new conversion transaction/Update the database stock
                insertConversion();
            }
        }

        private void frmChiumartRetail_Load(object sender, EventArgs e)
        {
            populateListview();
        }
    }
}
