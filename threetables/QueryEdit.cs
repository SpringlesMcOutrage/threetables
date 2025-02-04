using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace threetables
{
    public partial class QueryEdit : Form
    {
        private const string connectionString = "Server=localhost;Database=threetables;Integrated Security=True;TrustServerCertificate=True;";
        private string currentTable = "";

        public QueryEdit()
        {
            InitializeComponent();
        }

        private void QueryEdit_Load(object sender, EventArgs e)
        {
            richTextBoxQuery.Text = "SELECT * FROM Users";
        }

        private void buttonDoSQL_Click(object sender, EventArgs e)
        {
            ExecuteQuery(richTextBoxQuery.Text);
        }

        private void ExecuteQuery(string query)
        {
            try
            {
                using (SqlConnection sqlconn = new SqlConnection(connectionString))
                {
                    sqlconn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, sqlconn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewResults.DataSource = dt;

                    if (dt.Rows.Count > 0)
                    {
                        currentTable = GetTableNameFromQuery(query);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private string GetTableNameFromQuery(string query)
        {
            string[] keywords = { "FROM", "JOIN", "UPDATE", "INTO" };
            string[] words = query.Split(' ');
            for (int i = 0; i < words.Length - 1; i++)
            {
                if (Array.Exists(keywords, k => k.Equals(words[i], StringComparison.OrdinalIgnoreCase)))
                {
                    return words[i + 1];
                }
            }
            return "";
        }

        private void dataGridViewResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || string.IsNullOrEmpty(currentTable))
                return;

            DataGridViewRow row = dataGridViewResults.Rows[e.RowIndex];
            string[] columnNames = new string[row.Cells.Count];
            object[] values = new object[row.Cells.Count];

            for (int i = 0; i < row.Cells.Count; i++)
            {
                columnNames[i] = dataGridViewResults.Columns[i].HeaderText;
                values[i] = row.Cells[i].Value;
            }

            EditForm editForm = new EditForm(currentTable, columnNames, values);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                ExecuteQuery($"SELECT * FROM {currentTable}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBoxQuery.Clear();
        }
    }
}
