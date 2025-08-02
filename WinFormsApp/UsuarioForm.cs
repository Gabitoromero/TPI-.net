using API.Entities;
using Domain.Model;
using DTOs;

namespace WinFormsApp
{
    public partial class UsuarioForm : Form
    {
        public UsuarioForm()
        {
            InitializeComponent();
        }

        private async void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuarios = await APIUsuario.GetAllAsync();
                gridUsuarios.DataSource = usuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnMostrarUno_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)numUpDownIdUser.Value;
                FullUsuarioDTO user = await APIUsuario.GetAsync(id);

                if (user != null)
                {
                    gridUnicoUsuario.SelectedObject = user;
                    //propertyGridUsuario.Enabled = false;

                }
                else
                {
                    MessageBox.Show($"User not found with id: {id}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error retreiving user: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btnAddUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                 PostUsuarioDTO newUser = new PostUsuarioDTO
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Clave = txtClave.Text,
                    Email = txtEmail.Text,
                    NombreUsuario = txtNombreUsuario.Text
                };
                if (string.IsNullOrWhiteSpace(newUser.Nombre) || string.IsNullOrWhiteSpace(newUser.Apellido) ||
                    string.IsNullOrWhiteSpace(newUser.Clave) || string.IsNullOrWhiteSpace(newUser.Email) ||
                    string.IsNullOrWhiteSpace(newUser.NombreUsuario))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                PostUsuarioDTO addedUser = await APIUsuario.AddAsync(newUser);
                gridNuevoUsuario.SelectedObject = addedUser;
                //propertyGridUsuario.Enabled = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
