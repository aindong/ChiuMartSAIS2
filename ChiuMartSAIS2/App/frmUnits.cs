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
    public partial class frmUnits : Form
    {
        public frmUnits()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgUnits frmUnitsAdd = new Dialogs.dlgUnits("add", "");
            if (frmUnitsAdd.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            Dialogs.dlgUnits frmUnitsEdit = new Dialogs.dlgUnits("edit", listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            if (frmUnitsEdit.ShowDialog(this) == DialogResult.OK)
            {

            }
        }
    }
}
