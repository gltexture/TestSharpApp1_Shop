using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static AppSharp1.ClientsControl;
using static AppSharp1.ProductsControl;

namespace AppSharp1.cnt
{
    public partial class OrdersControl : UserControl, PageInterface
    {
        private List<ClientsControl.ClientItem> clients = new List<ClientsControl.ClientItem>();
        private List<ProductsControl.ProductItem> products = new List<ProductsControl.ProductItem>();
        private List<Order> orders = new List<Order>();

        public OrdersControl()
        {
            InitializeComponent();
            this.LoadClients();
            this.LoadProducts();
            this.LoadOrders();
            this.ProductsListBox.SelectionMode = SelectionMode.MultiExtended;
        }

        private void LoadClients()
        {
            this.clients.Clear();
            ClientsListBox.Items.Clear();

            try
            {
                var cmd = new NpgsqlCommand("SELECT id, name FROM clients ORDER BY id", DataBase.Connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var client = new ClientItem(reader.GetInt32(0), reader.GetString(1));
                    this.clients.Add(client);
                }

                reader.Close();

                foreach (var client in this.clients)
                {
                    ClientsListBox.Items.Add(client.GetDisplay());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            this.products.Clear();
            ProductsListBox.Items.Clear();

            try
            {
                var cmd = new NpgsqlCommand("SELECT id, name, price FROM products ORDER BY id", DataBase.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var product = new ProductItem(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2));
                    this.products.Add(product);
                }
                reader.Close();

                foreach (var p in this.products)
                {
                    ProductsListBox.Items.Add(p.GetDisplay());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadOrders()
        {
            this.orders.Clear();
            this.OrdersListBox.Items.Clear();

            try
            {
                var raw = new List<(int Oid, int Cid, DateTime Dt)>();
                var cmd = new NpgsqlCommand("SELECT id, client_id, order_date FROM orders ORDER BY id", DataBase.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    raw.Add((
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetDateTime(2)
                    ));
                }
                reader.Close();

                foreach (var (oid, cid, dt) in raw)
                {
                    var client = this.clients.First(c => c.Id == cid);
                    var items = this.LoadOrderItems(oid);
                    var order = new Order(oid, client, dt, items);
                    this.orders.Add(order);
                    this.OrdersListBox.Items.Add(order);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<OrderItem> LoadOrderItems(int orderId)
        {
            var list = new List<OrderItem>();

            try
            {
                var cmd = new NpgsqlCommand("SELECT product_id, quantity, delivered FROM order_items WHERE order_id = @oid", DataBase.Connection);
                cmd.Parameters.AddWithValue("@oid", orderId);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int pid = reader.GetInt32(0);
                    int qty = reader.GetInt32(1);
                    bool delivered = reader.GetBoolean(2);
                    var prod = this.products.First(p => p.Id == pid);
                    list.Add(new OrderItem(prod, qty, delivered));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return list;
        }

        private void OrdersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OrderItemsListBox.Items.Clear();
            int idx = this.OrdersListBox.SelectedIndex;
            if (idx < 0) { return; }
            var order = this.orders[idx];
            foreach (var item in order.Items)
            {
                this.OrderItemsListBox.Items.Add(item);
            }
        }

        private void ButtonAddOrder_Click(object sender, EventArgs e)
        {
            int cidx = this.ClientsListBox.SelectedIndex;
            if (cidx < 0)
            {
                return;
            }
            var client = this.clients[cidx];

            var selected = this.ProductsListBox.SelectedIndices;
            if (selected.Count == 0)
            {
                return;
            }

            DateTime date = this.dateOrder.Value;


            var checkCmd = new NpgsqlCommand("SELECT COUNT(*) FROM orders WHERE client_id = @cid AND order_date = @dt", DataBase.Connection);
            checkCmd.Parameters.AddWithValue("@cid", client.Id);
            checkCmd.Parameters.AddWithValue("@dt", date.Date);
            int existingCount = Convert.ToInt32(checkCmd.ExecuteScalar());

            if (existingCount > 0)
            {
                MessageBox.Show("Client alredy has an order on this date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cmd = new NpgsqlCommand("INSERT INTO orders(client_id, order_date) VALUES(@cid,@dt) RETURNING id", DataBase.Connection);
            cmd.Parameters.AddWithValue("@cid", client.Id);
            cmd.Parameters.AddWithValue("@dt", date.Date);
            int newId = Convert.ToInt32(cmd.ExecuteScalar());

            var items = new List<OrderItem>();
            foreach (int pi in selected)
            {
                var prod = this.products[pi];
                var icmd = new NpgsqlCommand("INSERT INTO order_items(order_id, product_id, quantity, delivered) VALUES(@oid,@pid,@q,false)", DataBase.Connection);
                icmd.Parameters.AddWithValue("@oid", newId);
                icmd.Parameters.AddWithValue("@pid", prod.Id);
                icmd.Parameters.AddWithValue("@q", 0);
                icmd.ExecuteNonQuery();
                items.Add(new OrderItem(prod, 0, false));
            }

            this.orders.Add(new Order(newId, client, date, items));
            this.OrdersListBox.Items.Add(this.orders.Last());
        }

        private void buttonRemoveOrder_Click(object sender, EventArgs e)
        {
            int idx = this.OrdersListBox.SelectedIndex;
            if (idx < 0)
            {
                return;
            }
            var order = this.orders[idx];
            var cmd1 = new NpgsqlCommand("DELETE FROM order_items WHERE order_id = @oid", DataBase.Connection);
            cmd1.Parameters.AddWithValue("@oid", order.Id);
            cmd1.ExecuteNonQuery();
            var cmd2 = new NpgsqlCommand("DELETE FROM orders WHERE id = @id", DataBase.Connection);
            cmd2.Parameters.AddWithValue("@id", order.Id);
            cmd2.ExecuteNonQuery();
            this.orders.RemoveAt(idx);
            this.OrdersListBox.Items.RemoveAt(idx);
            this.OrderItemsListBox.Items.Clear();
        }

        private void DeliveredTrueButton_Click(object sender, EventArgs e)
        {
            int oidx = this.OrdersListBox.SelectedIndex;
            int iidx = this.OrderItemsListBox.SelectedIndex;
            if (oidx < 0 || iidx < 0)
            {
                return;
            }
            var order = this.orders[oidx];
            var item = order.Items[iidx];
            var cmd = new NpgsqlCommand("UPDATE order_items SET delivered = true WHERE order_id = @oid AND product_id = @pid", DataBase.Connection);
            cmd.Parameters.AddWithValue("@oid", order.Id);
            cmd.Parameters.AddWithValue("@pid", item.Product.Id);
            cmd.ExecuteNonQuery();
            item.Delivered = true;
            this.OrderItemsListBox.Items[iidx] = item;
        }

        private void DeliveredFalseButton_Click(object sender, EventArgs e)
        {
            int oidx = this.OrdersListBox.SelectedIndex;
            int iidx = this.OrderItemsListBox.SelectedIndex;
            if (oidx < 0 || iidx < 0) 
            { 
                return; 
            }
            var order = this.orders[oidx];
            var item = order.Items[iidx];
            var cmd = new NpgsqlCommand("UPDATE order_items SET delivered = false WHERE order_id = @oid AND product_id = @pid", DataBase.Connection);
            cmd.Parameters.AddWithValue("@oid", order.Id);
            cmd.Parameters.AddWithValue("@pid", item.Product.Id);
            cmd.ExecuteNonQuery();
            item.Delivered = false;
            this.OrderItemsListBox.Items[iidx] = item;
        }

        private void ButtonSetQuanity_Click(object sender, EventArgs e)
        {
            int oidx = this.OrdersListBox.SelectedIndex;
            int iidx = this.OrderItemsListBox.SelectedIndex;
            if (oidx < 0 || iidx < 0)
            {
                return;
            }

            int nq;
            try
            {
                nq = Convert.ToInt32(this.orderQuanityTextBox.Text.Trim());
            }
            catch
            {
                return;
            }
            if (nq <= 0)
            {
                return;
            }

            var order = this.orders[oidx];
            var item = order.Items[iidx];

            var cmd = new NpgsqlCommand("UPDATE order_items SET quantity = @q WHERE order_id = @oid AND product_id = @pid", DataBase.Connection);
            cmd.Parameters.AddWithValue("@q", nq);
            cmd.Parameters.AddWithValue("@oid", order.Id);
            cmd.Parameters.AddWithValue("@pid", item.Product.Id);
            cmd.ExecuteNonQuery();

            item.Quantity = nq;
            this.OrderItemsListBox.Items[iidx] = item;
        }


        public Page getPage()
        {
            return Page.Orders;
        }

        public class OrderItem
        {
            public OrderItem(ProductsControl.ProductItem product, int quantity, bool delivered)
            {
                Product = product;
                Quantity = quantity;
                Delivered = delivered;
            }

            public ProductsControl.ProductItem Product { get; set; }
            public int Quantity { get; set; }
            public bool Delivered { get; set; }

            public override string ToString()
            {
                return $"{this.Product.Name} x{this.Quantity} — {(this.Delivered ? "Delivered" : "Not Delivered")}";
            }
        }

        public class Order
        {
            public Order(int id, ClientsControl.ClientItem client, DateTime date, List<OrderItem> items)
            {
                Id = id;
                Client = client;
                Date = date;
                Items = items;
            }

            public int Id { get; set; }
            public ClientsControl.ClientItem Client { get; set; }
            public DateTime Date { get; set; }
            public List<OrderItem> Items { get; set; }

            public override string ToString()
            {
                return $"{this.Id} — {this.Client.Name} — {this.Date:yyyy-MM-dd}";
            }
        }
    }
}
