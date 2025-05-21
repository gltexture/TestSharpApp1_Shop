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

namespace AppSharp1
{
    public partial class MainForm : Form
    {
        private readonly Color SELECTED_COLOR = Color.LightSteelBlue;
        private readonly Color UNSELECTED_COLOR = SystemColors.Control;

        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            MainMenuClientsButton.Tag = Page.Clients;
            MainMenuProductsButton.Tag = Page.Products;
            MainMenuOrdersButton.Tag = Page.Orders;
            MainMenuReportButton.Tag = Page.Report;

            this.LoadPage(new ProductsControl());
        }

        private void UpdateMenuButtonsStyle()
        {
            foreach (ToolStripItem item in MainMenuStrip.Items)
            {
                if (item is ToolStripMenuItem button && button.Tag is Page)
                {
                    button.BackColor = ((Page) button.Tag == Program.currentPage) ? SELECTED_COLOR : UNSELECTED_COLOR;
                    button.Font = new Font(button.Font, ((Page) button.Tag == Program.currentPage) ? FontStyle.Bold : FontStyle.Regular);
                }
            }
        }

        private void MainMenuClientsButton_Click(object sender, EventArgs e)
        {
            this.LoadPage(new ClientsControl());
        }

        private void MainMenuProductsButton_Click(object sender, EventArgs e)
        {
            this.LoadPage(new ProductsControl());
        }

        private void MainMenuOrdersButton_Click(object sender, EventArgs e)
        {
            this.LoadPage(new OrdersControl());
        }


        private void LoadPage(UserControl control)
        {
            Program.currentPage = ((PageInterface)control).getPage();

            this.MainPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            this.MainPanel.Controls.Add(control);

            this.UpdateMenuButtonsStyle();
        }

        private void MainMenuReportButton_Click(object sender, EventArgs e)
        {
            this.LoadPage(new ReportControl());
        }
    }
}
