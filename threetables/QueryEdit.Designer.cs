namespace threetables
{
    partial class QueryEdit
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
            buttonDoSQL = new Button();
            richTextBoxQuery = new RichTextBox();
            dataGridViewResults = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // buttonDoSQL
            // 
            buttonDoSQL.Location = new Point(658, 28);
            buttonDoSQL.Name = "buttonDoSQL";
            buttonDoSQL.Size = new Size(99, 35);
            buttonDoSQL.TabIndex = 0;
            buttonDoSQL.Text = "Do SQL";
            buttonDoSQL.UseVisualStyleBackColor = true;
            buttonDoSQL.Click += buttonDoSQL_Click;
            // 
            // richTextBoxQuery
            // 
            richTextBoxQuery.Location = new Point(84, 35);
            richTextBoxQuery.Name = "richTextBoxQuery";
            richTextBoxQuery.Size = new Size(556, 153);
            richTextBoxQuery.TabIndex = 1;
            richTextBoxQuery.Text = "";
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Location = new Point(84, 215);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.ReadOnly = true;
            dataGridViewResults.Size = new Size(704, 187);
            dataGridViewResults.TabIndex = 2;
            dataGridViewResults.CellClick += dataGridViewResults_CellDoubleClick;
            // 
            // button1
            // 
            button1.Location = new Point(658, 80);
            button1.Name = "button1";
            button1.Size = new Size(99, 36);
            button1.TabIndex = 3;
            button1.Text = "Clear";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(658, 140);
            button2.Name = "button2";
            button2.Size = new Size(99, 36);
            button2.TabIndex = 4;
            button2.Text = "EXIT";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // QueryEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridViewResults);
            Controls.Add(richTextBoxQuery);
            Controls.Add(buttonDoSQL);
            FormBorderStyle = FormBorderStyle.None;
            Name = "QueryEdit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QueryEdit";
            Load += QueryEdit_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonDoSQL;
        private RichTextBox richTextBoxQuery;
        private DataGridView dataGridViewResults;
        private Button button1;
        private Button button2;
    }
}