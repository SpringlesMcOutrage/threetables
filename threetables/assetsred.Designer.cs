namespace threetables
{
    partial class assetsred
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
            label2 = new Label();
            comboBoxType = new ComboBox();
            textBoxName = new TextBox();
            textBoxSymbol = new TextBox();
            textBoxPrice = new TextBox();
            buttonSave = new Button();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            buttonDelete = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(775, 0);
            label2.Name = "label2";
            label2.Size = new Size(26, 30);
            label2.TabIndex = 0;
            label2.Text = "X";
            label2.Click += label2_Click;
            // 
            // comboBoxType
            // 
            comboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(325, 81);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(336, 23);
            comboBoxType.TabIndex = 1;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(325, 140);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(336, 23);
            textBoxName.TabIndex = 2;
            // 
            // textBoxSymbol
            // 
            textBoxSymbol.Location = new Point(325, 201);
            textBoxSymbol.Name = "textBoxSymbol";
            textBoxSymbol.Size = new Size(336, 23);
            textBoxSymbol.TabIndex = 3;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(325, 266);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(336, 23);
            textBoxPrice.TabIndex = 4;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 14F);
            buttonSave.Location = new Point(428, 340);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(174, 49);
            buttonSave.TabIndex = 5;
            buttonSave.Text = "Зберегти";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(193, 81);
            label1.Name = "label1";
            label1.Size = new Size(44, 25);
            label1.TabIndex = 6;
            label1.Text = "Тип";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(193, 140);
            label3.Name = "label3";
            label3.Size = new Size(44, 25);
            label3.TabIndex = 7;
            label3.Text = "Ім'я";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(193, 201);
            label4.Name = "label4";
            label4.Size = new Size(79, 25);
            label4.TabIndex = 8;
            label4.Text = "Символ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(193, 266);
            label5.Name = "label5";
            label5.Size = new Size(52, 25);
            label5.TabIndex = 9;
            label5.Text = "Ціна";
            // 
            // buttonDelete
            // 
            buttonDelete.Font = new Font("Segoe UI", 14F);
            buttonDelete.Location = new Point(168, 340);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(194, 49);
            buttonDelete.TabIndex = 20;
            buttonDelete.Text = "Видалити запис";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // assetsred
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonDelete);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(buttonSave);
            Controls.Add(textBoxPrice);
            Controls.Add(textBoxSymbol);
            Controls.Add(textBoxName);
            Controls.Add(comboBoxType);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "assetsred";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "assetsred";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private ComboBox comboBoxType;
        private TextBox textBoxName;
        private TextBox textBoxSymbol;
        private TextBox textBoxPrice;
        private Button buttonSave;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button buttonDelete;
    }
}