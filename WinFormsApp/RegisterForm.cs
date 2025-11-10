using API.Clients;
using DTOs;
using System.Data;

namespace WinFormsApp
{
    public partial class RegisterForm : Form
    {
        private readonly bool isAutoRegistro;

        public RegisterForm(bool autoRegistro = true)
        {
            InitializeComponent();
            isAutoRegistro = autoRegistro;
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

                if(isAutoRegistro) 
                {
                    string[] tiposUsuario = { "alumno", "profesor" };
                    comboBoxTipoUsuario.DataSource = tiposUsuario;
                    comboBoxTipoUsuario.SelectedIndex = -1;
                    comboBoxTipoUsuario.Enabled = true;
                }
                else
                {
                    string[] tiposUsuario = { "profesor" };
                    comboBoxTipoUsuario.DataSource = tiposUsuario;
                    comboBoxTipoUsuario.SelectedIndex = 0;
                    comboBoxTipoUsuario.Enabled = false;
                }
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
                string rawTelefono = maskedTextBoxTelefono.Text ?? string.Empty;
                string digitsTelefono = new string(rawTelefono.Where(char.IsDigit).ToArray());
                if (digitsTelefono.Length != 10)
                {
                    MessageBox.Show("El teléfono debe contener exactamente 10 dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string contra = textBoxClave.Text;
                if(contra.Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener como minimo 6 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                PostUsuarioDTO response = await APIUsuario.AddAsync(dto);

                MessageBox.Show("Usuario registrado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (isAutoRegistro)
                {
                    bool loginSuccess = await APIUsuario.LoginAsync(new LoginRequest { NombreUsuario = response.NombreUsuario, Clave = response.Clave });

                    if (loginSuccess)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al loguear automáticamente, intente de nuevo", "Error de servidor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
