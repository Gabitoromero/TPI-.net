using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Entities;
using DTOs;

namespace WinFormsApp
{
    public partial class PlanesDeletePutForm : Form
    {
        public PlanesDeletePutForm()
        {
            InitializeComponent();
        }

        private async void buttonListarPlanes_Click(object sender, EventArgs e)
        {
            try
            {
                List<PlanDTO> planes = await APIPlan.GetAllAsync();
                GridPlanes.DataSource = planes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar los planes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void buttonEliminarPlan_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridPlanes.SelectedRows.Count > 0)
                {
                    int selectedRowIndex = GridPlanes.SelectedRows[0].Index;
                    PlanDTO selectedPlan = (PlanDTO)GridPlanes.Rows[selectedRowIndex].DataBoundItem;
                    DialogResult result = MessageBox.Show($"¿Estás seguro de eliminar el plan {selectedPlan.Descripcion}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        await APIPlan.DeleteAsync(selectedPlan.IdPlan);
                        MessageBox.Show("Plan eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        buttonListarPlanes_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un plan para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonModificarPlan_Click(object sender, EventArgs e)
        {
            try
            {
                if (textDesc.Text != "" && (int)numIDEsp.Value != 0)
                {
                    PlanDTO plan = new PlanDTO
                    {
                        Descripcion = textDesc.Text,
                        IdEspecialidad = (int)numIDEsp.Value,
                        IdPlan = int.Parse(textIDPlan.Text)
                    };

                    await APIPlan.UpdateAsync(plan);
                    buttonListarPlanes_Click(sender, e);
                    MessageBox.Show("Plan modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridPlanes_SelectionChanged(object sender, EventArgs e)
        {
            if (GridPlanes.CurrentRow != null)
            {
                PlanDTO plan = (PlanDTO)GridPlanes.CurrentRow.DataBoundItem;
                textIDPlan.Text = plan.IdPlan.ToString();
                textDesc.Text = plan.Descripcion;
                numIDEsp.Value = plan.IdEspecialidad;

            }
        }

        private void PlanesDeletePutForm_Load(object sender, EventArgs e)
        {

        }
    }
}