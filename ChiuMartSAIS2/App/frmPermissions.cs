﻿using System;
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
    public partial class frmPermissions : Form
    {
        public frmPermissions()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dialogs.dlgPermission dlg = new Dialogs.dlgPermission();
            if (dlg.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
