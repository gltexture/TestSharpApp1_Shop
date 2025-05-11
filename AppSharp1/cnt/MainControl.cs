using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace AppSharp1
{
    public partial class MainControl : UserControl, PageInterface
    {
        public static List<PriceItem> priceList = new List<PriceItem>();

        public MainControl()
        {
            InitializeComponent();
            this.RefreshListBox();
        }

        private void PriceListAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(PriceListIdInput.Text.Trim());
                decimal price = decimal.Parse(PriceListPriceInput.Text.Trim());

                foreach (var item in priceList)
                {
                    if (item.Id == id)
                    {
                        MessageBox.Show("ID already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                priceList.Add(new PriceItem(id, price));
                this.RefreshListBox();
                PriceListIdInput.Clear();
                PriceListPriceInput.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid ID or Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PriceListRemove_Click(object sender, EventArgs e)
        {
            if (PriceListBox.SelectedItem == null)
            {
                return;
            }

            var selectedItem = (PriceItem) PriceListBox.SelectedItem;
            priceList.RemoveAll(item => item.Id == selectedItem.Id);
            this.RefreshListBox();
        }

        private void PriceListImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Select Excel File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Workbook workbook = excelApp.Workbooks.Open(openFileDialog.FileName);
                    Worksheet worksheet = (Worksheet)workbook.Sheets[1];

                    Range range = worksheet.UsedRange;
                    for (int i = 2; i <= range.Rows.Count; i++)
                    {
                        int id = (int) (range.Cells[i, 1] as Range).Value2;
                        decimal price = (decimal) (range.Cells[i, 2] as Range).Value2;

                        priceList.Add(new PriceItem(id, price));
                    }

                    workbook.Close(false);
                    excelApp.Quit();

                    this.RefreshListBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PriceListExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Save Excel File"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Workbook workbook = excelApp.Workbooks.Add();
                    Worksheet worksheet = (Worksheet)workbook.Sheets[1];

                    worksheet.Cells[1, 1] = "ID";
                    worksheet.Cells[1, 2] = "Price";

                    int row = 2;
                    foreach (var item in priceList)
                    {
                        worksheet.Cells[row, 1] = item.Id;
                        worksheet.Cells[row, 2] = item.Price;
                        row++;
                    }

                    workbook.SaveAs(saveFileDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Successful", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RefreshListBox()
        {
            PriceListBox.Items.Clear();
            foreach (var item in priceList)
            {
                PriceListBox.Items.Add(item);
            }
        }


        public Page getPage()
        {
            return Page.Main;
        }

        public class PriceItem
        {
            public int Id { get; set; }
            public decimal Price { get; set; }

            public PriceItem(int id, decimal price)
            {
                Id = id;
                Price = price;
            }

            public override string ToString()
            {
                return $"{Id} - {Price}";
            }
        }
    }
}
