using DTOs;
using API.Clients;


namespace WinFormsApp
{
    public partial class CursoDetalleForm : Form
    {
        private NewCursoDTO curso;
        private bool isEdit = false;
        private bool isEditingMode = false; // Para controlar el estado de edición

        public CursoDetalleForm()
        {
            InitializeComponent();
            dataGridAlumnosCurso.SelectionChanged += dataGridAlumnosCurso_SelectionChanged;
            dataGridProfesoresCurso.SelectionChanged += dataGridProfesoresCurso_SelectionChanged;
        }

        public CursoDetalleForm(NewCursoDTO curso) : this()
        {
            this.curso = curso;
            isEdit = true;
        }

        private void dataGridAlumnosCurso_SelectionChanged(object? sender, EventArgs e)
        {
            btnEliminarAlumnoCurso.Visible = dataGridAlumnosCurso.SelectedRows.Count > 0 && dataGridAlumnosCurso.CurrentRow != null;
        }

        private void dataGridProfesoresCurso_SelectionChanged(object? sender, EventArgs e)
        {
            btnEliminarProfesorCurso.Visible = dataGridProfesoresCurso.SelectedRows.Count > 0 && dataGridProfesoresCurso.CurrentRow != null;
        }

        private async void CursoDetalleForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Validar si el curso está deshabilitado
                if (isEdit && curso != null && !curso.Habilitado)
                {
                    DialogResult result = MessageBox.Show(
                        "Este curso está deshabilitado.\n\n¿Desea darlo de alta?",
                        "Curso Deshabilitado",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            curso.Habilitado = true;
                            await APICurso.UpdateAsync(curso);
                            MessageBox.Show("Curso reactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show($"Error al reactivar el curso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Este curso está deshabilitado y no se puede modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnModificarCurso.Enabled = false;
                        Close();
                        return;
                    }
                }

                if (isEdit && curso != null && curso.Habilitado)
                {
                    List<ComisionDTO> comisiones = await APIComision.GetAllAsync();
                    if (comisiones.Count == 0)
                    {
                        MessageBox.Show("No se pudieron cargar las comisiones.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    // Filtrar solo comisiones habilitadas
                    var comisionesHabilitadas = comisiones.Where(c => c.Habilitado).ToList();
                    if (comisionesHabilitadas.Count == 0)
                    {
                        MessageBox.Show("No hay comisiones habilitadas disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    comboBoxComision.DataSource = comisionesHabilitadas;
                    comboBoxComision.DisplayMember = "Desc_comision";
                    comboBoxComision.ValueMember = "Id_comision";
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error al verificar el estado del curso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            catch
            {
                comboBoxComision.DataSource = null;
            }

            try
            {
                List<MateriaDTO> materias = await APIMateria.GetAllAsync();
                var materiasDisponibles = materias;
                if (materiasDisponibles.Count == 0)
                {
                    MessageBox.Show("No hay materias habilitadas disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                comboBoxMateria.DataSource = materiasDisponibles;
                comboBoxMateria.DisplayMember = "Desc_materia";
                comboBoxMateria.ValueMember = "Id_materia";
            }
            catch
            {
                comboBoxMateria.DataSource = null;
            }

            if (isEdit && curso != null)
            {
                numericAnio.Value = curso.Anio_calendario;
                numericCupo.Value = curso.Cupo;
                if (comboBoxComision.DataSource != null)
                {
                    var items = (System.Collections.IList)comboBoxComision.DataSource;
                    if (items.Cast<ComisionDTO>().Any(c => c.Id_comision == curso.Id_comision))
                    {
                        comboBoxComision.SelectedValue = curso.Id_comision;
                    }
                    else
                    {
                        comboBoxComision.SelectedIndex = -1;
                    }
                }

                if (comboBoxMateria.DataSource != null)
                {
                    var items = (System.Collections.IList)comboBoxMateria.DataSource;
                    if (items.Cast<MateriaDTO>().Any(m => m.Id_materia == curso.Id_materia))
                    {
                        comboBoxMateria.SelectedValue = curso.Id_materia;
                    }
                    else
                    {
                        comboBoxMateria.SelectedIndex = -1;
                    }
                }
                // Cargar alumnos del curso
                await LoadAlumnosCurso(curso.Id_curso);

                // Cargar profesores del curso
                await LoadProfesoresCurso(curso.Id_curso);

                SetEditingMode(false);
            }
            else
            {
                numericAnio.Value = DateTime.Now.Year;
                numericCupo.Value = 0;
                comboBoxComision.SelectedIndex = -1;
                comboBoxMateria.SelectedIndex = -1;
            }
        }

        private async Task LoadAlumnosCurso(int idCurso)
        {
            try
            {
                List<AlumnoCursoDetalleDTO> alumnos = await APIUsuario.GetAlumnosByCursoAsync(idCurso);

                dataGridAlumnosCurso.DataSource = null;
                dataGridAlumnosCurso.DataSource = alumnos;

                if (dataGridAlumnosCurso.Columns["IdInscripcion"] != null)
                {
                    dataGridAlumnosCurso.Columns["IdInscripcion"].Visible = false;
                }
                if (dataGridAlumnosCurso.Columns["Legajo"] != null)
                    dataGridAlumnosCurso.Columns["Legajo"].HeaderText = "Legajo";

                if (dataGridAlumnosCurso.Columns["Alumno"] != null)
                    dataGridAlumnosCurso.Columns["Alumno"].HeaderText = "Alumno";

                if (dataGridAlumnosCurso.Columns["Condicion"] != null)
                    dataGridAlumnosCurso.Columns["Condicion"].HeaderText = "Condición";

                if (dataGridAlumnosCurso.Columns["Nota"] != null)
                    dataGridAlumnosCurso.Columns["Nota"].HeaderText = "Nota";

                dataGridAlumnosCurso.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadProfesoresCurso(int idCurso)
        {
            try
            {
                List<ProfesorCursoDetalleDTO> profesores = await APIUsuario.GetProfesoresByCursoAsync(idCurso);

                dataGridProfesoresCurso.DataSource = null;
                dataGridProfesoresCurso.DataSource = profesores;

                if (dataGridProfesoresCurso.Columns["IdDictado"] != null)
                {
                    dataGridProfesoresCurso.Columns["IdDictado"].Visible = false;
                }
                if (dataGridProfesoresCurso.Columns["Legajo"] != null)
                    dataGridProfesoresCurso.Columns["Legajo"].HeaderText = "Legajo";

                if (dataGridProfesoresCurso.Columns["Nombre"] != null)
                    dataGridProfesoresCurso.Columns["Nombre"].HeaderText = "Profesor";

                if (dataGridProfesoresCurso.Columns["Cargo"] != null)
                    dataGridProfesoresCurso.Columns["Cargo"].HeaderText = "Cargo";

                dataGridProfesoresCurso.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetEditingMode(bool enabled)
        {
            isEditingMode = enabled;

            comboBoxMateria.Enabled = enabled;
            comboBoxComision.Enabled = enabled;
            numericAnio.Enabled = enabled;
            numericCupo.Enabled = enabled;

            if (enabled)
            {
                btnModificarCurso.BackColor = Color.Orange;
                btnModificarCurso.Text = "Editando";
            }
            else
            {
                btnModificarCurso.BackColor = SystemColors.Control;
                btnModificarCurso.Text = "Modificar Curso";
            }
        }

        private void btnModificarCurso_Click(object? sender, EventArgs e)
        {
            SetEditingMode(!isEditingMode);
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                NewCursoDTO dto = new NewCursoDTO
                {
                    Id_curso = (curso != null) ? curso.Id_curso : 0,
                    Anio_calendario = (int)numericAnio.Value,
                    Cupo = (int)numericCupo.Value,
                    Id_comision = comboBoxComision.SelectedValue != null ? (int)comboBoxComision.SelectedValue : 0,
                    Id_materia = comboBoxMateria.SelectedValue != null ? (int)comboBoxMateria.SelectedValue : 0,
                    Habilitado = true
                };

                if (isEdit)
                {
                    await APICurso.UpdateAsync(dto);
                    MessageBox.Show("Curso actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await APICurso.AddAsync(dto);
                    MessageBox.Show("Curso agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar curso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnEliminarAlumnoCurso_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridAlumnosCurso.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un alumno para eliminar su inscripción.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idInscripcion = (int)dataGridAlumnosCurso.CurrentRow.Cells["IdInscripcion"].Value;
                string nombreAlumno = dataGridAlumnosCurso.CurrentRow.Cells["Alumno"].Value?.ToString() ?? "este alumno";
                string condicion = dataGridAlumnosCurso.CurrentRow.Cells["Condicion"].Value?.ToString() ?? "desconocida";

                // Mostrar mensaje de confirmación
                DialogResult confirmResult = MessageBox.Show(
                    $"¿Está seguro que desea eliminar la inscripción del alumno '{nombreAlumno}'?\n\nCondición: {condicion}\n\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // Solo eliminar si el usuario confirma
                if (confirmResult == DialogResult.Yes)
                {
                    await APIUsuario.DeleteAlumnoCursoAsync(idInscripcion);
                    MessageBox.Show("Inscripción eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar la lista de alumnos
                    await LoadAlumnosCurso(curso.Id_curso);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminarProfesorCurso_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dataGridProfesoresCurso.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un profesor para eliminar su asignación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idDictado = (int)dataGridProfesoresCurso.CurrentRow.Cells["IdDictado"].Value;
                string nombreProfesor = dataGridProfesoresCurso.CurrentRow.Cells["Nombre"].Value?.ToString() ?? "este profesor";
                string cargo = dataGridProfesoresCurso.CurrentRow.Cells["Cargo"].Value?.ToString() ?? "desconocido";

                // Mostrar mensaje de confirmación
                DialogResult confirmResult = MessageBox.Show(
                    $"¿Está seguro que desea eliminar la asignación del profesor '{nombreProfesor}'?\n\nCargo: {cargo}\n\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // Solo eliminar si el usuario confirma
                if (confirmResult == DialogResult.Yes)
                {
                    await APIUsuario.DeleteProfesorCursoAsync(idDictado);
                    MessageBox.Show("Asignación eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar la lista de profesores
                    await LoadProfesoresCurso(curso.Id_curso);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarProfesorCurso_Click(object? sender, EventArgs e)
        {
            try
            {
                Hide();
                using (var formSeleccion = new CursoSeleccionProfesor(curso.Id_curso))
                {
                    formSeleccion.ShowDialog();

                    // Si se agregó un profesor, recargar la lista
                    if (formSeleccion.ProfesorAgregado)
                    {
                        _ = LoadProfesoresCurso(curso.Id_curso);
                    }
                }
                Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Show();
            }
        }

        private void dataGridProfesoresCurso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

