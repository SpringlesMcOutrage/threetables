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
    public partial class orders : Form
    {
        public orders()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            string connectionString = "Server=localhost;Database=threetables;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT o.order_id, a.name AS asset_name, u.name AS user_name, 
                       o.created_at, o.order_type, o.price, o.quantity, 
                       o.status, o.trade_type
                FROM Orders o
                JOIN Assets a ON o.asset_id = a.asset_id
                JOIN Users u ON o.user_id = u.user_id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridViewOrders.DataSource = dt;

                        dataGridViewOrders.Columns["order_id"].Visible = false;
                        dataGridViewOrders.Columns["asset_name"].HeaderText = "Актив";
                        dataGridViewOrders.Columns["user_name"].HeaderText = "Користувач";
                        dataGridViewOrders.Columns["created_at"].HeaderText = "Дата створення";
                        dataGridViewOrders.Columns["order_type"].HeaderText = "Тип ордеру";
                        dataGridViewOrders.Columns["price"].HeaderText = "Ціна";
                        dataGridViewOrders.Columns["quantity"].HeaderText = "Кількість";
                        dataGridViewOrders.Columns["status"].HeaderText = "Статус";
                        dataGridViewOrders.Columns["trade_type"].HeaderText = "Тип угоди";

                        dataGridViewOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження ордерів: {ex.Message}");
            }
        }


        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            ordersred form = new ordersred(null);
            form.ShowDialog();
            LoadOrders();
        }

        private void dataGridViewOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int orderId = Convert.ToInt32(dataGridViewOrders.Rows[e.RowIndex].Cells["order_id"].Value);

                ordersred form = new ordersred(orderId);
                form.ShowDialog();
                LoadOrders();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
