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
using Microsoft.Office.Interop.Excel;
using Npgsql;

namespace AppSharp1
{
    public partial class ProductsControl : UserControl, PageInterface
    {
        private List<ProductItem> products = new List<ProductItem>();

        public ProductsControl()
        {
            InitializeComponent();
            this.LoadProducts();
        }

        private void ProductsExport_Click(object sender, EventArgs e)
        {
            LoadProducts();

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Export Products to Excel"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Workbook workbook = excelApp.Workbooks.Add();
                    Worksheet worksheet = (Worksheet)workbook.Sheets[1];

                    worksheet.Cells[1, 1] = "ID";
                    worksheet.Cells[1, 2] = "Product Name";
                    worksheet.Cells[1, 3] = "Price";

                    Range headerRange = worksheet.Range["A1:C1"];
                    headerRange.Font.Bold = true;
                    headerRange.Interior.Color = XlRgbColor.rgbLightGray;

                    int row = 2;
                    foreach (var product in products)
                    {
                        worksheet.Cells[row, 1] = product.Id;
                        worksheet.Cells[row, 2] = product.Name;
                        worksheet.Cells[row, 3] = product.Price;
                        row++;
                    }

                    worksheet.Columns.AutoFit();

                    workbook.SaveAs(saveFileDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Export error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            string name = productNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal price;
            try
            {
                price = Convert.ToDecimal(productPriceTextBox.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Invalid price!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                var cmd = new NpgsqlCommand("INSERT INTO products(name, price) VALUES (@name, @price)", DataBase.Connection);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("price", price);
                cmd.ExecuteNonQuery();

                productNameTextBox.Clear();
                productPriceTextBox.Clear();
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
            public decimal Price { get; set; }

            public ProductItem(int id, string name, decimal priceId)
            {
                Id = id;
                Name = name;
                Price = priceId;
            }

            public string GetDisplay()
            {
                return $"{Id} - {Name} (Price: {Price} Rubles)";
            }

            public override string ToString()
            {
                return $"{Id} - {Name}";
            }
        }

        private void buttonEditProduct_Click(object sender, EventArgs e)
        {
            string name = productNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal price;
            try
            {
                price = Convert.ToDecimal(productPriceTextBox.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Invalid price!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = ProductsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Select an item!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var product = products[selectedIndex];

            try
            {
                var cmd = new NpgsqlCommand("UPDATE products SET name = @name, price = @price WHERE @pid = id", DataBase.Connection);
                cmd.Parameters.AddWithValue("@pid", product.Id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.ExecuteNonQuery();

                productNameTextBox.Clear();
                productPriceTextBox.Clear();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
