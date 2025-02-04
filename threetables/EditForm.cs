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
    public partial class EditForm : Form
    {
        private const string connectionString = "Server=localhost;Database=threetables;Integrated Security=True;TrustServerCertificate=True;";
        private string tableName;
        private string[] columnNames;
        private object[] values;

        public EditForm(string tableName, string[] columnNames, object[] values)
        {
            InitializeComponent();
            this.tableName = tableName;
            this.columnNames = columnNames;
            this.values = values;
            InitializeFields();
        }

        private void InitializeFields()
        {
            for (int i = 0; i < columnNames.Length; i++)
            {
                Label label = new Label
                {
                    Text = columnNames[i],
                    Top = 10 + (i * 30),
                    Left = 10
                };
                this.Controls.Add(label);

                TextBox textBox = new TextBox
                {
                    Name = "textBox_" + columnNames[i],
                    Text = values[i]?.ToString(),
                    Top = 10 + (i * 30),
                    Left = 120,
                    Width = 200
                };
                this.Controls.Add(textBox);
            }

            Button buttonSave = new Button
            {
                Text = "Зберегти",
                Top = 10 + (columnNames.Length * 30),
                Left = 10
            };
            buttonSave.Click += ButtonSave_Click;
            this.Controls.Add(buttonSave);

            Button buttonCancel = new Button
            {
                Text = "Відміна",
                Top = 10 + (columnNames.Length * 30),
                Left = 120
            };
            buttonCancel.Click += (sender, e) => this.Close();
            this.Controls.Add(buttonCancel);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlconn = new SqlConnection(connectionString))
                {
                    sqlconn.Open();
                    string updateQuery = GenerateUpdateQuery();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, sqlconn))
                    {
                        for (int i = 1; i < columnNames.Length; i++)
                        {
                            string controlName = "textBox_" + columnNames[i];
                            TextBox textBox = (TextBox)this.Controls[controlName];
                            cmd.Parameters.AddWithValue("@" + columnNames[i], textBox.Text);
                        }
                        cmd.Parameters.AddWithValue("@id", values[0]);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Дані оновлено!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при оновленні: " + ex.Message);
            }
        }

        private string GenerateUpdateQuery()
        {
            string primaryKey = columnNames[0];
            string setClause = "";

            for (int i = 1; i < columnNames.Length; i++)
            {
                setClause += columnNames[i] + " = @" + columnNames[i] + ",";
            }
            setClause = setClause.TrimEnd(',');

            return $"UPDATE {tableName} SET {setClause} WHERE {primaryKey} = @id";
        }
    }
}
