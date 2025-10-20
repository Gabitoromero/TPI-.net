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
            this.Load += RegisterForm_Load;
        }

        private async void RegisterForm_Load(object? sender, EventArgs e)
        {
            try
            {
                var plans = await APIPlan.GetAllAsync();
                comboBoxPlan.DataSource = plans;
                comboBoxPlan.DisplayMember = "Descripcion";
                comboBoxPlan.ValueMember = "IdPlan";
                comboBoxPlan.SelectedIndex = -1;

                string[] tiposUsuario = { "alumno", "profesor" };
                comboBoxTipoUsuario.DataSource = tiposUsuario;
                comboBoxTipoUsuario.SelectedIndex = -1;
            }
            catch
            {
                comboBoxPlan.DataSource = null;
            }
        }

        private async void buttonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar telefono: debe contener 10 dígitos
                string rawTelefono = maskedTextBoxTelefono.Text ?? string.Empty;
                string digitsTelefono = new string(rawTelefono.Where(char.IsDigit).ToArray());
                if (digitsTelefono.Length != 10)
                {
                    MessageBox.Show("El teléfono debe contener exactamente 10 dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FullUsuarioDTO dto = new FullUsuarioDTO
                {
                    Id = 0,
                    Legajo = 0,
                    Habilitado = true,
                    Nombre = textBoxNombre.Text,
                    Apellido = textBoxApellido.Text,
                    Email = textBoxEmail.Text,
                    Clave = textBoxClave.Text,
                    NombreUsuario = textBoxUsername.Text,
                    Direccion = textBoxDireccion.Text,
                    Telefono = digitsTelefono,
                    FechaNacimiento = dateTimePickerFechaNacimiento.Value,
                    IdPlan = comboBoxPlan.SelectedValue != null ? (int)comboBoxPlan.SelectedValue : 0,
                    FechaAlta = DateTime.Now,
                    Tipo = comboBoxTipoUsuario.SelectedItem != null ? comboBoxTipoUsuario.SelectedItem.ToString()! : string.Empty
                };

                // Llamada al API que acepta FullUsuarioDTO y devuelve PostUsuarioDTO (ID and credentials)
                PostUsuarioDTO response = await APIUsuario.AddAsync(dto);

                MessageBox.Show("Usuario registrado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                bool loginSuccess = await APIUsuario.LoginAsync(new LoginRequest { NombreUsuario = response.NombreUsuario, Clave = response.Clave });

                if (loginSuccess)
                {
                    // After successful automatic login, fetch the created user's id by username
                    var showUser = await APIUsuario.GetByUsernameAsync(response.NombreUsuario);
                    if (showUser == null)
                    {
                        MessageBox.Show("No se pudo obtener la información del usuario creado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Persist current user id
                    APIClientBase.CurrentUserId = showUser.Id;

                    // tipo comes from the login response stored in APIClientBase
                    string? tipo = APIClientBase.CurrentUserTipo;

                    var menuForm = new MenuForm(APIClientBase.CurrentUserId, tipo);
                    this.Hide();
                    menuForm.FormClosed += (s, args) =>
                    {
                        APIUsuario.Logout();
                        var login = new LoginForm();
                        login.Show();
                        this.Close();
                    };
                    menuForm.Show();
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
