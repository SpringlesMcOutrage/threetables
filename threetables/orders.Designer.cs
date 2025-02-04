namespace threetables
{
    partial class orders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            dataGridViewOrders = new DataGridView();
            buttonAddOrder = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(777, -1);
            label1.Name = "label1";
            label1.Size = new Size(26, 30);
            label1.TabIndex = 0;
            label1.Text = "X";
            label1.Click += label1_Click;
            // 
            // dataGridViewOrders
            // 
            dataGridViewOrders.AllowUserToAddRows = false;
            dataGridViewOrders.AllowUserToDeleteRows = false;
            dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrders.Location = new Point(78, 72);
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.ReadOnly = true;
            dataGridViewOrders.Size = new Size(671, 278);
            dataGridViewOrders.TabIndex = 1;
            dataGridViewOrders.CellClick += dataGridViewOrders_CellDoubleClick;
            // 
            // buttonAddOrder
            // 
            buttonAddOrder.Font = new Font("Segoe UI", 14F);
            buttonAddOrder.Location = new Point(315, 377);
            buttonAddOrder.Name = "buttonAddOrder";
            buttonAddOrder.Size = new Size(206, 38);
            buttonAddOrder.TabIndex = 2;
            buttonAddOrder.Text = "Додати замовлення";
            buttonAddOrder.UseVisualStyleBackColor = true;
            buttonAddOrder.Click += buttonAddOrder_Click;
            // 
            // orders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonAddOrder);
            Controls.Add(dataGridViewOrders);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "orders";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "orders";
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridViewOrders;
        private Button buttonAddOrder;
    }
}