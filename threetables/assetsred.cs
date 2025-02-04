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
            buttonDelete.Visible = assetId.HasValue;
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!assetId.HasValue)
                return;

            var confirmResult = MessageBox.Show("Ви впевнені, що хочете видалити цей актив?",
                                                "Підтвердження видалення",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                string connectionString = "Server=localhost;Database=threetables;Integrated Security=True;TrustServerCertificate=True;";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlTransaction transaction = connection.BeginTransaction();

                        try
                        {
                            string deleteQuery = "DELETE FROM Assets WHERE asset_id = @assetId";
                            using (SqlCommand command = new SqlCommand(deleteQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@assetId", assetId.Value);
                                command.ExecuteNonQuery();
                            }

                            string createTempTable = @"
                    CREATE TABLE Assets_New (
                        asset_id INT IDENTITY(1,1) PRIMARY KEY,
                        name NVARCHAR(255) NOT NULL,
                        symbol NVARCHAR(50) NOT NULL,
                        current_price DECIMAL(18,2) NOT NULL,
                        type NVARCHAR(50) NOT NULL
                    );";
                            using (SqlCommand command = new SqlCommand(createTempTable, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                            }
                            string copyData = @"
                    INSERT INTO Assets_New (name, symbol, current_price, type)
                    SELECT name, symbol, current_price, type FROM Assets ORDER BY asset_id;";
                            using (SqlCommand command = new SqlCommand(copyData, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                            }
                            string dropOldTable = "DROP TABLE Assets;";
                            using (SqlCommand command = new SqlCommand(dropOldTable, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                            }
                            string renameTable = "EXEC sp_rename 'Assets_New', 'Assets';";
                            using (SqlCommand command = new SqlCommand(renameTable, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Актив успішно видалено.");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Помилка видалення активу: {ex.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка підключення до бази даних: {ex.Message}");
                }
            }
        }
    }
}
