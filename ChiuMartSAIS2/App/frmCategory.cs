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
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgCategory frmCategoryAdd = new Dialogs.dlgCategory("add", "");
            if (frmCategoryAdd.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }

            Dialogs.dlgCategory frmCategoryEdit = new Dialogs.dlgCategory("edit", listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            if (frmCategoryEdit.ShowDialog(this) == DialogResult.OK)
            {

            }
        }
    }
}
