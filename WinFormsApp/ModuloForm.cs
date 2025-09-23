using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
                    MessageBox.Show($"La especialidad con Id {numIDModulo.Value} no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                GridModulo.SelectedObject = modulo;
            }
            catch (Exception ex)
            {
                // Si ocurre cualquier error (por ejemplo 404 desde el API), limpiamos la property grid
                GridModulo.SelectedObject = null;
                GridModulo.Refresh();
                MessageBox.Show($"Error al buscar el módulo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonAgregarModulo_Click(object sender, EventArgs e)
        {
            try
            {
                ModuloPostForm modPostForm = new ModuloPostForm();
                modPostForm.ShowDialog();
                this.buttonListarModulos_Click(sender, e);
            }
            catch(Exception err)
            {
                MessageBox.Show($"Error al modificar especialidad: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModulosGetPostForm_Load(object sender, EventArgs e)
        {

        }

        private async void btnModificarModulo_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)numIDModulo.Value;
                ModuloDTO mod = await APIModulo.GetAsync(id);
                if (mod != null)
                {
                    ModuloPutDeleteForm moduloPutDeleteForm = new ModuloPutDeleteForm(id);
                    moduloPutDeleteForm.ShowDialog();

                }
                this.buttonListarModulos_Click(sender, e);
                this.buttonBuscarModulo_Click(sender, e);
            }catch( ArgumentException err)
            {
                MessageBox.Show($"Error al modificar especialidad: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}