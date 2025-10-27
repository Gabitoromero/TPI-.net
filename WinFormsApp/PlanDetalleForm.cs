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
        private bool isEdit = false;
        public PlanDetalleForm()
        {
            InitializeComponent();
        }
        public PlanDetalleForm(PlanDTO plan) : this()
        {
            this.plan = plan;
            this.isEdit = true;
        }
        
        public async void PlanDetalleForm_Load_1(object sender, EventArgs e)
        {
            try
            {
                // Validar si el plan está deshabilitado
                if (isEdit && plan != null)
                {
                    DialogResult result = MessageBox.Show(
                        "Este plan está deshabilitado.\n\nAl reactivarlo se habilitarán:\n- Todos los usuarios del plan\n- Todas las comisiones del plan\n- Todas las materias del plan\n- Todos los cursos relacionados\n\n¿Desea darlo de alta?",
                        "Plan Deshabilitado",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            await APIPlan.UpdateAsync(plan);
                            MessageBox.Show("Plan reactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show($"Error al reactivar el plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Este plan está deshabilitado y no se puede modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        return;
                    }
                }

                await LoadEspecialidades();
                
                if (isEdit && plan != null)
                {
                    txtBoxDescripcion.Text = plan.Descripcion;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private async Task LoadEspecialidades()
        {
            var especialidades = await APIEspecialidad.GetAllAsync();
     
            comboBoxEspecialidades.DataSource = especialidades;
            comboBoxEspecialidades.DisplayMember = "Descripcion";
            comboBoxEspecialidades.ValueMember = "Id";
            
            if (isEdit && plan != null)
            {
                if (especialidades.Any(e => e.Id == plan.IdEspecialidad))
                {
                    comboBoxEspecialidades.SelectedValue = plan.IdEspecialidad;
                }
                else
                {
                    comboBoxEspecialidades.SelectedIndex = -1;
                }
            }
            else
            {
                comboBoxEspecialidades.SelectedIndex = -1;
            }
        }

        public void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        public void btnGuardar_Click(object sender, EventArgs e)
        {
            btnGuardar_Click_1(sender, e);
        }

        private async void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                int idEspecialidad = comboBoxEspecialidades.SelectedValue != null ? (int)comboBoxEspecialidades.SelectedValue : 0;

                if (isEdit && plan != null)
                {
                    PlanDTO toSend = new PlanDTO
                    {
                        IdPlan = plan.IdPlan,
                        Descripcion = txtBoxDescripcion.Text,
                        IdEspecialidad = idEspecialidad
                    };

                    await APIPlan.UpdateAsync(toSend);
                    MessageBox.Show("Plan guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    PlanDTO nuevoPlan = new PlanDTO
                    {
                        IdPlan = 0,
                        Descripcion = txtBoxDescripcion.Text,
                        IdEspecialidad = idEspecialidad
                    };
                    PlanDTO planAdded = await APIPlan.AddAsync(nuevoPlan);
                    MessageBox.Show("Plan agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
