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
                    string sqlQuery = "SELECT * FROM cheque ";

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

        private void frmChequeMonitoring_Load(object sender, EventArgs e)
        {
            populateCheques();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
