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
    public partial class frmChequeMonitoring : Form
    {
        private Classes.Configuration conf;

        public frmChequeMonitoring()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        private void populateCheques()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT * FROM cheque WHERE status = 'active' ORDER BY chequeName ASC";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstCheques.Items.Clear();

                    while (reader.Read())
                    {
                        lstCheques.Items.Add(reader["id"].ToString());
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["chequeNo"].ToString());
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["chequeName"].ToString());
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["chequeBank"].ToString());
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["chequeBranch"].ToString());
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["chequeAmount"].ToString());

                        // converts the chequeDate to datetime
                        DateTime aDate;
                        DateTime.TryParse(reader["chequeDate"].ToString(), out aDate);
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["status"].ToString());
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// This function is responsible for searching a specific cheque
        /// </summary>
        private void searchCheque(string criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT * FROM cheque WHERE chequeName LIKE @criteria AND status = 'active'";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("criteria", "%" + criteria + "%");

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstCheques.Items.Clear();

                    while (reader.Read())
                    {
                        lstCheques.Items.Add(reader["id"].ToString());
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["chequeNo"].ToString());
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["chequeName"].ToString());
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["chequeBank"].ToString());
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["chequeBranch"].ToString());
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["chequeAmount"].ToString());

                        // converts the chequeDate to datetime
                        DateTime aDate;
                        DateTime.TryParse(reader["chequeDate"].ToString(), out aDate);
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["status"].ToString());
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// This function is responsible for getting the cheque list by date processing
        /// </summary>
        private void getChequeByDateProcessing(string stockLevel)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT * FROM cheque WHERE status = 'active' ORDER BY chequeName ASC";
                    DateTime dateNow = DateTime.Today;
                    if (stockLevel == "Processing")
                    {
                        sqlQuery = "SELECT * FROM cheque WHERE DATE_FORMAT(chequeDate,'%Y-%m-%d') > cast(now() as date) ORDER BY chequeName ASC";
                    }
                    else if (stockLevel == "Cleared")
                    {
                        sqlQuery = "SELECT * FROM cheque WHERE DATE_FORMAT(chequeDate,'%Y-%m-%d') <= cast(now() as date) ORDER BY chequeName ASC";
                    }

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    lstCheques.Items.Clear();

                    while (reader.Read())
                    {
                        lstCheques.Items.Add(reader["id"].ToString());
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["chequeNo"].ToString());
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["chequeName"].ToString());
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["chequeBank"].ToString());
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["chequeBranch"].ToString());
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["chequeAmount"].ToString());

                        // converts the chequeDate to datetime
                        DateTime aDate;
                        DateTime.TryParse(reader["chequeDate"].ToString(), out aDate);
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["status"].ToString());
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// This function is responsible for checking the cheque date, it will change the color of a row for
        /// a specific cheque date
        /// </summary>
        private void checkChequeProcessing()
        {
            // Check the status
            foreach (ListViewItem lvw in lstCheques.Items)
            {
                DateTime chequeDate = Convert.ToDateTime(lvw.SubItems[6].Text);
                DateTime dateNow = DateTime.Today;

                // Check for processing
                if (chequeDate > dateNow)
                {
                    lvw.BackColor = Color.White;
                }

                // Check for cleared
                if (chequeDate <= dateNow)
                {
                    lvw.BackColor = Color.LimeGreen;
                }
            }
        }


        private void frmChequeMonitoring_Load(object sender, EventArgs e)
        {
            populateCheques();
            checkChequeProcessing();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchCheque(textBox1.Text);
            checkChequeProcessing();
        }

        private void lblProcessing_Click(object sender, EventArgs e)
        {
            getChequeByDateProcessing("Processing");
            checkChequeProcessing();
        }

        private void lblAll_Click(object sender, EventArgs e)
        {
            getChequeByDateProcessing("All");
            checkChequeProcessing();
        }

        private void lblCleared_Click(object sender, EventArgs e)
        {
            getChequeByDateProcessing("Cleared");
            checkChequeProcessing();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            trashCheque();
            populateCheques();
            checkChequeProcessing();
        }

        private void trashCheque()
        {
            try
            {
                using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
                {
                    Con.Open();
                    string sqlQuery = "UPDATE cheque SET status = 'inactive' WHERE id = @crit";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("crit", crit);

                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database ", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string crit { get; set; }

        private void lstCheques_Click(object sender, EventArgs e)
        {
            crit = lstCheques.SelectedItems[0].Text;
        }
    }
}
