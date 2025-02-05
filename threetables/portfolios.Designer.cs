namespace threetables
{
    partial class portfolios
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
            buttonAddPortfolio = new Button();
            dataGridViewPortfolios = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPortfolios).BeginInit();
            SuspendLayout();
            // 
            // buttonAddPortfolio
            // 
            buttonAddPortfolio.Font = new Font("Segoe UI", 14F);
            buttonAddPortfolio.Location = new Point(302, 380);
            buttonAddPortfolio.Name = "buttonAddPortfolio";
            buttonAddPortfolio.Size = new Size(206, 38);
            buttonAddPortfolio.TabIndex = 5;
            buttonAddPortfolio.Text = "Додати запис";
            buttonAddPortfolio.UseVisualStyleBackColor = true;
            buttonAddPortfolio.Click += buttonAddPortfolio_Click;
            // 
            // dataGridViewPortfolios
            // 
            dataGridViewPortfolios.AllowUserToAddRows = false;
            dataGridViewPortfolios.AllowUserToDeleteRows = false;
            dataGridViewPortfolios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPortfolios.Location = new Point(73, 70);
            dataGridViewPortfolios.Name = "dataGridViewPortfolios";
            dataGridViewPortfolios.ReadOnly = true;
            dataGridViewPortfolios.Size = new Size(671, 278);
            dataGridViewPortfolios.TabIndex = 4;
            dataGridViewPortfolios.CellClick += dataGridViewPortfolios_CellDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(775, 0);
            label1.Name = "label1";
            label1.Size = new Size(26, 30);
            label1.TabIndex = 3;
            label1.Text = "X";
            label1.Click += label1_Click;
            // 
            // portfolios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonAddPortfolio);
            Controls.Add(dataGridViewPortfolios);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "portfolios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "portfolios";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPortfolios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAddPortfolio;
        private DataGridView dataGridViewPortfolios;
        private Label label1;
    }
}