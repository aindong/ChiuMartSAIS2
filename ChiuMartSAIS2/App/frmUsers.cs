using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChiuMartSAIS2.App
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgUsers frmUsersAdd = new Dialogs.dlgUsers("add", "");
            if (frmUsersAdd.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            Dialogs.dlgUsers frmUsersEdit = new Dialogs.dlgUsers("edit", listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            if (frmUsersEdit.ShowDialog(this) == DialogResult.OK)
            {

            }
        }
    }
}
