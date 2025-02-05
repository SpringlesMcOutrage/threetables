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
    public partial class portfolios : Form
    {
        public portfolios()
        {
            InitializeComponent();
            LoadPortfolios();
        }

        private void LoadPortfolios()
        {
            string connectionString = "Server=localhost;Database=threetables;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT p.portfolio_id, u.name AS user_name, a.name AS asset_name, 
                               p.average_price, p.quantity
                        FROM Portfolios p
                        JOIN Users u ON p.user_id = u.user_id
                        JOIN Assets a ON p.asset_id = a.asset_id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridViewPortfolios.DataSource = dt;

                        dataGridViewPortfolios.Columns["portfolio_id"].Visible = false;
                        dataGridViewPortfolios.Columns["user_name"].HeaderText = "Користувач";
                        dataGridViewPortfolios.Columns["asset_name"].HeaderText = "Актив";
                        dataGridViewPortfolios.Columns["average_price"].HeaderText = "Середня ціна";
                        dataGridViewPortfolios.Columns["quantity"].HeaderText = "Кількість";

                        dataGridViewPortfolios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження портфелів: {ex.Message}");
            }
        }

        private void buttonAddPortfolio_Click(object sender, EventArgs e)
        {
            portfoliosred form = new portfoliosred(null);
            form.ShowDialog();
            LoadPortfolios();
        }

        private void dataGridViewPortfolios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int portfolioId = Convert.ToInt32(dataGridViewPortfolios.Rows[e.RowIndex].Cells["portfolio_id"].Value);

                portfoliosred form = new portfoliosred(portfolioId);
                form.ShowDialog();
                LoadPortfolios();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
