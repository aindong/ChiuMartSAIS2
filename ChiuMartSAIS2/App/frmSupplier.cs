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
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgSupplier frmSupplierAdd = new Dialogs.dlgSupplier("add", "");
            if (frmSupplierAdd.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            Dialogs.dlgSupplier frmSupplierEdit = new Dialogs.dlgSupplier("edit", listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            if (frmSupplierEdit.ShowDialog(this) == DialogResult.OK)
            {

            }
        }
    }
}
