using DTOs;
using System;
using System.Linq;
using System.Windows.Forms;
using API.Clients;

namespace WinFormsApp
{
    public partial class ComisionDetalleForm : Form
    {
        private ComisionDTO dto;
        private bool isEdit = false;
        public ComisionDetalleForm()
        {
            InitializeComponent();
        }
        public ComisionDetalleForm(ComisionDTO dto) : this()
        {
            this.dto = dto;
            isEdit = true;
        }

        private async void ComisionDetalleForm_Load(object sender, EventArgs e)
        {
            try
            {
                var plans = await APIPlan.GetAllAsync();
                comboBoxPlan.DataSource = plans;
                comboBoxPlan.DisplayMember = "Descripcion";
                comboBoxPlan.ValueMember = "IdPlan";
            

            if (isEdit && dto != null)
            {
                txtDesc.Text = dto.Desc_comision;
                numericAnio.Value = dto.Anio_especialidad;
                if (comboBoxPlan.DataSource != null)
                {
                    var planList = (System.Collections.IList)comboBoxPlan.DataSource;
                    if (planList.Cast<PlanDTO>().Any(p => p.IdPlan == dto.Id_plan))
                    {
                        comboBoxPlan.SelectedValue = dto.Id_plan;
                    }
                    else
                    {
                        comboBoxPlan.SelectedIndex = -1;
                    }
                }
            }
            }
            catch (ArgumentException err)
            {
                MessageBox.Show($"Error al cargar comisión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar comisión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ComisionDTO toSend = new ComisionDTO
                {
                    Id_comision = (dto != null) ? dto.Id_comision : 0,
                    Desc_comision = txtDesc.Text,
                    Anio_especialidad = (int)numericAnio.Value,
                    Id_plan = comboBoxPlan.SelectedValue != null ? (int)comboBoxPlan.SelectedValue : 0
                };

                if (isEdit)
                {
                    await APIComision.UpdateAsync(toSend);
                }
                else
                {
                    await APIComision.AddAsync(toSend);
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar comision: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
