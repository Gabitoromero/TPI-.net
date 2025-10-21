using API.Clients;
using DTOs;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class ComisionListaForm : Form
    {
        public ComisionListaForm()
        {
            InitializeComponent();
        }

        public async void ComisionListaForm_Load(object sender, EventArgs e)
        {
            await LoadComisiones();
        }

        private async Task LoadComisiones()
        {
            try
            {
                List<ComisionDTO> comisiones = await APIComision.GetAllAsync();
                List<PlanDTO> planes = new List<PlanDTO>();

                try
                {
                    planes = await APIPlan.GetAllAsync();
                }
                catch
                {
                    //planes = new List<PlanDTO>();
                    throw new Exception("No se pudieron cargar los planes. Verifique la conexión con el servidor.");
                }

                var view = comisiones.Select(c => new
                    {
                        Id_comision = c.Id_comision,
                        Desc_comision = c.Desc_comision,
                        Anio_especialidad = c.Anio_especialidad,
                        Plan = planes.FirstOrDefault(p => p.IdPlan == c.Id_plan)?.Descripcion
                    })
                    .ToList();

                dataGridViewComisiones.DataSource = view;
                dataGridViewComisiones.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar comisiones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ComisionDetalleForm form = new ComisionDetalleForm();
            form.ShowDialog();
            _ = LoadComisiones();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewComisiones.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una comisión para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int id = (int)dataGridViewComisiones.CurrentRow.Cells["Id_comision"].Value;
                ComisionDTO dto = await APIComision.GetAsync(id);
                ComisionDetalleForm form = new ComisionDetalleForm(dto);
                form.ShowDialog();
                await LoadComisiones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar comisión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewComisiones.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una comisión para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int id = (int)dataGridViewComisiones.CurrentRow.Cells["Id_comision"].Value;

                // Mostrar mensaje de confirmación
                DialogResult confirmResult = MessageBox.Show(
                    $"¿Está seguro que desea eliminar la comisión'{id}'?\n\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // Solo eliminar si el usuario confirma
                if (confirmResult == DialogResult.Yes)
                {
                    await APIComision.DeleteAsync(id);
                    MessageBox.Show("Comisión eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadComisiones();
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar comisión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
