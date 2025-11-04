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

namespace WinFormsApp
{
    public partial class MenuAlumno : Form
    {

        public MenuAlumno()
        {
            InitializeComponent();
        }

        private async void btnVerInscripciones_Click_2(object? sender, EventArgs e)
        {
            try
            {
                string username = APIClientBase.LoginResponse.Username;
                ShowUsuarioDTO current = await APIUsuario.GetByUsernameAsync(username);

                Hide();
                using (var detalle = new InscripcionDetalle())
                {
                    detalle.ShowDialog();
                }
                Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnNuevaInscripcion_Click(object? sender, EventArgs e)
        {
            try
            {
                string username = APIClientBase.LoginResponse.Username;
                ShowUsuarioDTO current = await APIUsuario.GetByUsernameAsync(username);

                if (!current.Habilitado ?? false)
                {
                    MessageBox.Show("Su cuenta no está habilitada. No puede realizar nuevas inscripciones.", "Cuenta no habilitada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Hide();
                    using (var nuevaInscripcion = new InscripcionNueva())
                    {
                        DialogResult result = nuevaInscripcion.ShowDialog();
                    }
                    Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuAlumno_Load(object sender, EventArgs e)
        {
            // Puedes agregar lógica de inicialización si es necesario
        }
    }
}
