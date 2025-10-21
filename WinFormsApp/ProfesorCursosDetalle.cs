using API.Clients;
using System.Data;
using DTOs;

namespace WinFormsApp
{
    public partial class ProfesorCursosDetalle : Form
    {
        public ProfesorCursosDetalle()
        {
            InitializeComponent();
            this.Load += ProfesorCursosDetalle_Load;
        }

        private async void ProfesorCursosDetalle_Load(object? sender, EventArgs e)
        {
            try
            {

                ShowUsuarioDTO profesor = await APIUsuario.GetByUsernameAsync(APIUsuario.LoginResponse.Username);
                var cursosProfesor = await APIUsuario.GetProfesorCursosAsync(profesor.Id);

                // Obtener información de materias y comisiones
                var materiaTasks = cursosProfesor.Select(c => APIMateria.GetAsync(c.Curso.Id_materia)).ToList();
                var comisionTasks = cursosProfesor.Select(c => APIComision.GetAsync(c.Curso.Id_comision)).ToList();
                var materias = await Task.WhenAll(materiaTasks);
                var comisiones = await Task.WhenAll(comisionTasks);

                var data = cursosProfesor.Select((c, idx) => new
                {
                    Materia = materias[idx].Desc_materia,
                    Comision = comisiones[idx].Desc_comision,
                    Año = c.Curso.Anio_calendario,
                    Cargo = c.Cargo
                }).ToList();

                dataGridViewCursos.DataSource = data;
                dataGridViewCursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando cursos del profesor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnCerrar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
