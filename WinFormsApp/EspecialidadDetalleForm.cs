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
                // Validar si la especialidad está deshabilitada
                if (isEdit && especialidad != null && !especialidad.Habilitado)
                {
                    DialogResult result = MessageBox.Show(
                        "Esta especialidad está deshabilitada.\n\nAl reactivarla se habilitarán:\n" +
                        "- Todos los planes de la especialidad\n" +
                        "- Todos los usuarios de esos planes\n" +
                        "- Todas las comisiones de esos planes\n" +
                        "- Todas las materias de esos planes\n" +
                        "- Todos los cursos relacionados\n\n¿Desea darla de alta?",
                        "Especialidad Deshabilitada",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            especialidad.Habilitado = true;
                            await APIEspecialidad.UpdateAsync(especialidad);
                            MessageBox.Show("Especialidad reactivada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show($"Error al reactivar la especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Esta especialidad está deshabilitada y no se puede modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        return;
                    }
                }

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
                        Descripcion = descripcion,
                        Habilitado = especialidad.Habilitado
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
