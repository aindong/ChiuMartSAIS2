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

namespace ChiuMartSAIS2.App.ReportDialog
{
    public partial class dlgIndividualLog : Form
    {

        private Classes.Configuration conf;
        public string logType;
        public string relationId;
        public double quantity = 0;

        public dlgIndividualLog()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        private void populateLogByType()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sql = "";

                    if (logType == "transaction")
                    {
                        sql = "SELECT l.id, l.username, l.quantity, l.price, l.created_date, l.log_type, u.unitDesc, p.productName, c.clientName FROM logs as l INNER JOIN units as u ON l.unit_Id = u.unitId INNER JOIN products as p ON l.product_id = p.productId INNER JOIN client as c ON l.clientId = c.clientId WHERE l.log_type = 'transaction' AND l.relationId = @relationId ORDER BY l.created_date ASC";
                    }
                    else if (logType == "client")
                    {
                        sql = "SELECT l.id, l.username, l.quantity, l.price, l.created_date, l.log_type, u.unitDesc, p.productName, c.clientName FROM logs as l INNER JOIN units as u ON l.unit_Id = u.unitId INNER JOIN products as p ON l.product_id = p.productId INNER JOIN client as c ON l.clientId = c.clientId WHERE l.log_type = 'transaction' AND c.clientId = @relationId ORDER BY l.created_date ASC";
                    }
                    else if (logType == "supplier")
                    {
                        sql = "SELECT l.id, l.username, l.quantity, l.created_date, l.log_type, l.supplierPrice, u.unitDesc, p.productName, s.supplierName FROM logs as l INNER JOIN units as u ON l.unit_Id = u.unitId INNER JOIN products as p ON l.product_id = p.productId INNER JOIN supplier as s ON l.supplierId = s.supplierId WHERE l.log_type = 'transaction' AND s.supplierId = @relationId ORDER BY l.created_date ASC";
                    }
                    else if (logType == "balance")
                    {
                        sql = "SELECT l.id, l.username, l.price, l.created_date, l.paymentMethod, l.log_type, c.clientName FROM logs as l INNER JOIN client as c ON l.clientId = c.clientId WHERE l.log_type = 'balance' AND l.relationId = @relationId ORDER BY l.created_date ASC";
                    }

                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);
                    sqlCmd.Parameters.AddWithValue("logType", logType);
                    sqlCmd.Parameters.AddWithValue("relationId", relationId);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();
                    quantity = 0;
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        if (logType == "balance")
                        {
                            listView1.Items.Add(reader["id"].ToString());
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["clientName"].ToString());
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["price"].ToString());
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["paymentMethod"].ToString());
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["log_type"].ToString());
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["created_date"].ToString());
                            quantity += double.Parse(reader["price"].ToString());
                        }
                        else
                        {
                            listView1.Items.Add(reader["id"].ToString());
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["quantity"].ToString());
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["unitDesc"].ToString());
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["productName"].ToString());
                            if (logType == "supplier")
                            {
                                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierPrice"].ToString());
                                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());
                            }
                            else
                            {
                                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["price"].ToString());
                                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["clientName"].ToString());
                            }

                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["log_type"].ToString());
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["created_date"].ToString());
                            quantity += double.Parse(reader["quantity"].ToString());
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.ToString());
                MessageBox.Show(this, "Can't connect to database" + errorCode, errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filterDate()
        {
            using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
            {
                try
                {
                    con.Open();
                    string sql = "";

                    if (logType == "transaction")
                    {
                        sql = "SELECT l.id, l.username, l.quantity, l.price, l.created_date, l.log_type, u.unitDesc, p.productName, c.clientName FROM logs as l INNER JOIN units as u ON l.unit_Id = u.unitId INNER JOIN products as p ON l.product_id = p.productId INNER JOIN client as c ON l.clientId = c.clientId WHERE l.log_type = 'transaction' AND l.relationId = @relationId AND DATE_FORMAT(l.created_date,'%Y-%m-%d') BETWEEN @from AND @to ORDER BY l.created_date ASC";
                    }
                    else if (logType == "client")
                    {
                        sql = "SELECT l.id, l.username, l.quantity, l.price, l.created_date, l.log_type, u.unitDesc, p.productName, c.clientName FROM logs as l INNER JOIN units as u ON l.unit_Id = u.unitId INNER JOIN products as p ON l.product_id = p.productId INNER JOIN client as c ON l.clientId = c.clientId WHERE l.log_type = 'transaction' AND c.clientId = @relationId AND DATE_FORMAT(l.created_date,'%Y-%m-%d') BETWEEN @from AND @to ORDER BY l.created_date ASC";
                    }
                    else if (logType == "supplier")
                    {
                        sql = "SELECT l.id, l.username, l.quantity, l.created_date, l.log_type, l.supplierPrice, u.unitDesc, p.productName, s.supplierName FROM logs as l INNER JOIN units as u ON l.unit_Id = u.unitId INNER JOIN products as p ON l.product_id = p.productId INNER JOIN supplier as s ON l.supplierId = s.supplierId WHERE l.log_type = 'transaction' AND s.supplierId = @relationId AND DATE_FORMAT(l.created_date,'%Y-%m-%d') BETWEEN @from AND @to ORDER BY l.created_date ASC";
                    }
                    else if (logType == "balance")
                    {
                        sql = "SELECT l.id, l.username, l.price, l.created_date, l.paymentMethod, l.log_type, c.clientName FROM logs as l INNER JOIN client as c ON l.clientId = c.clientId WHERE l.log_type = 'balance' AND l.relationId = @relationId AND DATE_FORMAT(l.created_date,'%Y-%m-%d') BETWEEN @from AND @to ORDER BY l.created_date ASC";
                    }

                    MySqlCommand sqlCmd = new MySqlCommand(sql, con);
                    sqlCmd.Parameters.AddWithValue("logType", logType);
                    sqlCmd.Parameters.AddWithValue("relationId", relationId);

                    sqlCmd.Parameters.AddWithValue("from", dtpStart.Value.ToString("yyyy-MM-dd"));
                    sqlCmd.Parameters.AddWithValue("to", dtpEnd.Value.ToString("yyyy-MM-dd"));

                    MySqlDataReader reader = sqlCmd.ExecuteReader();
                    quantity = 0;
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        if (logType == "balance")
                        {
                            listView1.Items.Add(reader["id"].ToString());
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["clientName"].ToString());
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["price"].ToString());
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["paymentMethod"].ToString());
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["log_type"].ToString());
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["created_date"].ToString());
                            quantity += double.Parse(reader["price"].ToString());
                        }
                        else
                        {
                            listView1.Items.Add(reader["id"].ToString());
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["quantity"].ToString());
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["unitDesc"].ToString());
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["productName"].ToString());
                            if (logType == "supplier")
                            {
                                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierPrice"].ToString());
                                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierName"].ToString());
                            }
                            else
                            {
                                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["price"].ToString());
                                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["clientName"].ToString());
                            }

                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["log_type"].ToString());
                            listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["created_date"].ToString());
                            quantity += double.Parse(reader["quantity"].ToString());
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    string errorCode = string.Format("Error Code : {0}", ex.ToString());
                    MessageBox.Show(this, "Can't connect to database" + errorCode, errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InitializeListView()
        {
            // Set up the inital values for the ListView and populate it. 
            this.listView1 = new ListView();
            this.listView1.Dock = DockStyle.Top;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Size = new System.Drawing.Size(292, 130);
            this.listView1.View = View.Details;
            this.listView1.FullRowSelect = true;

            PopulateListview();
        }

        private void PopulateListview()
        {
            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = "id";
            columnHeader.TextAlign = HorizontalAlignment.Left;
            columnHeader.Width = 0;

            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Name";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 190;

            ColumnHeader columnHeader3 = new ColumnHeader();
            columnHeader3.Text = "Price";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 80;

            ColumnHeader columnHeader4 = new ColumnHeader();
            columnHeader4.Text = "Payment Method";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            columnHeader4.Width = 170;

            ColumnHeader columnHeader5 = new ColumnHeader();
            columnHeader5.Text = "Type";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 130;

            ColumnHeader columnHeader6 = new ColumnHeader();
            columnHeader6.Text = "Date";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            columnHeader6.Width = 185;
            
            this.listView1.Columns.Add(columnHeader);
            this.listView1.Columns.Add(columnHeader2);
            this.listView1.Columns.Add(columnHeader3);
            this.listView1.Columns.Add(columnHeader4);
            this.listView1.Columns.Add(columnHeader5);
            this.listView1.Columns.Add(columnHeader6);
        }

        private void PopulateListviewSupplier()
        {
            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = "id";
            columnHeader.TextAlign = HorizontalAlignment.Left;
            columnHeader.Width = 0;

            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Quantity";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 100;

            ColumnHeader columnHeader3 = new ColumnHeader();
            columnHeader3.Text = "Unit";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 80;

            ColumnHeader columnHeader4 = new ColumnHeader();
            columnHeader4.Text = "Product";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            columnHeader4.Width = 200;

            ColumnHeader columnHeader5 = new ColumnHeader();
            columnHeader5.Text = "Supplier Price";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 115;

            ColumnHeader columnHeader7 = new ColumnHeader();
            columnHeader7.Text = "Supplier Name";
            columnHeader7.TextAlign = HorizontalAlignment.Center;
            columnHeader7.Width = 150;

            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "Type";
            columnHeader1.TextAlign = HorizontalAlignment.Center;
            columnHeader1.Width = 120;

            ColumnHeader columnHeader6 = new ColumnHeader();
            columnHeader6.Text = "Date";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            columnHeader6.Width = 185;

            this.listView1.Columns.Add(columnHeader);
            this.listView1.Columns.Add(columnHeader2);
            this.listView1.Columns.Add(columnHeader3);
            this.listView1.Columns.Add(columnHeader4);
            this.listView1.Columns.Add(columnHeader5);
            this.listView1.Columns.Add(columnHeader7);
            this.listView1.Columns.Add(columnHeader1);
            this.listView1.Columns.Add(columnHeader6);
        }

        private void dlgIndividualLog_Load(object sender, EventArgs e)
        {
            if (logType == "balance")
            {
                listView1.Clear();
                PopulateListview();
            }
            else if (logType == "supplier")
            {
                listView1.Clear();
                PopulateListviewSupplier();
            }
            populateLogByType();
            lblQuantity.Text = quantity.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            filterDate();
            lblQuantity.Text = quantity.ToString();
        }
    }
}
