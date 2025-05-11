using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static AppSharp1.ClientsControl;

namespace AppSharp1.cnt
{
    public partial class ReportControl : UserControl, PageInterface
    {
        private List<ClientItem> clients = new List<ClientItem>();

        public ReportControl()
        {
            InitializeComponent();
            this.LoadClients();
            this.ClientsListBox.SelectionMode = SelectionMode.MultiExtended;
        }

        private void LoadClients()
        {
            clients.Clear();
            ClientsListBox.Items.Clear();

            try
            {
                var cmd = new NpgsqlCommand("SELECT id, name FROM clients ORDER BY id", DataBase.Connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var client = new ClientItem(reader.GetInt32(0), reader.GetString(1));
                    clients.Add(client);
                }

                reader.Close();

                foreach (var client in clients)
                {
                    ClientsListBox.Items.Add(client.GetDisplay());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading clients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonReport_Click_1(object sender, EventArgs e)
        {
            var selectedDate = dateReport.Value.Date;
            var selectedClients = ClientsListBox.SelectedIndices.Cast<int>().Select(i => clients[i]).ToList();

            if (selectedClients.Count == 0)
            {
                MessageBox.Show("Choose clients.");
                return;
            }

            var reportData = new Dictionary<int, (string name, decimal sum)>();
            var reportText = new System.Text.StringBuilder();

            try
            {
                foreach (var client in selectedClients)
                {
                    var cmd = new NpgsqlCommand(@"
            SELECT oi.product_id, p.name, oi.quantity, oi.delivered, p.price
            FROM orders o
            JOIN order_items oi ON o.id = oi.order_id
            JOIN products p ON oi.product_id = p.id
            WHERE o.client_id = @cid AND DATE(o.order_date) = @dt", DataBase.Connection);

                    cmd.Parameters.AddWithValue("@cid", client.Id);
                    cmd.Parameters.AddWithValue("@dt", selectedDate.Date);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int pid = reader.GetInt32(0);
                        string pname = reader.GetString(1);
                        int quantity = reader.GetInt32(2);
                        bool delivered = reader.GetBoolean(3);
                        int priceId = reader.GetInt32(4);

                        if (!delivered)
                        {
                            var priceItem = MainControl.priceList.FirstOrDefault(p => p.Id == priceId);
                            if (priceItem == null)
                            {
                                continue;
                            }

                            decimal price = priceItem.Price;
                            decimal sum = quantity * price;

                            if (reportData.ContainsKey(pid))
                            {
                                var existing = reportData[pid];
                                reportData[pid] = (pname, existing.sum + sum);
                            }
                            else
                            {
                                reportData[pid] = (pname, sum);
                            }

                            reportText.AppendLine($"Client: {client.Name}, Product: {pname}, Quantity: {quantity}, Summ: {sum:C}");
                        }
                    }
                    reader.Close();
                }

                if (reportData.Count == 0)
                {
                    MessageBox.Show("No data on current date.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show(reportText.ToString(), "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);

                chart1.Series.Clear();
                var series = new System.Windows.Forms.DataVisualization.Charting.Series("Non-Delivered");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                foreach (var (name, sum) in reportData.Values)
                {
                    series.Points.AddXY(name, sum);
                }

                chart1.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Page getPage()
        {
            return Page.Report;
        }
        private void dateReport_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
