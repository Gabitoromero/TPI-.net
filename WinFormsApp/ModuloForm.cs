using System;
using System.Collections.Generic;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace WinFormsApp
{
    public partial class ModuloForm : Form
    {
        public ModuloForm()
        {
            InitializeComponent();
        }

        private async void buttonListarModulos_Click(object sender, EventArgs e)
        {
            try
            {
                var modulos = await APIModulo.GetAllAsync();
                GridModulos.DataSource = modulos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar los módulos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonBuscarModulo_Click(object sender, EventArgs e)
        {
            try
            {
                ModuloDTO modulo = await APIModulo.GetAsync((int)numIDModulo.Value);

                if (modulo == null)
                {
                    GridModulo.SelectedObject = null;
                    GridModulo.Refresh();
                    throw new Exception("No se encontró el módulo con el ID especificado.");
                }

                GridModulo.SelectedObject = modulo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el módulo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonAgregarModulo_Click(object sender, EventArgs e)
        {
            ModuloPostForm modPostForm = new ModuloPostForm();
            modPostForm.ShowDialog();
        }

        private void ModulosGetPostForm_Load(object sender, EventArgs e)
        {

        }

        private void btnModificarModulo_Click(object sender, EventArgs e)
        {
            int id = (int)numIDModulo.Value;
            ModuloPutDeleteForm moduloPutDeleteForm = new ModuloPutDeleteForm(id);
            moduloPutDeleteForm.ShowDialog();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}