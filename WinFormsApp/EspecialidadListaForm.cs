using DTOs;
using API.Clients;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class EspecialidadListaForm : Form
    {
        public EspecialidadListaForm()
        {
            InitializeComponent();
        }

        public async void EspecialidadListaForm_Load(object sender, EventArgs e)
        {
            await LoadEspecialidades();
        }

        private async Task LoadEspecialidades()
        {
            try
            {
                List<EspecialidadDTO> list = await APIEspecialidad.GetAllAsync();
                dataGridViewEspecialidades.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar especialidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new EspecialidadDetalleForm())
            {
                form.ShowDialog();
            }
            this.Show();
            _ = LoadEspecialidades();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewEspecialidades.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una especialidad para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = (int)dataGridViewEspecialidades.CurrentRow.Cells["Id"].Value;
                EspecialidadDTO dto = await APIEspecialidad.GetAsync(id);
                
                this.Hide();
                using (var form = new EspecialidadDetalleForm(dto))
                {
                    form.ShowDialog();
                }
                this.Show();
                await LoadEspecialidades();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show(); // Asegurar que se muestre incluso si hay error
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewEspecialidades.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una especialidad para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = (int)dataGridViewEspecialidades.CurrentRow.Cells["Id"].Value;
                string descripcionEspecialidad = dataGridViewEspecialidades.CurrentRow.Cells["Descripcion"].Value?.ToString() ?? "esta especialidad";

                // Mostrar mensaje de confirmación
                DialogResult confirmResult = MessageBox.Show(
                    $"¿Está seguro que desea eliminar la especialidad '{descripcionEspecialidad}'?\n\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // Solo eliminar si el usuario confirma
                if (confirmResult == DialogResult.Yes)
                {
                    await APIEspecialidad.DeleteAsync(id);
                    MessageBox.Show("Especialidad eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadEspecialidades();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dataGridViewEspecialidades_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                int id = (int)dataGridViewEspecialidades.Rows[e.RowIndex].Cells["Id"].Value;
                var dto = await APIEspecialidad.GetAsync(id);
                
                this.Hide();
                using (var form = new EspecialidadDetalleForm(dto))
                {
                    form.ShowDialog();
                }
                this.Show();
                await LoadEspecialidades();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show(); // Asegurar que se muestre incluso si hay error
            }
        }
    }
}
