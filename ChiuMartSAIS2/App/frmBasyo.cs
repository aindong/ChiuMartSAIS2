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
    public partial class frmBasyo : Form
    {
        private Classes.Configuration conf;
        private string action;
        private int basyoId;

        public frmBasyo()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        private void populateBasyo()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT * FROM basyo WHERE date_created BETWEEN @start AND @end ";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("start", dtpFrom.Value.Date);
                    sqlCmd.Parameters.AddWithValue("end", dtpTo.Value.AddDays(1).Date);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["id"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["date_created"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["basyo_returned"].ToString());
                        lblReturned.Text = reader["basyo_returned"].ToString();
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void getTotalBasyoSold()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT SUM(qty) as total FROM `transaction` WHERE `productId` = '35' AND transDate BETWEEN @start AND @end ";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("start", dtpFrom.Value.Date);
                    sqlCmd.Parameters.AddWithValue("end", dtpTo.Value.AddDays(1).Date);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lblSold.Text = reader["total"].ToString();
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.ToString());
                    MessageBox.Show(this, "Can't connect to database"+ errorCode, errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void getTotalBasyoReturned()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT SUM(basyo_returned) as total FROM basyo WHERE date_created BETWEEN @start AND @end ";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("start", dtpFrom.Value.Date);
                    sqlCmd.Parameters.AddWithValue("end", dtpTo.Value.AddDays(1).Date);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lblReturned.Text = reader["total"].ToString();
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteBasyo(int criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE basyo SET status='inactive' WHERE id=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Basyo history successfully deleted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Deleting basyo history error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateBasyo(int criteria, string basyo_returned)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE basyo SET basyo_returned=@basyo_returned WHERE id=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("criteria", criteria);
                    sqlCmd.Parameters.AddWithValue("basyo_returned", basyo_returned);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Basyo successfully updated", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Updating basyo error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void insertBasyo(string basyo_returned)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {

                    Con.Open();
                    string sqlQuery = "INSERT INTO basyo (basyo_returned) VALUES (@basyo_returned)";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("basyo_returned", basyo_returned);

                    sqlCmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Basyo error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmBasyo_Load(object sender, EventArgs e)
        {
            populateBasyo();
            getTotalBasyoSold();
            getTotalBasyoReturned();
            if (lblReturned.Text == "")
            {
                lblReturned.Text = "0";
            }
            if (lblSold.Text == "")
            {
                lblSold.Text = "0";
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            action = "Add";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            panel1.Visible = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            action = "Edit";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtReturn.Text == "")
            {
                MessageBox.Show("Please enter a number.");
                return;
            }
            panel1.Visible = false;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            if (action == "Add")
            {
                insertBasyo(txtReturn.Text);
                populateBasyo();
                getTotalBasyoReturned();
            }
            else
            {
                updateBasyo(basyoId, txtReturn.Text);
                populateBasyo();
                getTotalBasyoReturned();
            }

            if (lblReturned.Text == "")
            {
                lblReturned.Text = "0";
            }
            if (lblSold.Text == "")
            {
                lblSold.Text = "0";
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            if (MessageBox.Show(this, "Do you want to delete this basyo history?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deleteBasyo(basyoId);
                populateBasyo();
                getTotalBasyoReturned();
            }

            if (lblReturned.Text == "")
            {
                lblReturned.Text = "0";
            }
            if (lblSold.Text == "")
            {
                lblSold.Text = "0";
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            basyoId = id;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            populateBasyo();
            getTotalBasyoSold();
            getTotalBasyoReturned();

            if (lblReturned.Text == "")
            {
                lblReturned.Text = "0";
            }
            if (lblSold.Text == "")
            {
                lblSold.Text = "0";
            }
        }
    }
}
