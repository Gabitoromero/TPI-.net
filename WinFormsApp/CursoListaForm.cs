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
            dataGridViewCursos.SelectionChanged += DataGridViewCursos_SelectionChanged;
            dataGridViewCursos.CellDoubleClick += DataGridViewCursos_CellDoubleClick;
        }

        public async void CursoListaForm_Load(object sender, EventArgs e)
        {
            await LoadCursos();
            dataGridViewCursos.ClearSelection();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void DataGridViewCursos_SelectionChanged(object? sender, EventArgs e)
        {
            btnModificar.Enabled = dataGridViewCursos.SelectedRows.Count > 0 && dataGridViewCursos.CurrentRow != null;
            btnEliminar.Enabled = dataGridViewCursos.SelectedRows.Count > 0 && dataGridViewCursos.CurrentRow != null;
        }

        private async Task LoadCursos()
        {
            try
            {
                
                List<NewCursoDTO> cursos = await APICurso.GetAllAsync();
                if(cursos.Count == 0)
                {
                    MessageBox.Show("No se pudieron cargar los cursos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                List<ComisionDTO> comisiones = await APIComision.GetAllAsync();
                if(comisiones.Count == 0)
                {
                    MessageBox.Show("No se pudieron cargar las comisiones.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                List<MateriaDTO> materias = await APIMateria.GetAllAsync();
                if(materias.Count == 0)
                {
                    MessageBox.Show("No se pudieron cargar las materias.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                dataGridViewCursos.ClearSelection();
                btnModificar.Enabled = false;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new CursoNuevoForm())
            {
                form.ShowDialog();
            }
            this.Show();
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
                
                if (curso == null)
                {
                    MessageBox.Show("No se pudo obtener el curso seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.Hide();
                using (var form = new CursoDetalleForm(curso))
                {
                    form.ShowDialog();
                }
                this.Show();
                await LoadCursos();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
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
                    MessageBox.Show("Curso eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCursos();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void DataGridViewCursos_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignorar clic en el header

            try
            {
                int id = (int)dataGridViewCursos.Rows[e.RowIndex].Cells["Id_curso"].Value;
                NewCursoDTO curso = await APICurso.GetAsync(id);
                
                if (curso == null)
                {
                    MessageBox.Show("No se pudo obtener el curso seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.Hide();
                using (var form = new CursoDetalleForm(curso))
                {
                    form.ShowDialog();
                }
                this.Show();
                await LoadCursos();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }
    }
}
