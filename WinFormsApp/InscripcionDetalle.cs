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
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void InscripcionDetalle_Load_1(object sender, EventArgs e)
        {
            try
            {
                if (APIUsuario.LoginResponse == null || string.IsNullOrEmpty(APIUsuario.LoginResponse.Username))
                {
                    MessageBox.Show("Error: No hay sesión activa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                ShowUsuarioDTO alumno = await APIUsuario.GetByUsernameAsync(APIUsuario.LoginResponse.Username);
                List<ShowAlumno_CursoDTO>? inscripciones = await APIUsuario.GetAlumnoCursosAsync(alumno.Id);

                if (inscripciones == null) 
                { 
                    MessageBox.Show($"Alumno sin inscripciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }

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
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
