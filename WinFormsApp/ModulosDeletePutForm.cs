using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DTOs;
using API.Entities;

namespace WinFormsApp
{
    public partial class ModulosDeletePutForm : Form
    {
        public ModulosDeletePutForm()
        {
            InitializeComponent();
        }

        private async void buttonListarModulos_Click(object sender, EventArgs e)
        {
            try
            {
                List<ModuloDTO> modulos = await APIModulo.GetAllAsync();
                GridModulos.DataSource = modulos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar los módulos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonEliminarModulo_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridModulos.SelectedRows.Count > 0)
                {
                    int selectedRowIndex = GridModulos.SelectedRows[0].Index;
                    ModuloDTO selectedModulo = (ModuloDTO)GridModulos.Rows[selectedRowIndex].DataBoundItem;
                    DialogResult result = MessageBox.Show($"¿Estás seguro de eliminar el módulo \"{selectedModulo.Descripcion}\"?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        await APIModulo.DeleteAsync(selectedModulo.Id);
                        MessageBox.Show("Módulo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        buttonListarModulos_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un módulo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el módulo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonModificarModulo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textDescripcion.Text))
                {
                    ModuloDTO modulo = new ModuloDTO
                    {
                        Id = int.Parse(textIDModulo.Text),
                        Descripcion = textDescripcion.Text
                    };

                    await APIModulo.UpdateAsync(modulo);
                    buttonListarModulos_Click(sender, e);
                    MessageBox.Show("Módulo modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Por favor, completá la descripción.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el módulo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridModulos_SelectionChanged(object sender, EventArgs e)
        {
            if (GridModulos.CurrentRow != null)
            {
                ModuloDTO modulo = (ModuloDTO)GridModulos.CurrentRow.DataBoundItem;
                textIDModulo.Text = modulo.Id.ToString();
                textDescripcion.Text = modulo.Descripcion;
            }
        }
    }
}
