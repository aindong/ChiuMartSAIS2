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
        private string status = "active";

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
                    string sqlQuery = "SELECT * FROM cheque WHERE status = @status AND chequeStatus != 'Verified' ORDER BY chequeName ASC";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("status", this.status);

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
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["chequeStatus"].ToString());
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
                    string sqlQuery = "SELECT * FROM cheque WHERE chequeName LIKE @criteria AND status = @status";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("status", this.status);
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
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["chequeStatus"].ToString());
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
                    string sqlQuery = "SELECT * FROM cheque WHERE status = @status AND chequeStatus != 'Verified' ORDER BY chequeName ASC";
                    DateTime dateNow = DateTime.Today;
                    if (stockLevel == "Processing")
                    {
                        sqlQuery = "SELECT * FROM cheque WHERE DATE_FORMAT(chequeDate,'%Y-%m-%d') > cast(now() as date) AND status = @status AND chequeStatus != 'Verified' ORDER BY chequeName ASC";
                    }
                    else if (stockLevel == "Cleared")
                    {
                        sqlQuery = "SELECT * FROM cheque WHERE DATE_FORMAT(chequeDate,'%Y-%m-%d') <= cast(now() as date) AND status = @status AND chequeStatus != 'Verified' ORDER BY chequeName ASC";
                    }
                    else if (stockLevel == "Verified")
                    {
                        sqlQuery = "SELECT * FROM cheque WHERE chequeStatus = 'Verified' AND status = @status ORDER BY chequeName ASC";
                    }

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("status", this.status);

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
                        lstCheques.Items[lstCheques.Items.Count - 1].SubItems.Add(reader["chequeStatus"].ToString());
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
                string chequeStatus = lvw.SubItems[8].Text;

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

                // Check for verified
                if (chequeStatus == "Verified")
                {
                    lvw.BackColor = Color.DeepSkyBlue;
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
            if (lstCheques.SelectedItems.Count <= 0)
            {
                return;
            }

            string id = lstCheques.SelectedItems[lstCheques.SelectedItems.Count - 1].Text;

            if (btnDelete.Text == "&Delete")
            {
                if (MessageBox.Show(this, "Do you want to delete this cheque?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    trashCheque();
                    populateCheques();
                    checkChequeProcessing();
                }
            }
            else
            {
                if (MessageBox.Show(this, "Do you want to restore this cheque?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    restoreCheque();
                    populateCheques();
                    checkChequeProcessing();
                }
            }
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
                    MessageBox.Show(this, "Cheque successfully deleted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database ", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void restoreCheque()
        {
            try
            {
                using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
                {
                    Con.Open();
                    string sqlQuery = "UPDATE cheque SET status = 'active' WHERE id = @crit";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("crit", crit);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Cheque successfully restored", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database ", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void verifyCheque()
        {
            try
            {
                using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
                {
                    Con.Open();
                    string sqlQuery = "UPDATE cheque SET chequeStatus = 'Verified' WHERE id = @crit";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("crit", crit);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Cheque successfully verified", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void lblVerify_Click(object sender, EventArgs e)
        {
            getChequeByDateProcessing("Verified");
            checkChequeProcessing();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (lstCheques.SelectedItems.Count <= 0)
            {
                return;
            }

            string id = lstCheques.SelectedItems[lstCheques.SelectedItems.Count - 1].Text;

            if (MessageBox.Show(this, "Do you want to verify this cheque?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                verifyCheque();
                populateCheques();
                checkChequeProcessing();
            }
        }

        private void rboActive_CheckedChanged(object sender, EventArgs e)
        {
            status = "active";
            btnDelete.Text = "&Delete";
            populateCheques();
            checkChequeProcessing();
        }

        private void rboInactive_CheckedChanged(object sender, EventArgs e)
        {
            status = "inactive";
            btnDelete.Text = "&Restore";
            populateCheques();
            checkChequeProcessing();
        }
    }
}
