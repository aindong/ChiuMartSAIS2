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
    public partial class dlgSalesReport : Form
    {
        private Classes.Configuration conf;

        private double totalGross;
        private double totalCost;
        private double totalProfit;

        public dlgSalesReport()
        {
            InitializeComponent();

            conf = new Classes.Configuration();
        }

        // Load the product data on the listview
        private void populateProductSales()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conf.connectionstring))
                {
                    con.Open();
                    string sqlQuery = "SELECT t.`transdate`, t.`productId`, t.`unitPrice`, SUM(t.`qty`) as totalSold, t.`supplierPrice`, p.productName FROM `transaction` t LEFT JOIN `products` p ON p.productId = t.productId WHERE (t.`transDate` BETWEEN @from AND @to) GROUP BY t.`unitPrice`, t.`productId`, t.`supplierPrice`";
                    MySqlCommand sqlCmd = new MySqlCommand(sqlQuery, con);

                    sqlCmd.Parameters.AddWithValue("from", dtpFrom.Value.AddDays(-1));
                    sqlCmd.Parameters.AddWithValue("to", dtpTo.Value);

                    MySqlDataReader reader = sqlCmd.ExecuteReader();

                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["productId"].ToString());

                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["totalSold"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["productName"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["unitPrice"].ToString());

                        double totalSold = Double.Parse(reader["totalSold"].ToString()) * Double.Parse(reader["unitPrice"].ToString());
                        double cost = Double.Parse(reader["supplierPrice"].ToString()) * Double.Parse(reader["totalSold"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(totalSold.ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["supplierPrice"].ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(cost.ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["transDate"].ToString());
                    }
                }
            }
            catch (MySqlException ex)
            {
                string errorCode = string.Format("Error Code : {0}", ex.Number);
                MessageBox.Show(this, "Can't connect to database", errorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Calculate total gross
        private void calculateTotalGross()
        {
            totalGross = 0;
            for(int i = 0; i < listView1.Items.Count; i++)
            {
                totalGross += Double.Parse(listView1.Items[i].SubItems[4].Text);
            }
            lblGross.Text = totalGross.ToString();
        }

        // Calculate total cost
        private void calculateTotalCost()
        {
            totalCost = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                totalCost += Double.Parse(listView1.Items[i].SubItems[6].Text);
            }
            lblOverallCost.Text = totalCost.ToString();
        }

        // Calculate profit
        private void showProfit()
        {
            calculateTotalCost();
            calculateTotalGross();

            totalProfit = totalGross - totalCost;
            lblProfit.Text = totalProfit.ToString();
        }

        private void dlgSalesReport_Load(object sender, EventArgs e)
        {
            populateProductSales();
            showProfit();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            populateProductSales();
            showProfit();
        }
    }
}
