using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private async void buttonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                PostUsuarioDTO dto = new PostUsuarioDTO
                {
                    Nombre = textBoxNombre.Text,
                    Apellido = textBoxApellido.Text,
                    Email = textBoxEmail.Text,
                    Clave = textBoxClave.Text,
                    NombreUsuario = textBoxUsername.Text
                };

                dto = await APIUsuario.AddAsync(dto);

                MessageBox.Show("Usuario registrado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                bool loginSuccess = await APIUsuario.LoginAsync(new LoginRequest { NombreUsuario = dto.NombreUsuario, Clave = dto.Clave });

                if (loginSuccess)
                {
                    var menuForm = new MenuForm();
                    menuForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error al loguear automáticamente, intente de nuevo", "Error de servidor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar usuario " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
