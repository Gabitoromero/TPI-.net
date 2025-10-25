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
            dataGridViewCursos.SelectionChanged += dataGridViewCursos_SelectionChanged;
            btnDetalle.Click += btnDetalle_Click;
            btnDetalle.Enabled = false;
        }
        
        private void dataGridViewCursos_SelectionChanged(object? sender, EventArgs e)
        {
            btnDetalle.Enabled = dataGridViewCursos.SelectedRows.Count > 0 && dataGridViewCursos.CurrentRow != null;
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
                    IdCurso = c.Curso.Id_curso,
                    Materia = materias[idx].Desc_materia,
                    Comision = comisiones[idx].Desc_comision,
                    Año = c.Curso.Anio_calendario,
                    Cargo = c.Cargo
                }).ToList();

                dataGridViewCursos.DataSource = data;

                // Ocultar la columna IdCurso
                if (dataGridViewCursos.Columns["IdCurso"] != null)
                {
                    dataGridViewCursos.Columns["IdCurso"].Visible = false;
                }

                dataGridViewCursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnCerrar_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void ProfesorCursosDetalle_Load_1(object sender, EventArgs e)
        {

        }

        private void btnDetalle_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dataGridViewCursos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un curso para ver sus alumnos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idCurso = (int)dataGridViewCursos.CurrentRow.Cells["IdCurso"].Value;
               
                Hide();
                using (var formAlumnos = new AlumnosCursoForm(idCurso))
                {
                    formAlumnos.ShowDialog();
                }
                Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Show();
            }
        }
    }
}
