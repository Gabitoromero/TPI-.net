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
            dataGridViewComisiones.SelectionChanged += DataGridViewComisiones_SelectionChanged;
        }

        public async void ComisionListaForm_Load(object sender, EventArgs e)
        {
            await LoadComisiones();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void DataGridViewComisiones_SelectionChanged(object? sender, EventArgs e)
        {

            bool haySeleccion = dataGridViewComisiones.SelectedRows.Count > 0 && dataGridViewComisiones.CurrentRow != null;
            btnModificar.Enabled = haySeleccion;
            btnEliminar.Enabled = haySeleccion;
        }

        private async Task LoadComisiones()
        {
            try
            {
                List<PlanDTO> planes = await APIPlan.GetAllAsync();
                if (planes.Count == 0)
                {
                    MessageBox.Show("No se pudieron cargar los planes.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                List<ComisionDTO> comisiones = await APIComision.GetAllAsync();
                if (comisiones.Count == 0)
                {
                    MessageBox.Show("No se pudieron cargar las comisiones.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false; // Deshabilitar después de limpiar selección
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new ComisionDetalleForm())
            {
                form.ShowDialog();
            }
            this.Show();
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
                if (dto == null)
                {
                    MessageBox.Show("No se pudo obtener la comisión seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.Hide();
                using (var form = new ComisionDetalleForm(dto))
                {
                    form.ShowDialog();
                }
                this.Show();
                await LoadComisiones();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
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
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
