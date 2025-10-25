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
using API.Clients;


namespace WinFormsApp
{
    public partial class PlanListaForm : Form
    {
        public PlanListaForm()
        {
            InitializeComponent();
            dataGridViewPlanes.SelectionChanged += DataGridViewPlanes_SelectionChanged;
        }
        private void DataGridViewPlanes_SelectionChanged(object? sender, EventArgs e)
        {
            bool haySeleccion = dataGridViewPlanes.SelectedRows.Count > 0 && dataGridViewPlanes.CurrentRow != null;
            btnModificar.Enabled = haySeleccion;
            btnEliminar.Enabled = haySeleccion;
        }
        public async void PlanListaForm_Load(object sender, EventArgs e)
        {
            await LoadPlanes();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private async Task LoadPlanes()
        {
            try
            {
                List<EspecialidadDTO> especialidades = await APIEspecialidad.GetAllAsync();
                if (especialidades.Count == 0)
                {
                    MessageBox.Show("No se pudieron cargar las especialidades.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                List<PlanDTO> planes = await APIPlan.GetAllAsync();
                if (planes.Count == 0)
                {
                    MessageBox.Show("No se pudieron cargar los planes.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Build dictionary for fast lookup (handle nulls)
                var espDict = (especialidades ?? new List<EspecialidadDTO>())
                              .ToDictionary(x => x.Id, x => x.Descripcion);

                // Project to a view model that shows Especialidad description instead of Id
                var view = (planes ?? new List<PlanDTO>()).Select(p => new
                {
                    IdPlan = p.IdPlan,
                    Descripcion = p.Descripcion?.Trim(),
                    Especialidad = espDict.TryGetValue(p.IdEspecialidad, out var desc) ? desc : $"Id {p.IdEspecialidad}"
                }).ToList();

                dataGridViewPlanes.DataSource = view;
                dataGridViewPlanes.ClearSelection();
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPlanes.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un plan para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                int idPlan = (int)dataGridViewPlanes.CurrentRow.Cells["IdPlan"].Value;
                string descripcionPlan = dataGridViewPlanes.CurrentRow.Cells["Descripcion"].Value?.ToString() ?? "este plan";
                string especialidad = dataGridViewPlanes.CurrentRow.Cells["Especialidad"].Value?.ToString() ?? "desconocida";

                // Mostrar mensaje de confirmación
                DialogResult confirmResult = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el plan '{descripcionPlan}'?\n\nEspecialidad: {especialidad}\n\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // Solo eliminar si el usuario confirma
                if (confirmResult == DialogResult.Yes)
                {
                    await APIPlan.DeleteAsync(idPlan);
                    MessageBox.Show("Plan eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadPlanes();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPlanes.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un plan para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                int idPlan = (int)dataGridViewPlanes.CurrentRow.Cells["IdPlan"].Value;
                PlanDTO plan = await APIPlan.GetAsync(idPlan);
                
                if (plan == null)
                {
                    MessageBox.Show("No se pudo obtener el plan seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                this.Hide();
                using (var planform = new PlanDetalleForm(plan))
                {
                    planform.ShowDialog();
                }
                this.Show();
                await LoadPlanes();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var planform = new PlanDetalleForm())
            {
                planform.ShowDialog();
            }
            this.Show();
            _ = LoadPlanes();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string descBuscada = textBoxBuscador.Text?.Trim();
                if (string.IsNullOrEmpty(descBuscada))
                {
                    MessageBox.Show("Ingrese la descripción a buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dataGridViewPlanes.Rows.Count == 0)
                {
                    MessageBox.Show("No hay planes para buscar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dataGridViewPlanes.ClearSelection();

                bool encontrado = false;
                foreach (DataGridViewRow row in dataGridViewPlanes.Rows)
                {
                    if (row.IsNewRow) continue;
                    string? descFila = null;
                    if (dataGridViewPlanes.Columns.Contains("Descripcion"))
                    {
                        descFila = row.Cells["Descripcion"].Value?.ToString();
                    }
                    else
                    {     
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            var val = row.Cells[i].Value?.ToString();
                            if (!string.IsNullOrEmpty(val) && val.Equals(descBuscada, StringComparison.OrdinalIgnoreCase))
                            {
                                descFila = val;
                                break;
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(descFila) && descFila.IndexOf(descBuscada, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        row.Selected = true;
                        dataGridViewPlanes.CurrentCell = row.Cells[0];
                        dataGridViewPlanes.FirstDisplayedScrollingRowIndex = row.Index;
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    MessageBox.Show("No se encontró ningún plan con esa descripción.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
