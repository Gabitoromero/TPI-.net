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
    public partial class ModuloPostForm : Form
    {
        public ModuloPostForm()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ModuloDTO nuevoMod = new ModuloDTO();
                nuevoMod.Descripcion = textBoxDescripcion.Text;
                nuevoMod.Id = 0;

                if (string.IsNullOrWhiteSpace(nuevoMod.Descripcion))
                {
                    MessageBox.Show("La descripción no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ModuloDTO moduloAdded = await APIModulo.AddAsync(nuevoMod);
                MessageBox.Show("Especialidad creada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
