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
    }
}
