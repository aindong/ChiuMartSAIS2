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

        private Classes.Configuration conf;

        public frmChiumartRetail()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        // populate the listview with data from the database
        private void populateListview()
        {
            try
            {

            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Restoring client error", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgConversionForm dlg = new Dialogs.dlgConversionForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Insert the new conversion transaction/Update the database stock
            }
        }

        private void frmChiumartRetail_Load(object sender, EventArgs e)
        {

        }
    }
}
