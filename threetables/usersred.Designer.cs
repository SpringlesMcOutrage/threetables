namespace threetables
{
    partial class usersred
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
            comboBoxRole = new ComboBox();
            textBoxEmail = new TextBox();
            textBoxName = new TextBox();
            textBoxPassword = new TextBox();
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
            label2.Location = new Point(774, -1);
            label2.Name = "label2";
            label2.Size = new Size(26, 30);
            label2.TabIndex = 0;
            label2.Text = "X";
            label2.Click += label2_Click;
            // 
            // comboBoxRole
            // 
            comboBoxRole.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRole.FormattingEnabled = true;
            comboBoxRole.Location = new Point(260, 83);
            comboBoxRole.Name = "comboBoxRole";
            comboBoxRole.Size = new Size(321, 23);
            comboBoxRole.TabIndex = 1;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(260, 147);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(321, 23);
            textBoxEmail.TabIndex = 2;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(260, 208);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(321, 23);
            textBoxName.TabIndex = 3;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(260, 277);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(321, 23);
            textBoxPassword.TabIndex = 4;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 14F);
            buttonSave.Location = new Point(471, 330);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(148, 52);
            buttonSave.TabIndex = 5;
            buttonSave.Text = "Зберегти";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(150, 83);
            label1.Name = "label1";
            label1.Size = new Size(54, 25);
            label1.TabIndex = 6;
            label1.Text = "Роль";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(150, 145);
            label3.Name = "label3";
            label3.Size = new Size(58, 25);
            label3.TabIndex = 7;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(150, 206);
            label4.Name = "label4";
            label4.Size = new Size(40, 25);
            label4.TabIndex = 8;
            label4.Text = "Імя";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(150, 272);
            label5.Name = "label5";
            label5.Size = new Size(78, 25);
            label5.TabIndex = 9;
            label5.Text = "Пароль";
            // 
            // buttonDelete
            // 
            buttonDelete.Font = new Font("Segoe UI", 14F);
            buttonDelete.Location = new Point(150, 333);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(194, 49);
            buttonDelete.TabIndex = 21;
            buttonDelete.Text = "Видалити запис";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // usersred
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
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxName);
            Controls.Add(textBoxEmail);
            Controls.Add(comboBoxRole);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "usersred";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "usersred";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private ComboBox comboBoxRole;
        private TextBox textBoxEmail;
        private TextBox textBoxName;
        private TextBox textBoxPassword;
        private Button buttonSave;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button buttonDelete;
    }
}