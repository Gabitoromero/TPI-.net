using DTOs;
using API.Clients;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class EspecialidadDetalleForm : Form
    {
        private EspecialidadDTO especialidad;
        private bool isEdit = false;

        public EspecialidadDetalleForm()
        {
            InitializeComponent();
        }

        public EspecialidadDetalleForm(EspecialidadDTO dto) : this()
        {
            especialidad = dto;
            isEdit = true;
        }

        public async void EspecialidadDetalleForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (isEdit && especialidad != null)
                {
                    txtBoxDescripcion.Text = especialidad.Descripcion;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string descripcion = txtBoxDescripcion.Text?.Trim();
                if (string.IsNullOrWhiteSpace(descripcion))
                {
                    MessageBox.Show("La descripción no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (isEdit && especialidad != null)
                {
                    EspecialidadDTO toSend = new EspecialidadDTO 
                    { 
                        Id = especialidad.Id, 
                        Descripcion = descripcion
                    };
                    await APIEspecialidad.UpdateAsync(toSend);
                    MessageBox.Show("Especialidad actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    NewEspecialidadDTO nuevo = new NewEspecialidadDTO { Descripcion = descripcion };
                    EspecialidadDTO created = await APIEspecialidad.AddAsync(nuevo);
                    MessageBox.Show("Especialidad creada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
