using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace WinFormsApp
{
    public partial class AlumnosCursoForm : Form
    {
        private int idCurso;
        private List<ShowAlumno_CursoDTO> alumnosDelCurso;

        public AlumnosCursoForm(int idCurso)
        {
            InitializeComponent();
            this.idCurso = idCurso;
            this.Load += AlumnosCursoForm_Load;
            dataGridViewAlumnosCurso.SelectionChanged += DataGridViewAlumnosCurso_SelectionChanged;
            btnModificar.Enabled = false;
        }

        private void DataGridViewAlumnosCurso_SelectionChanged(object? sender, EventArgs e)
        {
            btnModificar.Enabled = dataGridViewAlumnosCurso.SelectedRows.Count > 0 && dataGridViewAlumnosCurso.CurrentRow != null;
        }

        private async void AlumnosCursoForm_Load(object? sender, EventArgs e)
        {
            await LoadAlumnosCurso();
        }

        private async Task LoadAlumnosCurso()
        {
            try
            {
                // Obtener todos los alumnos del curso con información completa
                var todosLosAlumnos = await APIUsuario.GetAlumnosCompletoByCursoAsync(idCurso);

                // Filtrar solo alumnos habilitados
                alumnosDelCurso = todosLosAlumnos.Where(a => a.Alumno.Habilitado == true).ToList();

                // Proyectar los datos para el DataGridView
                var dataView = alumnosDelCurso.Select(a => new
                {
                    IdInscripcion = a.IdInscripcion,
                    Legajo = a.Alumno.Legajo,
                    NombreUsuario = a.Alumno.NombreUsuario,
                    Condicion = a.Condicion,
                    Nota = a.Nota
                }).ToList();

                dataGridViewAlumnosCurso.DataSource = null;
                dataGridViewAlumnosCurso.DataSource = dataView;

                // Ocultar la columna IdInscripcion
                if (dataGridViewAlumnosCurso.Columns["IdInscripcion"] != null)
                {
                    dataGridViewAlumnosCurso.Columns["IdInscripcion"].Visible = false;
                }

                // Configurar headers
                if (dataGridViewAlumnosCurso.Columns["Legajo"] != null)
                    dataGridViewAlumnosCurso.Columns["Legajo"].HeaderText = "Legajo";
                if (dataGridViewAlumnosCurso.Columns["NombreUsuario"] != null)
                    dataGridViewAlumnosCurso.Columns["NombreUsuario"].HeaderText = "Nombre de Usuario";
                if (dataGridViewAlumnosCurso.Columns["Condicion"] != null)
                    dataGridViewAlumnosCurso.Columns["Condicion"].HeaderText = "Condición";
                if (dataGridViewAlumnosCurso.Columns["Nota"] != null)
                    dataGridViewAlumnosCurso.Columns["Nota"].HeaderText = "Nota";

                dataGridViewAlumnosCurso.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewAlumnosCurso.ClearSelection();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnModificar_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAlumnosCurso.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un alumno para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string username = APIClientBase.LoginResponse.Username;
                ShowUsuarioDTO current = await APIUsuario.GetByUsernameAsync(username);
                if (!current.Habilitado ?? false)
                {
                    MessageBox.Show("Su cuenta no está habilitada. No puede modificar el estado del alumno.", "Cuenta no habilitada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Obtener el IdInscripcion de la fila seleccionada
                    int idInscripcion = (int)dataGridViewAlumnosCurso.CurrentRow.Cells["IdInscripcion"].Value;

                    // Buscar el alumno completo en nuestra lista
                    var alumnoSeleccionado = alumnosDelCurso.FirstOrDefault(a => a.IdInscripcion == idInscripcion);

                    if (alumnoSeleccionado == null)
                    {
                        MessageBox.Show("No se encontró el alumno seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Hide();
                    using (var formEditar = new AlumnoCursoPutForm(alumnoSeleccionado))
                    {
                        DialogResult result = formEditar.ShowDialog();
                    }
                    Show();
                }

                await LoadAlumnosCurso();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Show();
            }
        }
    }
}
