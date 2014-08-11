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
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgClient frmClientAdd = new Dialogs.dlgClient("add", "");
            if (frmClientAdd.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            Dialogs.dlgClient frmClientEdit = new Dialogs.dlgClient("edit", listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            if (frmClientEdit.ShowDialog(this) == DialogResult.OK)
            {

            }
        }
    }
}
