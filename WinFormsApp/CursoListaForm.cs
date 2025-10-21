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
                
                List<NewCursoDTO> cursos = await APICurso.GetAllAsync();
                List<ComisionDTO> comisiones = new List<ComisionDTO>();
                List<MateriaDTO> materias = new List<MateriaDTO>();

                try
                {
                    comisiones = await APIComision.GetAllAsync();
                }
                catch
                {
                    
                    comisiones = new List<ComisionDTO>();
                }

                try
                {
                    materias = await APIMateria.GetAllAsync();
                }
                catch
                {
                    
                    materias = new List<MateriaDTO>();
                }

                var view = (cursos ?? new List<NewCursoDTO>())
                    .Select(c => new
                    {
                        Id_curso = c.Id_curso,
                        Anio_calendario = c.Anio_calendario,
                        Cupo = c.Cupo,
                        Comision = comisiones.FirstOrDefault(x => x.Id_comision == c.Id_comision)?.Desc_comision ?? "(sin comision)",
                        Materia = materias.FirstOrDefault(m => m.Id_materia == c.Id_materia)?.Desc_materia ?? "(sin materia)"
                    })
                    .ToList();

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
                string materiaDesc = dataGridViewCursos.CurrentRow.Cells["Materia"].Value?.ToString() ?? "desconocida";
                string comisionDesc = dataGridViewCursos.CurrentRow.Cells["Comision"].Value?.ToString() ?? "desconocida";
                int anio = (int)dataGridViewCursos.CurrentRow.Cells["Anio_calendario"].Value;

                // Mostrar mensaje de confirmación
                DialogResult confirmResult = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el curso?\n\nMateria: {materiaDesc}\nComisión: {comisionDesc}\nAño: {anio}\n\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // Solo eliminar si el usuario confirma
                if (confirmResult == DialogResult.Yes)
                {
                    await APICurso.DeleteAsync(id);
                    MessageBox.Show("Curso eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCursos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el curso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   
    }
}
