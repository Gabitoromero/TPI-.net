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
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Id_plan = comboBoxPlan.SelectedValue != null ? (int)comboBoxPlan.SelectedValue : 0
                };

                if (isEdit)
                {
                    await APIMateria.UpdateAsync(toSend);
                }
                else
                {
                    await APIMateria.AddAsync(toSend);
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
