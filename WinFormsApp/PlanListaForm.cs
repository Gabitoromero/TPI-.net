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
        }
        public async void PlanListaForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<PlanDTO> planes = await APIPlan.GetAllAsync();
                List<EspecialidadDTO> especialidades = await APIEspecialidad.GetAllAsync();

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar los planes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPlanes.CurrentRow != null)
            {
                int idPlan = (int)dataGridViewPlanes.CurrentRow.Cells["IdPlan"].Value;
                try
                {
                    await APIPlan.DeleteAsync(idPlan);
                    MessageBox.Show("Plan eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PlanListaForm_Load(sender, e); // Refresh the list
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un plan para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                PlanDetalleForm planform = new PlanDetalleForm(plan);
                planform.ShowDialog();
                PlanListaForm_Load(sender, e); // Refresh the list after modification

            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PlanDetalleForm planform = new PlanDetalleForm();
            planform.ShowDialog();
            PlanListaForm_Load(sender, e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //PlanDTO planDesc = await APIPlan.GetAsync();
        }
    }
}
