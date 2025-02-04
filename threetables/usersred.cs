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
    public partial class usersred : Form
    {
        private int? userId;
        public usersred(int? id = null)
        {
            InitializeComponent();
            userId = id;
            InitializeRoleComboBox();


            if (userId.HasValue)
            {
                LoadUser();
            }
            buttonDelete.Visible = userId.HasValue;

        }
        private void InitializeRoleComboBox()
        {
            comboBoxRole.Items.Clear();
            comboBoxRole.Items.Add("admin");
            comboBoxRole.Items.Add("user");
            comboBoxRole.SelectedIndex = 0;
        }


        private void LoadUser()
        {
            string connectionString = "Server=localhost;Database=threetables;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT email, name, password_hash AS password, role FROM Users WHERE user_id = @UserId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxEmail.Text = reader["email"].ToString();
                                textBoxName.Text = reader["name"].ToString();
                                textBoxPassword.Text = reader["password"].ToString();
                                comboBoxRole.SelectedItem = reader["role"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження користувача: {ex.Message}");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string name = textBoxName.Text;
            string password = textBoxPassword.Text;
            string role = comboBoxRole.SelectedItem.ToString();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Усі поля обов'язкові для заповнення.");
                return;
            }

            string connectionString = "Server=localhost;Database=threetables;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (userId.HasValue)
                    {
                        string updateQuery = @"
                            UPDATE Users
                            SET email = @Email, name = @Name, password_hash = @Password, role = @Role
                            WHERE user_id = @UserId";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue("@Name", name);
                            command.Parameters.AddWithValue("@Password", password);
                            command.Parameters.AddWithValue("@Role", role);
                            command.Parameters.AddWithValue("@UserId", userId);

                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string insertQuery = @"
                            INSERT INTO Users (email, name, password_hash, role, created_at)
                            VALUES (@Email, @Name, @Password, @Role, GETDATE())";

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue("@Name", name);
                            command.Parameters.AddWithValue("@Password", password);
                            command.Parameters.AddWithValue("@Role", role);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Зміни збережено успішно.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження користувача: {ex.Message}");
            }
        }



        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!userId.HasValue)
                return;

            var confirmResult = MessageBox.Show("Ви впевнені, що хочете видалити цього користувача?",
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
                            string deleteQuery = "DELETE FROM Users WHERE user_id = @userId";
                            using (SqlCommand command = new SqlCommand(deleteQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@userId", userId.Value);
                                command.ExecuteNonQuery();
                            }

                            string createTempTable = @"
                        CREATE TABLE Users_New (
                            user_id INT IDENTITY(1,1) PRIMARY KEY,
                            email NVARCHAR(255) NOT NULL,
                            name NVARCHAR(255) NOT NULL,
                            password_hash NVARCHAR(255) NOT NULL,
                            role NVARCHAR(50) NOT NULL,
                            created_at DATETIME NOT NULL
                        );";
                            using (SqlCommand command = new SqlCommand(createTempTable, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                            }
                            string copyData = @"
                                INSERT INTO Users_New (email, name, password_hash, role, created_at)
                                SELECT email, name, password_hash, role, created_at FROM Users ORDER BY user_id;";


                            using (SqlCommand command = new SqlCommand(copyData, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                            }

                            string dropOldTable = "DROP TABLE Users;";
                            using (SqlCommand command = new SqlCommand(dropOldTable, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                            }

                            string renameTable = "EXEC sp_rename 'Users_New', 'Users';";
                            using (SqlCommand command = new SqlCommand(renameTable, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Користувача успішно видалено.");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Помилка видалення користувача: {ex.Message}");
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
