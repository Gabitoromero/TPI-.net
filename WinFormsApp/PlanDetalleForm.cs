using DTOs;
using API.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{

    public partial class PlanDetalleForm : Form
    {
        private PlanDTO plan;
        public PlanDetalleForm()
        {
            InitializeComponent();
        }
        public PlanDetalleForm(PlanDTO plan) : this()
        {
            this.plan = plan;
        }
        public async void PlanDetalleForm_Load_1(object sender, EventArgs e)
        {
            await LoadEspecialidades();
            if (plan != null)
            {
                txtBoxDescripcion.Text = plan.Descripcion;
            }

        }
        private async Task LoadEspecialidades()
        {
            var especialidades = await APIEspecialidad.GetAllAsync();
            comboBoxEspecialidades.DataSource = especialidades;
            comboBoxEspecialidades.DisplayMember = "Descripcion";
            comboBoxEspecialidades.ValueMember = "Id";
            if (plan != null)
            {
                if (especialidades.Any(e => e.Id == plan.IdEspecialidad))
                {
                    comboBoxEspecialidades.SelectedValue = plan.IdEspecialidad;
                }
                else
                {
                    comboBoxEspecialidades.SelectedIndex = -1; // No selection by default
                }
            }
        }

        public void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }

        private async void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (plan != null) //UPDATE
                {

                    int idEspecialidad = (int)comboBoxEspecialidades.SelectedValue;
                    await APIPlan.UpdateAsync(plan);
                    MessageBox.Show("Plan guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                else //CREATE
                {
                    int idEspecialidad = (int)comboBoxEspecialidades.SelectedValue;
                    PlanDTO nuevoPlan = new PlanDTO(0, txtBoxDescripcion.Text, idEspecialidad);
                    PlanDTO planAdded = await APIPlan.AddAsync(nuevoPlan);
                    MessageBox.Show("Plan agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error al guardar el plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
