using DTOs;
using API.Clients;


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
                if (isEdit && plan != null)
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
