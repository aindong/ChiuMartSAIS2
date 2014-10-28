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

namespace ChiuMartSAIS2.App.Dialogs
{
    public partial class dlgConversionForm : Form
    {

        private Classes.Configuration conf;

        public dlgConversionForm()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        private void dlgConversionForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Update the stocks
        }
    }
}
