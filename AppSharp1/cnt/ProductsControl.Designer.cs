namespace AppSharp1
{
    partial class ProductsControl
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
            this.buttonRemoveProduct = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.productNameTextBox = new System.Windows.Forms.TextBox();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.ProductsListBox = new System.Windows.Forms.ListBox();
            this.PricesListBox = new System.Windows.Forms.ListBox();
            this.productIdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonEditProduct = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRemoveProduct
            // 
            this.buttonRemoveProduct.Location = new System.Drawing.Point(607, 3);
            this.buttonRemoveProduct.Name = "buttonRemoveProduct";
            this.buttonRemoveProduct.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveProduct.TabIndex = 10;
            this.buttonRemoveProduct.Text = "Remove";
            this.buttonRemoveProduct.UseVisualStyleBackColor = true;
            this.buttonRemoveProduct.Click += new System.EventHandler(this.buttonRemoveProduct_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Name: ";
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.Location = new System.Drawing.Point(47, 0);
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.Size = new System.Drawing.Size(157, 20);
            this.productNameTextBox.TabIndex = 8;
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(14, 53);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(75, 23);
            this.buttonAddProduct.TabIndex = 7;
            this.buttonAddProduct.Text = "Add New";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // ProductsListBox
            // 
            this.ProductsListBox.FormattingEnabled = true;
            this.ProductsListBox.Location = new System.Drawing.Point(222, 3);
            this.ProductsListBox.Name = "ProductsListBox";
            this.ProductsListBox.Size = new System.Drawing.Size(379, 238);
            this.ProductsListBox.TabIndex = 6;
            // 
            // PricesListBox
            // 
            this.PricesListBox.FormattingEnabled = true;
            this.PricesListBox.Location = new System.Drawing.Point(222, 247);
            this.PricesListBox.Name = "PricesListBox";
            this.PricesListBox.Size = new System.Drawing.Size(379, 121);
            this.PricesListBox.TabIndex = 11;
            // 
            // productIdTextBox
            // 
            this.productIdTextBox.Location = new System.Drawing.Point(47, 27);
            this.productIdTextBox.Name = "productIdTextBox";
            this.productIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.productIdTextBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Price ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Prices:";
            // 
            // buttonEditProduct
            // 
            this.buttonEditProduct.Location = new System.Drawing.Point(95, 53);
            this.buttonEditProduct.Name = "buttonEditProduct";
            this.buttonEditProduct.Size = new System.Drawing.Size(109, 23);
            this.buttonEditProduct.TabIndex = 15;
            this.buttonEditProduct.Text = "Edit Selected";
            this.buttonEditProduct.UseVisualStyleBackColor = true;
            this.buttonEditProduct.Click += new System.EventHandler(this.buttonEditProduct_Click);
            // 
            // ProductsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonEditProduct);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.productIdTextBox);
            this.Controls.Add(this.PricesListBox);
            this.Controls.Add(this.buttonRemoveProduct);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productNameTextBox);
            this.Controls.Add(this.buttonAddProduct);
            this.Controls.Add(this.ProductsListBox);
            this.Name = "ProductsControl";
            this.Size = new System.Drawing.Size(954, 521);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRemoveProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox productNameTextBox;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.ListBox ProductsListBox;
        private System.Windows.Forms.ListBox PricesListBox;
        private System.Windows.Forms.TextBox productIdTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonEditProduct;
    }
}
