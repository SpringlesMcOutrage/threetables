using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace threetables
{
    public partial class ordersred : Form
    {
        private int? orderId;

        public ordersred(int? orderId = null)
        {
            InitializeComponent();
            this.orderId = orderId;
            LoadAssets();
            LoadUsers();
            InitializeOrderTypeComboBox();
            InitializeTradeTypeComboBox();
            InitializeStatusComboBox();

            if (orderId.HasValue)
                LoadOrderDetails(orderId.Value);
            buttonDelete.Visible = orderId.HasValue;

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

        private void InitializeOrderTypeComboBox()
        {
            comboBoxOrderType.Items.Clear();
            comboBoxOrderType.Items.Add("limit");
            comboBoxOrderType.Items.Add("market");
            comboBoxOrderType.SelectedIndex = 0;
        }

        private void InitializeTradeTypeComboBox()
        {
            comboBoxTradeType.Items.Clear();
            comboBoxTradeType.Items.Add("buy");
            comboBoxTradeType.Items.Add("sell");
            comboBoxTradeType.SelectedIndex = 0;
        }

        private void InitializeStatusComboBox()
        {
            comboBoxStatus.Items.Clear();
            comboBoxStatus.Items.Add("open");
            comboBoxStatus.Items.Add("closed");
            comboBoxStatus.Items.Add("cancelled");
            comboBoxStatus.SelectedIndex = 0;
        }

        private void LoadOrderDetails(int orderId)
        {
            string connectionString = "Server=localhost;Database=threetables;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Orders WHERE order_id = @orderId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@orderId", orderId);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            comboBoxAsset.SelectedValue = Convert.ToInt32(reader["asset_id"]);
                            dateTimePickerCreatedAt.Value = Convert.ToDateTime(reader["created_at"]);
                            comboBoxOrderType.SelectedItem = reader["order_type"].ToString();
                            textBoxPrice.Text = reader["price"].ToString();
                            textBoxQuantity.Text = reader["quantity"].ToString();
                            comboBoxStatus.SelectedItem = reader["status"].ToString();
                            comboBoxTradeType.SelectedItem = reader["trade_type"].ToString();
                            comboBoxUser.SelectedValue = Convert.ToInt32(reader["user_id"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження ордера: {ex.Message}");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(textBoxPrice.Text, out decimal price) || !decimal.TryParse(textBoxQuantity.Text, out decimal quantity))
            {
                MessageBox.Show("Введіть коректні дані для ціни та кількості.");
                return;
            }

            int assetId = (int)comboBoxAsset.SelectedValue;
            string orderType = comboBoxOrderType.SelectedItem.ToString();
            string status = comboBoxStatus.SelectedItem.ToString();
            string tradeType = comboBoxTradeType.SelectedItem.ToString();
            int userId = (int)comboBoxUser.SelectedValue;
            DateTime createdAt = dateTimePickerCreatedAt.Value;

            string connectionString = "Server=localhost;Database=threetables;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (orderId.HasValue)
                    {
                        string updateQuery = @"
                            UPDATE Orders
                            SET asset_id = @AssetId, created_at = @CreatedAt, order_type = @OrderType, 
                                price = @Price, quantity = @Quantity, status = @Status, 
                                trade_type = @TradeType, user_id = @UserId
                            WHERE order_id = @OrderId";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@OrderId", orderId.Value);
                            command.Parameters.AddWithValue("@AssetId", assetId);
                            command.Parameters.AddWithValue("@CreatedAt", createdAt);
                            command.Parameters.AddWithValue("@OrderType", orderType);
                            command.Parameters.AddWithValue("@Price", price);
                            command.Parameters.AddWithValue("@Quantity", quantity);
                            command.Parameters.AddWithValue("@Status", status);
                            command.Parameters.AddWithValue("@TradeType", tradeType);
                            command.Parameters.AddWithValue("@UserId", userId);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Збережено успішно.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження ордера: {ex.Message}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!orderId.HasValue)
                return;

            var confirmResult = MessageBox.Show("Ви впевнені, що хочете видалити цей ордер?",
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
                            string deleteQuery = "DELETE FROM Orders WHERE order_id = @OrderId";
                            using (SqlCommand command = new SqlCommand(deleteQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@OrderId", orderId.Value);
                                command.ExecuteNonQuery();
                            }

                            string createTempTable = @"
                        CREATE TABLE Orders_New (
                            order_id INT IDENTITY(1,1) PRIMARY KEY,
                            asset_id INT NOT NULL,
                            created_at DATETIME NOT NULL,
                            order_type NVARCHAR(50) NOT NULL,
                            price REAL,
                            quantity REAL NOT NULL,
                            status NVARCHAR(50) NOT NULL,
                            trade_type NVARCHAR(50) NOT NULL,
                            user_id INT NOT NULL
                        );";
                            using (SqlCommand command = new SqlCommand(createTempTable, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                            }

                            string copyData = @"
                        INSERT INTO Orders_New (asset_id, created_at, order_type, price, quantity, status, trade_type, user_id)
                        SELECT asset_id, created_at, order_type, price, quantity, status, trade_type, user_id 
                        FROM Orders ORDER BY order_id;";
                            using (SqlCommand command = new SqlCommand(copyData, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                            }

                            string dropOldTable = "DROP TABLE Orders;";
                            using (SqlCommand command = new SqlCommand(dropOldTable, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                            }

                            string renameTable = "EXEC sp_rename 'Orders_New', 'Orders';";
                            using (SqlCommand command = new SqlCommand(renameTable, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Ордер успішно видалено.");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Помилка видалення ордера: {ex.Message}");
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
