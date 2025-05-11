using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppSharp1.cnt;
using Npgsql;

namespace AppSharp1
{
    public partial class ProductsControl : UserControl, PageInterface
    {
        private List<ProductItem> products = new List<ProductItem>();

        public ProductsControl()
        {
            InitializeComponent();
            this.LoadPrices();
            this.LoadProducts();
        }


        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            string name = productNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal priceId;
            try
            {
                priceId = Convert.ToDecimal(productIdTextBox.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Invalid price ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!MainControl.priceList.Any(p => p.Id == priceId))
            {
                MessageBox.Show("Price ID does not exist in price list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var cmd = new NpgsqlCommand("INSERT INTO products(name, price) VALUES (@name, @price)", DataBase.Connection);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("price", priceId);
                cmd.ExecuteNonQuery();

                productNameTextBox.Clear();
                productIdTextBox.Clear();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonRemoveProduct_Click(object sender, EventArgs e)
        {
            int selectedIndex = ProductsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Select an item!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var product = products[selectedIndex];

            try
            {
                var cmd = new NpgsqlCommand("DELETE FROM products WHERE id = @id", DataBase.Connection);
                cmd.Parameters.AddWithValue("id", product.Id);
                cmd.ExecuteNonQuery();

                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to remove product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPrices()
        {
            PricesListBox.Items.Clear();

            foreach (var entry in MainControl.priceList)
            {
                PricesListBox.Items.Add($"{entry.Id} - {entry.Price}");
            }
        }

        private void LoadProducts()
        {
            products.Clear();
            ProductsListBox.Items.Clear();

            try
            {
                var cmd = new NpgsqlCommand("SELECT id, name, price FROM products ORDER BY id", DataBase.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var product = new ProductItem(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2));
                    products.Add(product);
                }
                reader.Close();

                foreach (var p in products)
                {
                    ProductsListBox.Items.Add(p.GetDisplay());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Page getPage()
        {
            return Page.Products;
        }

        public class ProductItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal PriceId { get; set; }

            public ProductItem(int id, string name, decimal priceId)
            {
                Id = id;
                Name = name;
                PriceId = priceId;
            }

            public string GetDisplay()
            {
                var price = MainControl.priceList.FirstOrDefault(p => p.Id == PriceId)?.Price.ToString() ?? "not found";
                return $"{Id} - {Name} (Price: {price})";
            }

            public override string ToString()
            {
                return $"{Id} - {Name}";
            }
        }
    }
}
