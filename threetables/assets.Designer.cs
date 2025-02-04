namespace threetables
{
    partial class assets
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
            buttonAddAsset = new Button();
            label2 = new Label();
            dataGridViewAssets = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAssets).BeginInit();
            SuspendLayout();
            // 
            // buttonAddAsset
            // 
            buttonAddAsset.Font = new Font("Segoe UI", 14F);
            buttonAddAsset.Location = new Point(311, 378);
            buttonAddAsset.Name = "buttonAddAsset";
            buttonAddAsset.Size = new Size(203, 44);
            buttonAddAsset.TabIndex = 0;
            buttonAddAsset.Text = "Додати актив";
            buttonAddAsset.UseVisualStyleBackColor = true;
            buttonAddAsset.Click += buttonAddAsset_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(774, -2);
            label2.Name = "label2";
            label2.Size = new Size(26, 30);
            label2.TabIndex = 1;
            label2.Text = "X";
            label2.Click += label2_Click;
            // 
            // dataGridViewAssets
            // 
            dataGridViewAssets.AllowUserToAddRows = false;
            dataGridViewAssets.AllowUserToDeleteRows = false;
            dataGridViewAssets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAssets.Location = new Point(62, 60);
            dataGridViewAssets.Name = "dataGridViewAssets";
            dataGridViewAssets.ReadOnly = true;
            dataGridViewAssets.Size = new Size(684, 292);
            dataGridViewAssets.TabIndex = 2;
            dataGridViewAssets.CellClick += dataGridViewAssets_CellDoubleClick;
            // 
            // assets
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewAssets);
            Controls.Add(label2);
            Controls.Add(buttonAddAsset);
            FormBorderStyle = FormBorderStyle.None;
            Name = "assets";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "assets";
            ((System.ComponentModel.ISupportInitialize)dataGridViewAssets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAddAsset;
        private Label label2;
        private DataGridView dataGridViewAssets;
    }
}