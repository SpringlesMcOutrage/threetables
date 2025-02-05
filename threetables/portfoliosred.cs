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
    public partial class portfoliosred : Form
    {
        private int? portfolioId;

        public portfoliosred(int? portfolioId = null)
        {
            InitializeComponent();
            this.portfolioId = portfolioId;
            LoadUsers();
            LoadAssets();

            if (portfolioId.HasValue)
                LoadPortfolioDetails(portfolioId.Value);

            buttonDelete.Visible = portfolioId.HasValue;
        }

        private void LoadUsers()
        {
            comboBoxUser.Items.Clear();

            string connectionString = "Server=localhost;Database=threetables;Integrated Security=True;TrustServerCertificate=True;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT user_id, name FROM Users";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var users = new List<KeyValuePair<int, string>>();
                        while (reader.Read())
                        {
                            users.Add(new KeyValuePair<int, string>((int)reader["user_id"], reader["name"].ToString()));
                        }
                        comboBoxUser.DataSource = users;
                        comboBoxUser.DisplayMember = "Value";
                        comboBoxUser.ValueMember = "Key";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження користувачів: {ex.Message}");
            }

            if (comboBoxUser.Items.Count > 0) comboBoxUser.SelectedIndex = 0;
        }

        private void LoadAssets()
        {
            comboBoxAsset.Items.Clear();

            string connectionString = "Server=localhost;Database=threetables;Integrated Security=True;TrustServerCertificate=True;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT asset_id, name FROM Assets";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var assets = new List<KeyValuePair<int, string>>();
                        while (reader.Read())
                        {
                            assets.Add(new KeyValuePair<int, string>((int)reader["asset_id"], reader["name"].ToString()));
                        }
                        comboBoxAsset.DataSource = assets;
                        comboBoxAsset.DisplayMember = "Value";
                        comboBoxAsset.ValueMember = "Key";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження активів: {ex.Message}");
            }

            if (comboBoxAsset.Items.Count > 0) comboBoxAsset.SelectedIndex = 0;
        }

        private void LoadPortfolioDetails(int portfolioId)
        {
            string connectionString = "Server=localhost;Database=threetables;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Portfolios WHERE portfolio_id = @portfolioId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@portfolioId", portfolioId);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            comboBoxUser.SelectedValue = Convert.ToInt32(reader["user_id"]);
                            comboBoxAsset.SelectedValue = Convert.ToInt32(reader["asset_id"]);
                            textBoxAveragePrice.Text = reader["average_price"].ToString();
                            textBoxQuantity.Text = reader["quantity"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження портфеля: {ex.Message}");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(textBoxAveragePrice.Text, out decimal averagePrice) || !decimal.TryParse(textBoxQuantity.Text, out decimal quantity))
            {
                MessageBox.Show("Введіть коректні дані для ціни та кількості.");
                return;
            }

            int userId = (int)comboBoxUser.SelectedValue;
            int assetId = (int)comboBoxAsset.SelectedValue;

            string connectionString = "Server=localhost;Database=threetables;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query;
                    if (portfolioId.HasValue)
                    {
                        query = @"
                            UPDATE Portfolios
                            SET user_id = @UserId, asset_id = @AssetId, average_price = @AveragePrice, quantity = @Quantity
                            WHERE portfolio_id = @PortfolioId";
                    }
                    else
                    {
                        query = @"
                            INSERT INTO Portfolios (user_id, asset_id, average_price, quantity)
                            VALUES (@UserId, @AssetId, @AveragePrice, @Quantity)";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (portfolioId.HasValue) command.Parameters.AddWithValue("@PortfolioId", portfolioId.Value);
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@AssetId", assetId);
                        command.Parameters.AddWithValue("@AveragePrice", averagePrice);
                        command.Parameters.AddWithValue("@Quantity", quantity);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Збережено успішно.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження портфеля: {ex.Message}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!portfolioId.HasValue)
                return;

            var confirmResult = MessageBox.Show("Ви впевнені, що хочете видалити цей портфель?",
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
                            string deleteQuery = "DELETE FROM Portfolios WHERE portfolio_id = @PortfolioId";
                            using (SqlCommand command = new SqlCommand(deleteQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@PortfolioId", portfolioId.Value);
                                command.ExecuteNonQuery();
                            }

                            string createTempTable = @"
                        CREATE TABLE Portfolios_New (
                            portfolio_id INT IDENTITY(1,1) PRIMARY KEY,
                            user_id INT NOT NULL,
                            asset_id INT NOT NULL,
                            average_price REAL NOT NULL,
                            quantity REAL NOT NULL
                        );";
                            using (SqlCommand command = new SqlCommand(createTempTable, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                            }

                            string copyData = @"
                        INSERT INTO Portfolios_New (user_id, asset_id, average_price, quantity)
                        SELECT user_id, asset_id, average_price, quantity FROM Portfolios ORDER BY portfolio_id;";
                            using (SqlCommand command = new SqlCommand(copyData, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                            }

                            string dropOldTable = "DROP TABLE Portfolios;";
                            using (SqlCommand command = new SqlCommand(dropOldTable, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                            }

                            string renameTable = "EXEC sp_rename 'Portfolios_New', 'Portfolios';";
                            using (SqlCommand command = new SqlCommand(renameTable, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Портфель успішно видалено.");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Помилка видалення портфеля: {ex.Message}");
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
