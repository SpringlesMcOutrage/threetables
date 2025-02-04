namespace threetables
{
    partial class user
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
            dataGridViewUsers = new DataGridView();
            buttonAddUser = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(774, 9);
            label1.Name = "label1";
            label1.Size = new Size(26, 30);
            label1.TabIndex = 0;
            label1.Text = "X";
            label1.Click += label1_Click;
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Location = new Point(83, 58);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.Size = new Size(623, 283);
            dataGridViewUsers.TabIndex = 1;
            dataGridViewUsers.CellClick += dataGridViewUsers_CellClick;
            // 
            // buttonAddUser
            // 
            buttonAddUser.Location = new Point(290, 382);
            buttonAddUser.Name = "buttonAddUser";
            buttonAddUser.Size = new Size(206, 33);
            buttonAddUser.TabIndex = 2;
            buttonAddUser.Text = "Додати користувача";
            buttonAddUser.UseVisualStyleBackColor = true;
            buttonAddUser.Click += buttonAddUser_Click;
            // 
            // user
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonAddUser);
            Controls.Add(dataGridViewUsers);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "user";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "user";
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridViewUsers;
        private Button buttonAddUser;
    }
}