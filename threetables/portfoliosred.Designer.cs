namespace threetables
{
    partial class portfoliosred
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
            comboBoxUser = new ComboBox();
            comboBoxAsset = new ComboBox();
            textBoxAveragePrice = new TextBox();
            textBoxQuantity = new TextBox();
            buttonSave = new Button();
            buttonDelete = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // comboBoxUser
            // 
            comboBoxUser.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUser.FormattingEnabled = true;
            comboBoxUser.Location = new Point(404, 78);
            comboBoxUser.Name = "comboBoxUser";
            comboBoxUser.Size = new Size(275, 23);
            comboBoxUser.TabIndex = 0;
            // 
            // comboBoxAsset
            // 
            comboBoxAsset.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAsset.FormattingEnabled = true;
            comboBoxAsset.Location = new Point(404, 140);
            comboBoxAsset.Name = "comboBoxAsset";
            comboBoxAsset.Size = new Size(275, 23);
            comboBoxAsset.TabIndex = 1;
            // 
            // textBoxAveragePrice
            // 
            textBoxAveragePrice.Location = new Point(404, 204);
            textBoxAveragePrice.Name = "textBoxAveragePrice";
            textBoxAveragePrice.Size = new Size(275, 23);
            textBoxAveragePrice.TabIndex = 2;
            // 
            // textBoxQuantity
            // 
            textBoxQuantity.Location = new Point(404, 269);
            textBoxQuantity.Name = "textBoxQuantity";
            textBoxQuantity.Size = new Size(275, 23);
            textBoxQuantity.TabIndex = 3;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 12F);
            buttonSave.Location = new Point(450, 356);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(146, 34);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Зберегти запис";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Font = new Font("Segoe UI", 12F);
            buttonDelete.Location = new Point(214, 356);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(152, 36);
            buttonDelete.TabIndex = 5;
            buttonDelete.Text = "Видалити запис";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(770, 0);
            label1.Name = "label1";
            label1.Size = new Size(32, 30);
            label1.TabIndex = 6;
            label1.Text = "X ";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(239, 76);
            label2.Name = "label2";
            label2.Size = new Size(113, 25);
            label2.TabIndex = 7;
            label2.Text = "Користувач";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(239, 140);
            label3.Name = "label3";
            label3.Size = new Size(62, 25);
            label3.TabIndex = 8;
            label3.Text = "Актив";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(239, 204);
            label4.Name = "label4";
            label4.Size = new Size(128, 25);
            label4.TabIndex = 9;
            label4.Text = "Середня ціна";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(239, 264);
            label5.Name = "label5";
            label5.Size = new Size(89, 25);
            label5.TabIndex = 10;
            label5.Text = "Кількість";
            // 
            // portfoliosred
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonDelete);
            Controls.Add(buttonSave);
            Controls.Add(textBoxQuantity);
            Controls.Add(textBoxAveragePrice);
            Controls.Add(comboBoxAsset);
            Controls.Add(comboBoxUser);
            FormBorderStyle = FormBorderStyle.None;
            Name = "portfoliosred";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "portfoliosred";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxUser;
        private ComboBox comboBoxAsset;
        private TextBox textBoxAveragePrice;
        private TextBox textBoxQuantity;
        private Button buttonSave;
        private Button buttonDelete;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}