namespace AppSharp1
{
    partial class ClientsControl
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
            this.components = new System.ComponentModel.Container();
            this.ClientsListBox = new System.Windows.Forms.ListBox();
            this.buttonAddClient = new System.Windows.Forms.Button();
            this.clientNameTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRemoveClient = new System.Windows.Forms.Button();
            this.buttonEditClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ClientsListBox
            // 
            this.ClientsListBox.FormattingEnabled = true;
            this.ClientsListBox.Location = new System.Drawing.Point(213, 3);
            this.ClientsListBox.Name = "ClientsListBox";
            this.ClientsListBox.Size = new System.Drawing.Size(379, 238);
            this.ClientsListBox.TabIndex = 0;
            // 
            // buttonAddClient
            // 
            this.buttonAddClient.Location = new System.Drawing.Point(3, 26);
            this.buttonAddClient.Name = "buttonAddClient";
            this.buttonAddClient.Size = new System.Drawing.Size(75, 23);
            this.buttonAddClient.TabIndex = 1;
            this.buttonAddClient.Text = "Add New";
            this.buttonAddClient.UseVisualStyleBackColor = true;
            this.buttonAddClient.Click += new System.EventHandler(this.buttonAddClient_Click);
            // 
            // clientNameTextBox
            // 
            this.clientNameTextBox.Location = new System.Drawing.Point(38, 0);
            this.clientNameTextBox.Name = "clientNameTextBox";
            this.clientNameTextBox.Size = new System.Drawing.Size(157, 20);
            this.clientNameTextBox.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name: ";
            // 
            // buttonRemoveClient
            // 
            this.buttonRemoveClient.Location = new System.Drawing.Point(598, 3);
            this.buttonRemoveClient.Name = "buttonRemoveClient";
            this.buttonRemoveClient.Size = new System.Drawing.Size(102, 23);
            this.buttonRemoveClient.TabIndex = 5;
            this.buttonRemoveClient.Text = "Remove";
            this.buttonRemoveClient.UseVisualStyleBackColor = true;
            this.buttonRemoveClient.Click += new System.EventHandler(this.buttonRemoveClient_Click);
            // 
            // buttonEditClient
            // 
            this.buttonEditClient.Location = new System.Drawing.Point(93, 26);
            this.buttonEditClient.Name = "buttonEditClient";
            this.buttonEditClient.Size = new System.Drawing.Size(102, 23);
            this.buttonEditClient.TabIndex = 6;
            this.buttonEditClient.Text = "Edit Selected";
            this.buttonEditClient.UseVisualStyleBackColor = true;
            this.buttonEditClient.Click += new System.EventHandler(this.buttonEditClient_Click);
            // 
            // ClientsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonEditClient);
            this.Controls.Add(this.buttonRemoveClient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clientNameTextBox);
            this.Controls.Add(this.buttonAddClient);
            this.Controls.Add(this.ClientsListBox);
            this.Name = "ClientsControl";
            this.Size = new System.Drawing.Size(863, 462);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ClientsListBox;
        private System.Windows.Forms.Button buttonAddClient;
        private System.Windows.Forms.TextBox clientNameTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRemoveClient;
        private System.Windows.Forms.Button buttonEditClient;
    }
}
