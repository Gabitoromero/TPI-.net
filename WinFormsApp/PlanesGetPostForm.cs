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
using DTOs;

namespace WinFormsApp
{
    public partial class PlanesGetPostForm : Form
    {
        public PlanesGetPostForm()
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

        private async void buttonBuscarPlan_Click(object sender, EventArgs e)
        {
            try
            {
                PlanDTO plan = await APIPlan.GetAsync((int)numIDPlan.Value);

                if (plan == null)
                {
                    throw new Exception("No se encontró el plan con el ID especificado.");
                }

                GridPlan.SelectedObject = plan;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void buttonAgregarPlan_Click(object sender, EventArgs e)
        {
            try
            {
                PlanDTO nuevoPlan = new PlanDTO();

                if (string.IsNullOrWhiteSpace(textDesc.Text))
                {
                    MessageBox.Show("La descripción del plan no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                nuevoPlan.Descripcion = textDesc.Text;
                nuevoPlan.IdEspecialidad = (int)numIDEsp.Value;

                PlanDTO planAñadido = await APIPlan.AddAsync(nuevoPlan);
                GridNuevoPlan.SelectedObject = planAñadido;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PlanesGetPostForm_Load(object sender, EventArgs e)
        {

        }
    }
}
