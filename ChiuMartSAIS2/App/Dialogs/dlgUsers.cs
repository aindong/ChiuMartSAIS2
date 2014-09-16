using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChiuMartSAIS2.App.Dialogs
{
    public partial class dlgUsers : Form
    {
        //variable declarations
        private string _action;
        private int _crit;


        public string username;
        public string password;
        public string fullname;
        public string permissionId;
        public string DateCreated;
        public dlgUsers(string action, int crit)
        {
            InitializeComponent();

            _action = action;
            _crit = crit;
        }


        private void dlgUsers_Load(object sender, EventArgs e)
        {
            txtUsername.Text = username;
            txtpWord.Text = password;
            txtFullName.Text = fullname;
            cboPermissionId.Text = permissionId;

            frmUsers frm = new frmUsers();
            frm.populatePermission(cboPermissionId);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_action == "add")
            {
                if (checkEmpty() == false)
                {
                    MessageBox.Show("Please fill out all the required fields", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                if (checkEmpty() == false)
                {
                    MessageBox.Show("Please fill out all the required fields", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }

        /// <summary>
        /// checks if the fields are properly inputted
        /// </summary>
        /// <returns></returns>
        private bool checkEmpty()
        {
            if (txtUsername.Text == "")
            {
                return false;
            }
            else
            {
                if (txtpWord.Text == "")
                {
                    return false;
                }
                else
                {
                    if (txtFullName.Text == "")
                    {
                        return false;
                    }
                    else
                    {
                        if (cboPermissionId.SelectedIndex == -1)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
        }

        public void getUser(out int userId, out string UserName, out string PassWord, out string FullName, out string PermissionID)
        {
            // Set the user id
            userId = _crit;
            Classes.StringHash hasher = new Classes.StringHash();

            UserName = txtUsername.Text;
            PassWord = hasher.hashIt(txtpWord.Text);
            FullName = txtFullName.Text;
            PermissionID = cboPermissionId.Text;
        }

        public string userId { get; set; }
    }
}
