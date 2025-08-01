using API.Entities;
using System.Threading.Tasks;

namespace WinFormsLogIn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                // Simulate fetching user data
                var users = await APIUsuario.GetAllAsync();
                // Bind the list to the DataGridView
                gridUsuarios.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
