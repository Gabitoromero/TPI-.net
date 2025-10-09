using DTOs;
using API.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class CursoListaForm : Form
    {
        public CursoListaForm()
        {
            InitializeComponent();
        }

        public async void CursoListaForm_Load(object sender, EventArgs e)
        {
            await LoadCursos();
        }

        private async Task LoadCursos()
        {
            try
            {
                List<CursoDTO> cursos = await APICurso.GetAllAsync();

                var view = (cursos ?? new List<CursoDTO>()).Select(c => new
                {
                    Id_curso = c.Id_curso,
                    Anio_calendario = c.Anio_calendario,
                    Cupo = c.Cupo
                }).ToList();

                dataGridViewCursos.DataSource = view;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar los cursos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            CursoDetalleForm form = new CursoDetalleForm();
            form.ShowDialog();
            await LoadCursos();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewCursos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un curso para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = (int)dataGridViewCursos.CurrentRow.Cells["Id_curso"].Value;
                NewCursoDTO curso = await APICurso.GetAsync(id);
                CursoDetalleForm form = new CursoDetalleForm(curso);
                form.ShowDialog();
                await LoadCursos();
            }
            catch (ArgumentException err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el curso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewCursos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un curso para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = (int)dataGridViewCursos.CurrentRow.Cells["Id_curso"].Value;
                await APICurso.DeleteAsync(id);
                MessageBox.Show("Curso eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadCursos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el curso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            /*try
            {
                string filtroComision = textBoxFiltroComision.Text?.Trim();
                string filtroMateria = textBoxFiltroMateria.Text?.Trim();

                if (string.IsNullOrEmpty(filtroComision) && string.IsNullOrEmpty(filtroMateria))
                {
                    await LoadCursos();
                    return;
                }

                
                List<CursoDTO> cursos = await APICurso.GetAllAsync();

                var filtered = cursos.AsEnumerable();

                if (!string.IsNullOrEmpty(filtroComision))
                {
                    // assuming Comision id or name is an int or string present in DTO — since DTO doesn't have it, this will currently do nothing
                    // keep as placeholder to wire UI; later include Id_comision in DTO and API
                    filtered = filtered.Where(c => false); // no-op placeholder
                }

                if (!string.IsNullOrEmpty(filtroMateria))
                {
                    // same placeholder for materia
                    filtered = filtered.Where(c => false);
                }

                var view = filtered.Select(c => new
                {
                    Id_curso = c.Id_curso,
                    Anio_calendario = c.Anio_calendario,
                    Cupo = c.Cupo
                }).ToList();

                dataGridViewCursos.DataSource = view;

                if (view.Count == 0)
                {
                    MessageBox.Show("No se encontraron cursos con esos filtros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar cursos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
    }
}
