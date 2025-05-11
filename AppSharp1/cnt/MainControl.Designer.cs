namespace AppSharp1
{
    partial class MainControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.PriceListRemove = new System.Windows.Forms.Button();
            this.PriceListAdd = new System.Windows.Forms.Button();
            this.PriceListimport = new System.Windows.Forms.Button();
            this.priceListExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PriceListBox = new System.Windows.Forms.ListBox();
            this.PriceListPriceInput = new System.Windows.Forms.TextBox();
            this.PriceListIdInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PriceListRemove
            // 
            this.PriceListRemove.Location = new System.Drawing.Point(420, 284);
            this.PriceListRemove.Name = "PriceListRemove";
            this.PriceListRemove.Size = new System.Drawing.Size(75, 23);
            this.PriceListRemove.TabIndex = 11;
            this.PriceListRemove.Text = "Remove";
            this.PriceListRemove.UseVisualStyleBackColor = true;
            this.PriceListRemove.Click += new System.EventHandler(this.PriceListRemove_Click);
            // 
            // PriceListAdd
            // 
            this.PriceListAdd.Location = new System.Drawing.Point(420, 93);
            this.PriceListAdd.Name = "PriceListAdd";
            this.PriceListAdd.Size = new System.Drawing.Size(75, 23);
            this.PriceListAdd.TabIndex = 10;
            this.PriceListAdd.Text = "Add";
            this.PriceListAdd.UseVisualStyleBackColor = true;
            this.PriceListAdd.Click += new System.EventHandler(this.PriceListAdd_Click);
            // 
            // PriceListimport
            // 
            this.PriceListimport.Location = new System.Drawing.Point(701, 313);
            this.PriceListimport.Name = "PriceListimport";
            this.PriceListimport.Size = new System.Drawing.Size(75, 23);
            this.PriceListimport.TabIndex = 9;
            this.PriceListimport.Text = "Import";
            this.PriceListimport.UseVisualStyleBackColor = true;
            this.PriceListimport.Click += new System.EventHandler(this.PriceListImport_Click);
            // 
            // priceListExport
            // 
            this.priceListExport.Location = new System.Drawing.Point(501, 313);
            this.priceListExport.Name = "priceListExport";
            this.priceListExport.Size = new System.Drawing.Size(75, 23);
            this.priceListExport.TabIndex = 8;
            this.priceListExport.Text = "Export";
            this.priceListExport.UseVisualStyleBackColor = true;
            this.priceListExport.Click += new System.EventHandler(this.PriceListExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "PRICE-LIST";
            // 
            // PriceListBox
            // 
            this.PriceListBox.FormattingEnabled = true;
            this.PriceListBox.Location = new System.Drawing.Point(501, 30);
            this.PriceListBox.Name = "PriceListBox";
            this.PriceListBox.Size = new System.Drawing.Size(275, 277);
            this.PriceListBox.TabIndex = 6;
            // 
            // PriceListPriceInput
            // 
            this.PriceListPriceInput.Location = new System.Drawing.Point(395, 67);
            this.PriceListPriceInput.Name = "PriceListPriceInput";
            this.PriceListPriceInput.Size = new System.Drawing.Size(100, 20);
            this.PriceListPriceInput.TabIndex = 12;
            // 
            // PriceListIdInput
            // 
            this.PriceListIdInput.Location = new System.Drawing.Point(395, 41);
            this.PriceListIdInput.Name = "PriceListIdInput";
            this.PriceListIdInput.Size = new System.Drawing.Size(100, 20);
            this.PriceListIdInput.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Price:";
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PriceListIdInput);
            this.Controls.Add(this.PriceListPriceInput);
            this.Controls.Add(this.PriceListRemove);
            this.Controls.Add(this.PriceListAdd);
            this.Controls.Add(this.PriceListimport);
            this.Controls.Add(this.priceListExport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PriceListBox);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(825, 392);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PriceListRemove;
        private System.Windows.Forms.Button PriceListAdd;
        private System.Windows.Forms.Button PriceListimport;
        private System.Windows.Forms.Button priceListExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox PriceListBox;
        private System.Windows.Forms.TextBox PriceListPriceInput;
        private System.Windows.Forms.TextBox PriceListIdInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
