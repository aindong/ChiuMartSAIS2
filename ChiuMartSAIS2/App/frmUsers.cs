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
    public partial class frmUsers : Form
    {
        private string createdDate = "";
        private int userId = 0;
        private string username = "";
        private string password = "";
        private string fullname = "";
        private string permissionId = "";
        private string status = "active";


        private Classes.Configuration conf;

        public frmUsers()
        {
            InitializeComponent();
           
            conf = new Classes.Configuration();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgUsers frmUsersAdd = new Dialogs.dlgUsers("add", 0);
            if (frmUsersAdd.ShowDialog(this) == DialogResult.OK)
            {
                frmUsersAdd.getUser(out userId, out username, out password, out fullname, out permissionId);
                permissionId = getPermissionId(permissionId).ToString();
                insertUser(username, password, fullname, permissionId);
                populateUsers();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            Dialogs.dlgUsers frmUsersEdit = new Dialogs.dlgUsers("edit", userId);
            frmUsersEdit.username = this.username;
            frmUsersEdit.password = this.password;
            frmUsersEdit.fullname = this.fullname;
            frmUsersEdit.permissionId = this.permissionId;
            if (frmUsersEdit.ShowDialog(this) == DialogResult.OK)
            {
                // If all validations were valid, we're going to get the user
                frmUsersEdit.getUser(out userId, out username, out password, out fullname, out permissionId);
                updateUser(username, password, fullname, permissionId, userId);
                populateUsers();
            }
        }

        /// <summary>
        /// Retrieving data permissions from database. :) 
        /// </summary>
        public void populatePermission(ComboBox cbo)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT * FROM permission WHERE status = @status ORDER BY role ASC";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("status", this.status);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    cbo.Items.Clear();

                    while (reader.Read())
                    {
                        cbo.Items.Add(reader["role"].ToString());
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
        /// Retrieving data from database. :) 
        /// </summary>
        private void populateUsers()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT u.*, p.role FROM user as u INNER JOIN permission as p ON u.permissionId = p.permissionId WHERE u.status = @status ORDER BY u.username ASC";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    sqlCmd.Parameters.AddWithValue("status", this.status);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["userId"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["username"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["password"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["fullname"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["role"].ToString());

                        // converts the transdate to datetime
                        DateTime aDate;
                        DateTime.TryParse(reader["created_date"].ToString(), out aDate);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                        // converts the transdate to datetime
                        DateTime uDate;
                        DateTime.TryParse(reader["updated_date"].ToString(), out uDate);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(uDate.ToString("MMMM dd, yyyy"));
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["status"].ToString());
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int getPermissionId(string role)
        {
            int result = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "SELECT * FROM permission WHERE role = @role";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);

                    sqlCmd.Parameters.AddWithValue("role", role);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result = (int)reader["permissionId"];
                    }

                    return result;
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }
        }


        private void insertUser(string username, string password, string fullname, string permissionId)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "INSERT INTO user (username, password, fullname, permissionid, status) VALUES (@username, @password, @fullname, @permissionId, 'active')";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("username", username);
                    sqlCmd.Parameters.AddWithValue("password", password);
                    sqlCmd.Parameters.AddWithValue("fullname", fullname);
                    sqlCmd.Parameters.AddWithValue("permissionId", permissionId);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "User successfully added", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Adding new User error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateUser(string username, string password, string fullname, string permissionId, int criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE user SET username=@username, password=@password, fullname=@fullname, permissionId=@permissionid WHERE userId=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("username", username);
                    sqlCmd.Parameters.AddWithValue("password", password);
                    sqlCmd.Parameters.AddWithValue("fullname", fullname);
                    sqlCmd.Parameters.AddWithValue("permissionid", permissionId);
                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "User successfully updated", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Updating User error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void deleteUser(int criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE user SET status='inactive' WHERE userId=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "User successfully deleted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Deleting User error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void restoreUser(int criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE user SET status='active' WHERE userId=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "User successfully restored", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Restoring User error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            populateUsers();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            userId = id;
            username = listView1.SelectedItems[listView1.SelectedItems.Count - 1].SubItems[1].Text;
            password = listView1.SelectedItems[listView1.SelectedItems.Count - 1].SubItems[2].Text;
            fullname = listView1.SelectedItems[listView1.SelectedItems.Count - 1].SubItems[3].Text;
            permissionId = listView1.SelectedItems[listView1.SelectedItems.Count - 1].SubItems[4].Text;
            createdDate = listView1.SelectedItems[listView1.SelectedItems.Count - 1].SubItems[5].Text;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            if (btnDelete.Text == "&Delete")
            {
                if (MessageBox.Show(this, "Do you want to delete this user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    deleteUser(userId);
                    populateUsers();
                }
            }
            else
            {
                if (MessageBox.Show(this, "Do you want to restore this user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    restoreUser(userId);
                    populateUsers();
                }
            }
        }

        /// <summary>
        /// Searching of users using filters. 
        /// </summary>
        /// <param name="critera"></param>
        private void searchUser(string critera)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "";

                    sqlQuery = "SELECT u.*, p.role FROM user as u INNER JOIN permission as p ON u.permissionId = p.permissionId WHERE u.username LIKE @crit AND u.status = @status ORDER BY u.username ASC";
                   
                    
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    // SQL Query Parameters
                    sqlCmd.Parameters.AddWithValue("crit", "%" + critera + "%");
                    sqlCmd.Parameters.AddWithValue("status", this.status);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["userId"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["username"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["password"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["fullname"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["role"].ToString());

                        // converts the transdate to datetime
                        DateTime aDate;
                        DateTime.TryParse(reader["created_date"].ToString(), out aDate);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(aDate.ToString("MMMM dd, yyyy"));

                        // converts the transdate to datetime
                        DateTime uDate;
                        DateTime.TryParse(reader["updated_date"].ToString(), out uDate);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(uDate.ToString("MMMM dd, yyyy"));
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["status"].ToString());
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchUser(txtSearch.Text);
        }

        private void rboActive_CheckedChanged(object sender, EventArgs e)
        {
            status = "active";
            btnDelete.Text = "&Delete";
            populateUsers();
        }

        private void rboInactive_CheckedChanged(object sender, EventArgs e)
        {
            status = "inactive";
            btnDelete.Text = "&Restore";
            populateUsers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            Dialogs.dlgUsers frmUsersEdit = new Dialogs.dlgUsers("edit", userId);
            frmUsersEdit.username = this.username;
            frmUsersEdit.password = this.password;
            frmUsersEdit.fullname = this.fullname;
            frmUsersEdit.permissionId = this.permissionId;
            if (frmUsersEdit.ShowDialog(this) == DialogResult.OK)
            {
                // If all validations were valid, we're going to get the user
                frmUsersEdit.getUser(out userId, out username, out password, out fullname, out permissionId);
                updateUser(username, password, fullname, permissionId, userId);
                populateUsers();
            }
        }
    }
}
