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
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgProducts frmProductsAdd = new Dialogs.dlgProducts("add", "");
            if (frmProductsAdd.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            Dialogs.dlgProducts frmProductsAdd = new Dialogs.dlgProducts("edit", listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            if (frmProductsAdd.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

    }
}
