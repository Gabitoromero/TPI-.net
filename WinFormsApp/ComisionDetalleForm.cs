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
                // Validar si la comisión está deshabilitada
                if (isEdit && dto != null && !dto.Habilitado)
                {
                    DialogResult result = MessageBox.Show(
                        "Esta comisión está deshabilitada.\n\nAl reactivarla se habilitarán todos los cursos relacionados.\n\n¿Desea darla de alta?",
                        "Comisión Deshabilitada",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            dto.Habilitado = true;
                            await APIComision.UpdateAsync(dto);
                            MessageBox.Show("Comisión reactivada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show($"Error al reactivar la comisión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Esta comisión está deshabilitada y no se puede modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        return;
                    }
                }

                var plans = await APIPlan.GetAllAsync();
                // Filtrar solo planes habilitados
                var planesDisponibles = plans;
                if (planesDisponibles.Count == 0)
                {
                    MessageBox.Show("No hay planes habilitados disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                comboBoxPlan.DataSource = planesDisponibles;
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
                MessageBox.Show($"Error al cargar comisión: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if((int)numericAnio.Value == 0)
                {
                    throw new ArgumentException("El año debe ser distinto de 0");
                }
                ComisionDTO toSend = new ComisionDTO
                {
                    Id_comision = (dto != null) ? dto.Id_comision : 0,
                    Desc_comision = txtDesc.Text,
                    Anio_especialidad = (int)numericAnio.Value,
                    Id_plan = comboBoxPlan.SelectedValue != null ? (int)comboBoxPlan.SelectedValue : 0,
                    Habilitado = (dto != null) ? dto.Habilitado : true
                };

                if (isEdit)
                {
                    await APIComision.UpdateAsync(toSend);
                    MessageBox.Show("Comisión actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await APIComision.AddAsync(toSend);
                    MessageBox.Show("Comisión agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

