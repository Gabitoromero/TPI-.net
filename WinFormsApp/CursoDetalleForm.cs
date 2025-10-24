using DTOs;
using API.Clients;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        public CursoDetalleForm(NewCursoDTO curso) : this()
        {
            this.curso = curso;
            isEdit = true;
        }

        private void dataGridAlumnosCurso_SelectionChanged(object? sender, EventArgs e)
        {
            // No se permite la selección de filas
            //dataGridAlumnosCurso.ClearSelection();
            btnEliminarAlumnoCurso.Visible = dataGridAlumnosCurso.SelectedRows.Count > 0 && dataGridAlumnosCurso.CurrentRow != null;
        }

        private async void CursoDetalleForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<ComisionDTO> comisiones = await APIComision.GetAllAsync();
                comboBoxComision.DataSource = comisiones;
                comboBoxComision.DisplayMember = "Desc_comision";
                comboBoxComision.ValueMember = "Id_comision";
            }
            catch
            {
                comboBoxComision.DataSource = null;
            }

            try
            {
                List<MateriaDTO> materias = await APIMateria.GetAllAsync();
                comboBoxMateria.DataSource = materias;
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
                await LoadAlumnosCurso(curso.Id_curso);
                SetEditingMode(false);
            }
            else
            {
                // new course: ensure fields empty
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
                var alumnos = await APIUsuario.GetAlumnosByCursoAsync(idCurso);

                dataGridAlumnosCurso.DataSource = null;
                dataGridAlumnosCurso.DataSource = alumnos;

                if (dataGridAlumnosCurso.Columns["IdInscripcion"] != null)
                {
                    dataGridAlumnosCurso.Columns["IdInscripcion"].Visible = false;
                }
                if (dataGridAlumnosCurso.Columns["Legajo"] != null)
                    dataGridAlumnosCurso.Columns["Legajo"].HeaderText = "Legajo";

                if (dataGridAlumnosCurso.Columns["NombreCompleto"] != null)
                    dataGridAlumnosCurso.Columns["NombreCompleto"].HeaderText = "Alumno";

                if (dataGridAlumnosCurso.Columns["Condicion"] != null)
                    dataGridAlumnosCurso.Columns["Condicion"].HeaderText = "Condición";

                if (dataGridAlumnosCurso.Columns["Nota"] != null)
                    dataGridAlumnosCurso.Columns["Nota"].HeaderText = "Nota";

                dataGridAlumnosCurso.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar alumnos del curso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                btnModificarCurso.Text = "Cancelar Edición";
            }
            else
            {
                btnModificarCurso.BackColor = SystemColors.Control; 
                btnModificarCurso.Text = "Modificar Curso";
            }
        }

        private void btnModificarCurso_Click(object? sender, EventArgs e)
        {
            // Toggle entre modo edición y modo visualización
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
                    Id_materia = comboBoxMateria.SelectedValue != null ? (int)comboBoxMateria.SelectedValue : 0
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

                this.Close();
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
            this.Close();
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
                MessageBox.Show($"Error al eliminar inscripción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
