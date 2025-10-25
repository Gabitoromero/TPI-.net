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
            this.Load += InscripcionNueva_Load;
            btnCancelar.Click += BtnCancelar_Click;
            dataGridCursos.CellClick += DataGridCursos_CellClick;
        }

        private async void InscripcionNueva_Load(object? sender, EventArgs e)
        {
            try
            {
                // Obtener el alumno actual
                if (APIUsuario.LoginResponse == null || string.IsNullOrEmpty(APIUsuario.LoginResponse.Username))
                {
                    MessageBox.Show("Error: No hay sesión activa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Cargar todos los cursos disponibles
                var cursos = await APICurso.GetAllAsync();

                // Crear lista para mostrar con información completa
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

                // Configurar el DataGridView
                dataGridCursos.AutoGenerateColumns = true;
                dataGridCursos.DataSource = null; // Limpiar datasource anterior
                dataGridCursos.DataSource = cursosDisponibles;

                // Configurar columnas después de establecer el DataSource
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

                dataGridCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridCursos.MultiSelect = false;
                dataGridCursos.ReadOnly = true;
                dataGridCursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridCursos.AllowUserToAddRows = false;

                // Ocultar el botón confirmar inicialmente
                btnGuardar.Visible = false;
            }
            catch (Exception ex)
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

                // Mostrar mensaje de confirmación
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
                // Obtener el ID del alumno actual
                var alumno = await APIUsuario.GetByUsernameAsync(APIUsuario.LoginResponse.Username);
                if (alumno == null)
                {
                    MessageBox.Show("Error: No se pudo obtener la información del alumno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear el DTO de inscripción
                var inscripcionDTO = new Alumno_CursoDTO
                {
                    IdInscripcion = 0,
                    IdAlumno = alumno.Id,
                    IdCurso = curso.IdCurso,
                    Condicion = "Inscripto",
                    Nota = null
                };

                // Realizar la inscripción
                await APIUsuario.AddAlumnoCursoAsync(inscripcionDTO);

                // Mostrar mensaje de éxito
                MessageBox.Show(
                    $"¡Inscripción exitosa!\n\nCurso: {curso.DisplayText}",
                    "Inscripción Confirmada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Cerrar el formulario
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
