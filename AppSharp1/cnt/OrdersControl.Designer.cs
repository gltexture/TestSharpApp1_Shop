namespace AppSharp1.cnt
{
    partial class OrdersControl
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.orderQuanityTextBox = new System.Windows.Forms.TextBox();
            this.ClientsListBox = new System.Windows.Forms.ListBox();
            this.buttonRemoveOrder = new System.Windows.Forms.Button();
            this.buttonAddOrder = new System.Windows.Forms.Button();
            this.OrdersListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ProductsListBox = new System.Windows.Forms.ListBox();
            this.DeliveredTrueButton = new System.Windows.Forms.Button();
            this.DeliveredFalseButton = new System.Windows.Forms.Button();
            this.dateOrder = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSetQuanity = new System.Windows.Forms.Button();
            this.OrderItemsListBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Clients:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(609, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Quantity:";
            // 
            // orderQuanityTextBox
            // 
            this.orderQuanityTextBox.Location = new System.Drawing.Point(656, 135);
            this.orderQuanityTextBox.Name = "orderQuanityTextBox";
            this.orderQuanityTextBox.Size = new System.Drawing.Size(100, 20);
            this.orderQuanityTextBox.TabIndex = 21;
            // 
            // ClientsListBox
            // 
            this.ClientsListBox.FormattingEnabled = true;
            this.ClientsListBox.Location = new System.Drawing.Point(69, 247);
            this.ClientsListBox.Name = "ClientsListBox";
            this.ClientsListBox.Size = new System.Drawing.Size(379, 82);
            this.ClientsListBox.TabIndex = 20;
            // 
            // buttonRemoveOrder
            // 
            this.buttonRemoveOrder.Location = new System.Drawing.Point(607, 3);
            this.buttonRemoveOrder.Name = "buttonRemoveOrder";
            this.buttonRemoveOrder.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveOrder.TabIndex = 19;
            this.buttonRemoveOrder.Text = "Remove";
            this.buttonRemoveOrder.UseVisualStyleBackColor = true;
            this.buttonRemoveOrder.Click += new System.EventHandler(this.buttonRemoveOrder_Click);
            // 
            // buttonAddOrder
            // 
            this.buttonAddOrder.Location = new System.Drawing.Point(13, 52);
            this.buttonAddOrder.Name = "buttonAddOrder";
            this.buttonAddOrder.Size = new System.Drawing.Size(75, 23);
            this.buttonAddOrder.TabIndex = 16;
            this.buttonAddOrder.Text = "Add New";
            this.buttonAddOrder.UseVisualStyleBackColor = true;
            this.buttonAddOrder.Click += new System.EventHandler(this.ButtonAddOrder_Click);
            // 
            // OrdersListBox
            // 
            this.OrdersListBox.FormattingEnabled = true;
            this.OrdersListBox.Location = new System.Drawing.Point(222, 3);
            this.OrdersListBox.Name = "OrdersListBox";
            this.OrdersListBox.Size = new System.Drawing.Size(379, 238);
            this.OrdersListBox.TabIndex = 15;
            this.OrdersListBox.SelectedIndexChanged += new System.EventHandler(this.OrdersListBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 335);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Products:";
            // 
            // ProductsListBox
            // 
            this.ProductsListBox.FormattingEnabled = true;
            this.ProductsListBox.Location = new System.Drawing.Point(69, 335);
            this.ProductsListBox.Name = "ProductsListBox";
            this.ProductsListBox.Size = new System.Drawing.Size(379, 82);
            this.ProductsListBox.TabIndex = 25;
            // 
            // DeliveredTrueButton
            // 
            this.DeliveredTrueButton.Location = new System.Drawing.Point(607, 53);
            this.DeliveredTrueButton.Name = "DeliveredTrueButton";
            this.DeliveredTrueButton.Size = new System.Drawing.Size(104, 23);
            this.DeliveredTrueButton.TabIndex = 26;
            this.DeliveredTrueButton.Text = "Delivered=true";
            this.DeliveredTrueButton.UseVisualStyleBackColor = true;
            this.DeliveredTrueButton.Click += new System.EventHandler(this.DeliveredTrueButton_Click);
            // 
            // DeliveredFalseButton
            // 
            this.DeliveredFalseButton.Location = new System.Drawing.Point(607, 82);
            this.DeliveredFalseButton.Name = "DeliveredFalseButton";
            this.DeliveredFalseButton.Size = new System.Drawing.Size(104, 23);
            this.DeliveredFalseButton.TabIndex = 27;
            this.DeliveredFalseButton.Text = "Delivered=false";
            this.DeliveredFalseButton.UseVisualStyleBackColor = true;
            this.DeliveredFalseButton.Click += new System.EventHandler(this.DeliveredFalseButton_Click);
            // 
            // dateOrder
            // 
            this.dateOrder.Location = new System.Drawing.Point(4, 26);
            this.dateOrder.Name = "dateOrder";
            this.dateOrder.Size = new System.Drawing.Size(200, 20);
            this.dateOrder.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Orders:";
            // 
            // buttonSetQuanity
            // 
            this.buttonSetQuanity.Location = new System.Drawing.Point(612, 161);
            this.buttonSetQuanity.Name = "buttonSetQuanity";
            this.buttonSetQuanity.Size = new System.Drawing.Size(75, 23);
            this.buttonSetQuanity.TabIndex = 30;
            this.buttonSetQuanity.Text = "SetQuantity";
            this.buttonSetQuanity.UseVisualStyleBackColor = true;
            this.buttonSetQuanity.Click += new System.EventHandler(this.ButtonSetQuanity_Click);
            // 
            // OrderItemsListBox
            // 
            this.OrderItemsListBox.FormattingEnabled = true;
            this.OrderItemsListBox.Location = new System.Drawing.Point(454, 263);
            this.OrderItemsListBox.Name = "OrderItemsListBox";
            this.OrderItemsListBox.Size = new System.Drawing.Size(302, 121);
            this.OrderItemsListBox.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(454, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Order Items:";
            // 
            // OrdersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OrderItemsListBox);
            this.Controls.Add(this.buttonSetQuanity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateOrder);
            this.Controls.Add(this.DeliveredFalseButton);
            this.Controls.Add(this.DeliveredTrueButton);
            this.Controls.Add(this.ProductsListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.orderQuanityTextBox);
            this.Controls.Add(this.ClientsListBox);
            this.Controls.Add(this.buttonRemoveOrder);
            this.Controls.Add(this.buttonAddOrder);
            this.Controls.Add(this.OrdersListBox);
            this.Name = "OrdersControl";
            this.Size = new System.Drawing.Size(889, 508);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox orderQuanityTextBox;
        private System.Windows.Forms.ListBox ClientsListBox;
        private System.Windows.Forms.Button buttonRemoveOrder;
        private System.Windows.Forms.Button buttonAddOrder;
        private System.Windows.Forms.ListBox OrdersListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox ProductsListBox;
        private System.Windows.Forms.Button DeliveredTrueButton;
        private System.Windows.Forms.Button DeliveredFalseButton;
        private System.Windows.Forms.DateTimePicker dateOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSetQuanity;
        private System.Windows.Forms.ListBox OrderItemsListBox;
        private System.Windows.Forms.Label label5;
    }
}
