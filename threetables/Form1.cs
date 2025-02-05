namespace threetables
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            user user = new user();
            user.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            assets assets = new assets();
            assets.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            orders orders = new orders();
            orders.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            portfolios portfolios=new portfolios();
            portfolios.Show();
        }
    }
}
