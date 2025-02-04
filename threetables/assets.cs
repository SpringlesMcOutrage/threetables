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
    public partial class assets : Form
    {
        public assets()
        {
            InitializeComponent();
            LoadAssets();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();


        }
        private void LoadAssets()
        {
            string connectionString = "Server=localhost;Database=threetables;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT asset_id, name, symbol, current_price, type FROM Assets";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridViewAssets.DataSource = dt;

                        dataGridViewAssets.Columns["name"].HeaderText = "Назва активу";
                        dataGridViewAssets.Columns["symbol"].HeaderText = "Символ";
                        dataGridViewAssets.Columns["current_price"].HeaderText = "Поточна ціна";
                        dataGridViewAssets.Columns["type"].HeaderText = "Тип активу";

                        dataGridViewAssets.Columns["asset_id"].Visible = false;
                        dataGridViewAssets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження активів: {ex.Message}");
            }
        }

        private void buttonAddAsset_Click(object sender, EventArgs e)
        {
            assetsred form = new assetsred(null);
            form.ShowDialog();
        }

        private void dataGridViewAssets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int assetId = Convert.ToInt32(dataGridViewAssets.Rows[e.RowIndex].Cells["asset_id"].Value);

                assetsred form = new assetsred(assetId);
                form.ShowDialog();
                LoadAssets();
            }
        }

    }
}

