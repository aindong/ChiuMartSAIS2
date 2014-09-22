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
    public partial class dlgIntervalSettings : Form
    {
        public dlgIntervalSettings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.idleMode = chkToggleIdle.Checked;
            int tmpInterval = Int32.Parse(maskedTextBox1.Text);
            Properties.Settings.Default.idleInterval = (tmpInterval * 60000);
            Properties.Settings.Default.Save();

            //MessageBox.Show(Properties.Settings.Default.idleInterval.ToString());

            DialogResult = DialogResult.OK;
        }

        private void dlgIntervalSettings_Load(object sender, EventArgs e)
        {
            chkToggleIdle.Checked = ChiuMartSAIS2.Properties.Settings.Default.idleMode;
            maskedTextBox1.Text = (Properties.Settings.Default.idleInterval / 60000).ToString();
        }
    }
}
