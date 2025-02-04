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
    public partial class assetsred : Form
    {
        private int? assetId;

        public assetsred(int? assetId = null)
        {
            InitializeComponent();
            this.assetId = assetId;
            InitializeTypeComboBox();

            if (assetId.HasValue)
                LoadAssetDetails(assetId.Value);

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void InitializeTypeComboBox()
        {
            comboBoxType.Items.Clear();
            comboBoxType.Items.Add("Stock");
            comboBoxType.Items.Add("Crypto");
            comboBoxType.Items.Add("Commodity");
            comboBoxType.SelectedIndex = 0;
        }

        private void LoadAssetDetails(int assetId)
        {
            string connectionString = "Server=localhost;Database=threetables;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT asset_id, name, symbol, current_price, type FROM Assets WHERE asset_id = @assetId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@assetId", assetId);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            textBoxName.Text = reader["name"].ToString();
                            textBoxSymbol.Text = reader["symbol"].ToString();
                            textBoxPrice.Text = reader["current_price"].ToString();
                            comboBoxType.SelectedItem = reader["type"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading asset details: {ex.Message}");
            }
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string symbol = textBoxSymbol.Text;
            string type = comboBoxType.SelectedItem.ToString();

            if (!decimal.TryParse(textBoxPrice.Text, out decimal currentPrice))
            {
                MessageBox.Show("Введіть коректну ціну.");
                return;
            }

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(symbol) || string.IsNullOrEmpty(type))
            {
                MessageBox.Show("Усі поля обов'язкові для заповнення.");
                return;
            }

            string connectionString = "Server=localhost;Database=BLACK;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (assetId.HasValue)
                    {
                        string updateQuery = @"
                            UPDATE Assets
                            SET current_price = @Price, name = @Name, symbol = @Symbol, type = @Type
                            WHERE asset_id = @AssetId";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Price", currentPrice);
                            command.Parameters.AddWithValue("@Name", name);
                            command.Parameters.AddWithValue("@Symbol", symbol);
                            command.Parameters.AddWithValue("@Type", type);
                            command.Parameters.AddWithValue("@AssetId", assetId.Value);

                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string insertQuery = @"
                            INSERT INTO Assets (current_price, name, symbol, type)
                            VALUES (@Price, @Name, @Symbol, @Type)";

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Price", currentPrice);
                            command.Parameters.AddWithValue("@Name", name);
                            command.Parameters.AddWithValue("@Symbol", symbol);
                            command.Parameters.AddWithValue("@Type", type);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Зміни збережено успішно.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження активу: {ex.Message}");
            }
        }
    }
}
