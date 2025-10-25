using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;

namespace WinFormsApp
{
    public partial class MateriaListaForm : Form
    {
        public MateriaListaForm()
        {
            InitializeComponent();
            dataGridViewMaterias.SelectionChanged += dataGridViewMaterias_SelectionChanged;
        }
        private void dataGridViewMaterias_SelectionChanged(object? sender, EventArgs e)
        {
            bool haySeleccion = dataGridViewMaterias.SelectedRows.Count > 0 && dataGridViewMaterias.CurrentRow != null;
            btnModificar.Enabled = haySeleccion;
            btnEliminar.Enabled = haySeleccion;
        }

        public async void MateriaListaForm_Load(object sender, EventArgs e)
        {
            await LoadMaterias();
        }

        private async Task LoadMaterias()
        {
            try
            {
                List<MateriaDTO> materias = await APIMateria.GetAllAsync();
                List<PlanDTO> planes = new List<PlanDTO>();

                try
                {
                    planes = await APIPlan.GetAllAsync();
                }
                catch
                {
                    planes = new List<PlanDTO>();
                }

                var view = materias.Select(m => new
                    {
                        Id_materia = m.Id_materia,
                        Desc_materia = m.Desc_materia,
                        Hs_semanales = m.Hs_semanales,
                        Hs_totales = m.Hs_totales,
                        Plan = planes.FirstOrDefault(p => p.IdPlan == m.Id_plan)?.Descripcion
                    })
                    .ToList();

                dataGridViewMaterias.DataSource = view;
                dataGridViewMaterias.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new MateriaDetalleForm())
            {
                form.ShowDialog();
            }
            this.Show();
            _ = LoadMaterias();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewMaterias.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una materia para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int id = (int)dataGridViewMaterias.CurrentRow.Cells["Id_materia"].Value;
                MateriaDTO dto = await APIMateria.GetAsync(id);
                
                this.Hide();
                using (var form = new MateriaDetalleForm(dto))
                {
                    form.ShowDialog();
                }
                this.Show();
                await LoadMaterias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewMaterias.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una materia para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = (int)dataGridViewMaterias.CurrentRow.Cells["Id_materia"].Value;
                string descripcionMateria = dataGridViewMaterias.CurrentRow.Cells["Desc_materia"].Value?.ToString() ?? "esta materia";

                // Mostrar mensaje de confirmación
                DialogResult confirmResult = MessageBox.Show(
                    $"¿Está seguro que desea eliminar la materia '{descripcionMateria}'?\n\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // Solo eliminar si el usuario confirma
                if (confirmResult == DialogResult.Yes)
                {
                    await APIMateria.DeleteAsync(id);
                    MessageBox.Show("Materia eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadMaterias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
