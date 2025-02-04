namespace threetables
{
    partial class ordersred
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
            comboBoxAsset = new ComboBox();
            comboBoxOrderType = new ComboBox();
            comboBoxTradeType = new ComboBox();
            comboBoxStatus = new ComboBox();
            dateTimePickerCreatedAt = new DateTimePicker();
            textBoxPrice = new TextBox();
            textBoxQuantity = new TextBox();
            buttonSave = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            comboBoxUser = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(778, -1);
            label1.Name = "label1";
            label1.Size = new Size(26, 30);
            label1.TabIndex = 0;
            label1.Text = "X";
            label1.Click += label1_Click;
            // 
            // comboBoxAsset
            // 
            comboBoxAsset.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAsset.FormattingEnabled = true;
            comboBoxAsset.Location = new Point(233, 150);
            comboBoxAsset.Name = "comboBoxAsset";
            comboBoxAsset.Size = new Size(309, 23);
            comboBoxAsset.TabIndex = 1;
            // 
            // comboBoxOrderType
            // 
            comboBoxOrderType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOrderType.FormattingEnabled = true;
            comboBoxOrderType.Location = new Point(233, 205);
            comboBoxOrderType.Name = "comboBoxOrderType";
            comboBoxOrderType.Size = new Size(309, 23);
            comboBoxOrderType.TabIndex = 2;
            // 
            // comboBoxTradeType
            // 
            comboBoxTradeType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTradeType.FormattingEnabled = true;
            comboBoxTradeType.Location = new Point(233, 246);
            comboBoxTradeType.Name = "comboBoxTradeType";
            comboBoxTradeType.Size = new Size(121, 23);
            comboBoxTradeType.TabIndex = 3;
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(421, 246);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(121, 23);
            comboBoxStatus.TabIndex = 4;
            // 
            // dateTimePickerCreatedAt
            // 
            dateTimePickerCreatedAt.Location = new Point(233, 285);
            dateTimePickerCreatedAt.Name = "dateTimePickerCreatedAt";
            dateTimePickerCreatedAt.Size = new Size(309, 23);
            dateTimePickerCreatedAt.TabIndex = 5;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(233, 101);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(309, 23);
            textBoxPrice.TabIndex = 6;
            // 
            // textBoxQuantity
            // 
            textBoxQuantity.Location = new Point(233, 57);
            textBoxQuantity.Name = "textBoxQuantity";
            textBoxQuantity.Size = new Size(309, 23);
            textBoxQuantity.TabIndex = 7;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 14F);
            buttonSave.Location = new Point(298, 372);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(227, 37);
            buttonSave.TabIndex = 9;
            buttonSave.Text = "Зберегти замовлення";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(142, 57);
            label2.Name = "label2";
            label2.Size = new Size(63, 19);
            label2.TabIndex = 10;
            label2.Text = "Кількість";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(142, 105);
            label3.Name = "label3";
            label3.Size = new Size(37, 19);
            label3.TabIndex = 11;
            label3.Text = "Ціна";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(142, 154);
            label4.Name = "label4";
            label4.Size = new Size(46, 19);
            label4.TabIndex = 12;
            label4.Text = "Актив";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(142, 205);
            label5.Name = "label5";
            label5.Size = new Size(82, 19);
            label5.TabIndex = 13;
            label5.Text = "Тип ордеру";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(142, 246);
            label6.Name = "label6";
            label6.Size = new Size(80, 19);
            label6.TabIndex = 14;
            label6.Text = "Тип трейду";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(142, 289);
            label7.Name = "label7";
            label7.Size = new Size(70, 19);
            label7.TabIndex = 15;
            label7.Text = "Створено";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(142, 327);
            label8.Name = "label8";
            label8.Size = new Size(82, 19);
            label8.TabIndex = 16;
            label8.Text = "Користувач";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.Location = new Point(360, 247);
            label9.Name = "label9";
            label9.Size = new Size(50, 19);
            label9.TabIndex = 17;
            label9.Text = "Статус";
            // 
            // comboBoxUser
            // 
            comboBoxUser.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUser.FormattingEnabled = true;
            comboBoxUser.Location = new Point(233, 326);
            comboBoxUser.Name = "comboBoxUser";
            comboBoxUser.Size = new Size(312, 23);
            comboBoxUser.TabIndex = 18;
            // 
            // ordersred
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBoxUser);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(buttonSave);
            Controls.Add(textBoxQuantity);
            Controls.Add(textBoxPrice);
            Controls.Add(dateTimePickerCreatedAt);
            Controls.Add(comboBoxStatus);
            Controls.Add(comboBoxTradeType);
            Controls.Add(comboBoxOrderType);
            Controls.Add(comboBoxAsset);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ordersred";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ordersred";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBoxAsset;
        private ComboBox comboBoxOrderType;
        private ComboBox comboBoxTradeType;
        private ComboBox comboBoxStatus;
        private DateTimePicker dateTimePickerCreatedAt;
        private TextBox textBoxPrice;
        private TextBox textBoxQuantity;
        private Button buttonSave;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private ComboBox comboBoxUser;
    }
}