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
            EspecialidadDetalleForm form = new EspecialidadDetalleForm();
            form.ShowDialog();
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
                EspecialidadDetalleForm form = new EspecialidadDetalleForm(dto);
                form.ShowDialog();
                await LoadEspecialidades();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                await APIEspecialidad.DeleteAsync(id);
                MessageBox.Show("Especialidad eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadEspecialidades();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string filtro = textBoxBuscador.Text?.Trim();
                if (string.IsNullOrEmpty(filtro))
                {
                    _ = LoadEspecialidades();
                    return;
                }

                var all = APIEspecialidad.GetAllAsync().Result;
                var filtered = all.FindAll(e => e.Descripcion != null && e.Descripcion.Contains(filtro, StringComparison.OrdinalIgnoreCase));
                dataGridViewEspecialidades.DataSource = filtered;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar especialidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dataGridViewEspecialidades_CellDoubleClick(object? sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                int id = (int)dataGridViewEspecialidades.Rows[e.RowIndex].Cells["Id"].Value;
                var dto = await APIEspecialidad.GetAsync(id);
                var form = new EspecialidadDetalleForm(dto);
                form.ShowDialog();
                await LoadEspecialidades();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
