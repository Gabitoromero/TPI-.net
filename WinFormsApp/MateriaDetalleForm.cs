using DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;

namespace WinFormsApp
{
    public partial class MateriaDetalleForm : Form
    {
        private MateriaDTO dto;
        private bool isEdit = false;
        public MateriaDetalleForm()
        {
            InitializeComponent();
        }
        public MateriaDetalleForm(MateriaDTO dto) : this()
        {
            this.dto = dto;
            isEdit = true;
        }

        private async void MateriaDetalleForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Validar si la materia está deshabilitada
                if (isEdit && dto != null && !dto.Habilitado)
                {
                    DialogResult result = MessageBox.Show(
                        "Esta materia está deshabilitada.\n\n¿Desea darla de alta?",
                        "Materia Deshabilitada",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            dto.Habilitado = true;
                            await APIMateria.UpdateAsync(dto);
                            MessageBox.Show("Materia reactivada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show($"Error al reactivar la materia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Esta materia está deshabilitada y no se puede modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        return;
                    }
                }

                var plans = await APIPlan.GetAllAsync();
                comboBoxPlan.DataSource = plans;
                comboBoxPlan.DisplayMember = "Descripcion";
                comboBoxPlan.ValueMember = "IdPlan";
           
                if (isEdit && dto != null)
                {
                    txtDesc.Text = dto.Desc_materia;
                    numericHsSem.Value = dto.Hs_semanales;
                    numericHsTot.Value = dto.Hs_totales;
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
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if((int)numericHsTot.Value < (int)numericHsSem.Value)
                {
                    throw new ArgumentException("Las horas totales son menores a las horas semanales");
                }
                MateriaDTO toSend = new MateriaDTO
                {
                    Id_materia = (dto != null) ? dto.Id_materia : 0,
                    Desc_materia = txtDesc.Text,
                    Hs_semanales = (int)numericHsSem.Value,
                    Hs_totales = (int)numericHsTot.Value,
                    Id_plan = comboBoxPlan.SelectedValue != null ? (int)comboBoxPlan.SelectedValue : 0,
                    Habilitado = (dto != null) ? dto.Habilitado : true
                };

                if (isEdit)
                {
                    await APIMateria.UpdateAsync(toSend);
                    MessageBox.Show("Materia actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await APIMateria.AddAsync(toSend);
                    MessageBox.Show("Materia agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
