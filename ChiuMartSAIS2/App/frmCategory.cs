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
    public partial class frmCategory : Form
    {
        private Classes.Configuration conf;

        // fields declaration
        private int categoryId = 0;
        private string categoryName = "";

        public frmCategory()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        private void populateCategory()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "SELECT * FROM category";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);
                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["categoryId"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["categoryName"].ToString());
                    }

                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void insertCategory(string categoryName)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "INSERT INTO category (categoryName) VALUES (@categoryName)";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("categoryName", categoryName);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Category successfully added", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Adding new Category error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateCategory(string categoryName, int criteria)
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "UPDATE category SET categoryName=@categoryName WHERE categoryId=@criteria";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("categoryName", categoryName);
                    sqlCmd.Parameters.AddWithValue("criteria", criteria);

                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Category successfully updated", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Updating Category error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteCategory()
        {
            using (MySqlConnection Con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    Con.Open();
                    string sqlQuery = "DELETE FROM category WHERE categoryId=@criteria";

                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, Con);

                    sqlCmd.Parameters.AddWithValue("criteria", listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);

                    sqlCmd.ExecuteNonQuery();

                    MessageBox.Show(this, "Category data successfully deleted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.Number);
                    MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgCategory frmCategoryAdd = new Dialogs.dlgCategory("add", 0);
            if (frmCategoryAdd.ShowDialog(this) == DialogResult.OK)
            {
                // If all validations were valid, we're going to get the category
                frmCategoryAdd.getCategory(out categoryId, out categoryName);
                insertCategory(categoryName);
                populateCategory();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            Dialogs.dlgCategory frmCategoryEdit = new Dialogs.dlgCategory("edit", categoryId);
            frmCategoryEdit.categoryName = this.categoryName;
            if (frmCategoryEdit.ShowDialog(this) == DialogResult.OK)
            {
                // If all validations were valid, we're going to get the category
                frmCategoryEdit.getCategory(out categoryId, out categoryName);
                updateCategory(categoryName, categoryId);
                populateCategory();
            }
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            populateCategory();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            if (MessageBox.Show(this, "Do you want to delete this batch?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deleteCategory();
                populateCategory();
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            categoryId = id;
            categoryName = listView1.SelectedItems[listView1.SelectedItems.Count - 1].SubItems[1].Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
