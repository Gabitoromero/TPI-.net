using API.Clients;
using DTOs;

namespace WinFormsApp
{
    public partial class InscripcionNueva : Form
    {
        private List<CursoDisplayDTO> cursosDisponibles;

        public InscripcionNueva()
        {
            InitializeComponent();
            btnCancelar.Click += BtnCancelar_Click;
            dataGridCursos.CellClick += DataGridCursos_CellClick;
            dataGridCursos.SelectionChanged += DataGridCursos_SelectionChanged;
        }

        private void DataGridCursos_SelectionChanged(object? sender, EventArgs e)
        {

        }

        private async void InscripcionNueva_Load(object? sender, EventArgs e)
        {
            try
            {
                if (APIUsuario.LoginResponse == null || string.IsNullOrEmpty(APIUsuario.LoginResponse.Username))
                {
                    MessageBox.Show("Error: No hay sesión activa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                var cursos = await APICurso.GetAllDisponiblesAsync();
                if (cursos == null || cursos.Count == 0)
                {
                    MessageBox.Show("No hay cursos disponibles para inscripción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                cursosDisponibles = new List<CursoDisplayDTO>();

                foreach (var curso in cursos)
                {
                    var materia = await APIMateria.GetAsync(curso.Id_materia);
                    var comision = await APIComision.GetAsync(curso.Id_comision);

                    cursosDisponibles.Add(new CursoDisplayDTO
                    { 
                        IdCurso = curso.Id_curso,
                        Materia = materia.Desc_materia,
                        Comision = comision.Desc_comision,
                        Anio = curso.Anio_calendario,
                        DisplayText = $"{materia.Desc_materia} - {comision.Desc_comision} - {curso.Anio_calendario}"
                    });
                }

                dataGridCursos.DataSource = cursosDisponibles;

                if (dataGridCursos.Columns["IdCurso"] != null)
                    dataGridCursos.Columns["IdCurso"].Visible = false;
                if (dataGridCursos.Columns["Materia"] != null)
                    dataGridCursos.Columns["Materia"].HeaderText = "Materia";
                if (dataGridCursos.Columns["Comision"] != null)
                    dataGridCursos.Columns["Comision"].HeaderText = "Comisión";
                if (dataGridCursos.Columns["Anio"] != null)
                    dataGridCursos.Columns["Anio"].HeaderText = "Año";
                if (dataGridCursos.Columns["DisplayText"] != null)
                    dataGridCursos.Columns["DisplayText"].Visible = false;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void DataGridCursos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var cursoSeleccionado = cursosDisponibles[e.RowIndex];

                var confirmResult = MessageBox.Show(
                    $"¿Desea inscribirse al curso {cursoSeleccionado.DisplayText}?",
                    "Confirmar Inscripción",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    await InscribirAlumno(cursoSeleccionado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task InscribirAlumno(CursoDisplayDTO curso)
        {
            try
            {
                var alumno = await APIUsuario.GetByUsernameAsync(APIUsuario.LoginResponse.Username);
                if (alumno == null)
                {
                    MessageBox.Show("Error: No se pudo obtener la información del alumno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var inscripcionDTO = new Alumno_CursoDTO
                {
                    IdInscripcion = 0,
                    IdAlumno = alumno.Id,
                    IdCurso = curso.IdCurso,
                    Condicion = "Inscripto",
                    Nota = null
                };

                await APIUsuario.AddAlumnoCursoAsync(inscripcionDTO);

                MessageBox.Show(
                    $"¡Inscripción exitosa!\n\nCurso: {curso.DisplayText}",
                    "Inscripción Confirmada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridCursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
