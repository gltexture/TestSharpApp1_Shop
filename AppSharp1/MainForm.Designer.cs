namespace AppSharp1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.MainMenuClientsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuProductsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuOrdersButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MainMenuMainButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuReportButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuMainButton,
            this.MainMenuClientsButton,
            this.MainMenuProductsButton,
            this.MainMenuOrdersButton,
            this.MainMenuReportButton});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.MainMenuStrip.TabIndex = 1;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // MainMenuClientsButton
            // 
            this.MainMenuClientsButton.Name = "MainMenuClientsButton";
            this.MainMenuClientsButton.Size = new System.Drawing.Size(55, 20);
            this.MainMenuClientsButton.Tag = "1";
            this.MainMenuClientsButton.Text = "Clients";
            this.MainMenuClientsButton.Click += new System.EventHandler(this.MainMenuClientsButton_Click);
            // 
            // MainMenuProductsButton
            // 
            this.MainMenuProductsButton.Name = "MainMenuProductsButton";
            this.MainMenuProductsButton.Size = new System.Drawing.Size(66, 20);
            this.MainMenuProductsButton.Tag = "2";
            this.MainMenuProductsButton.Text = "Products";
            this.MainMenuProductsButton.Click += new System.EventHandler(this.MainMenuProductsButton_Click);
            // 
            // MainMenuOrdersButton
            // 
            this.MainMenuOrdersButton.Name = "MainMenuOrdersButton";
            this.MainMenuOrdersButton.Size = new System.Drawing.Size(54, 20);
            this.MainMenuOrdersButton.Tag = "3";
            this.MainMenuOrdersButton.Text = "Orders";
            this.MainMenuOrdersButton.Click += new System.EventHandler(this.MainMenuOrdersButton_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Location = new System.Drawing.Point(0, 27);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(800, 423);
            this.MainPanel.TabIndex = 2;
            // 
            // MainMenuMainButton
            // 
            this.MainMenuMainButton.Name = "MainMenuMainButton";
            this.MainMenuMainButton.Size = new System.Drawing.Size(46, 20);
            this.MainMenuMainButton.Tag = "0";
            this.MainMenuMainButton.Text = "Main";
            this.MainMenuMainButton.Click += new System.EventHandler(this.MainMenuMainButton_Click);
            // 
            // MainMenuReportButton
            // 
            this.MainMenuReportButton.Name = "MainMenuReportButton";
            this.MainMenuReportButton.Size = new System.Drawing.Size(54, 20);
            this.MainMenuReportButton.Text = "Report";
            this.MainMenuReportButton.Click += new System.EventHandler(this.MainMenuReportButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.MainMenuStrip);
            this.MainMenuStrip = this.MainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MainMenuClientsButton;
        private System.Windows.Forms.ToolStripMenuItem MainMenuProductsButton;
        private System.Windows.Forms.ToolStripMenuItem MainMenuOrdersButton;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.ToolStripMenuItem MainMenuMainButton;
        private System.Windows.Forms.ToolStripMenuItem MainMenuReportButton;
    }
}

