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
    public partial class EspecialidadPostForm : Form
    {
        public EspecialidadPostForm()
        {
            InitializeComponent();
        }
        private async void EspecialidadPostForm_Load(object sender, EventArgs e)
        {
            // Cualquier inicialización adicional si es necesaria
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                NewEspecialidadDTO nuevaEsp = new NewEspecialidadDTO();
                nuevaEsp.Descripcion = textBoxDESC.Text;
                if (string.IsNullOrWhiteSpace(nuevaEsp.Descripcion))
                {
                    MessageBox.Show("La descripción no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                EspecialidadDTO espAdded = await APIEspecialidad.AddAsync(nuevaEsp);
                MessageBox.Show("Especialidad creada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch(ArgumentException err )
            {
                MessageBox.Show($"Error al agregar especialidad: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EspecialidadPostForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
