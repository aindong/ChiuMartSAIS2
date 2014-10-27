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
    public partial class dlgIdleStatus : Form
    {
        public dlgIdleStatus()
        {
            InitializeComponent();
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            Classes.GetLastUserInput.formStatusIdle = false;
            this.Close();

            dlgPasswordAuth auth = new dlgPasswordAuth();
            auth.idleMode = true;
            if (auth.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void dlgIdleStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Classes.GetLastUserInput.formStatusIdle == true)
            {
                e.Cancel = true;
            }
        }
    }
}
