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
    public partial class frmChiumartRetail : Form
    {
        public frmChiumartRetail()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgConversionForm dlg = new Dialogs.dlgConversionForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Insert the new conversion transaction/Update the database stock
            }
        }
    }
}
