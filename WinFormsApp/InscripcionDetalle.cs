using API.Clients;
using System.Data;
using DTOs;

namespace WinFormsApp
{
    public partial class InscripcionDetalle : Form
    {

        public InscripcionDetalle()
        {
            InitializeComponent();
            this.Load += InscripcionDetalle_Load;
        }

        private async void InscripcionDetalle_Load(object? sender, EventArgs e)
        {
            try
            {
                ShowUsuarioDTO alumno = await APIUsuario.GetByUsernameAsync(APIUsuario.LoginResponse.Username);
                var inscripciones = await APIUsuario.GetAlumnoCursosAsync(alumno.Id);
                var materiaTasks = inscripciones.Select(i => APIMateria.GetAsync(i.Curso.Id_materia)).ToList();
                var comisionTasks = inscripciones.Select(i => APIComision.GetAsync(i.Curso.Id_comision)).ToList();
                var materias = await Task.WhenAll(materiaTasks);
                var comisiones = await Task.WhenAll(comisionTasks);

                var data = inscripciones.Select((i, idx) => new
                {
                    Materia = materias[idx].Desc_materia,
                    Comision = comisiones[idx].Desc_comision,
                    Condicion = i.Condicion,
                    Nota = i.Nota
                }).ToList();

                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando inscripciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InscripcionDetalle_Load_1(object sender, EventArgs e)
        {

        }
    }
}
