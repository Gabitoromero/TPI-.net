using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;

namespace WinFormsApp
{
    public partial class MateriaListaForm : Form
    {
        public MateriaListaForm()
        {
            InitializeComponent();
        }

        public async void MateriaListaForm_Load(object sender, EventArgs e)
        {
            await LoadMaterias();
        }

        private async Task LoadMaterias()
        {
            try
            {
                List<MateriaDTO> list = await APIMateria.GetAllAsync();
                dataGridViewMaterias.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar materias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MateriaDetalleForm form = new MateriaDetalleForm();
            form.ShowDialog();
            _ = LoadMaterias();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewMaterias.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una materia para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int id = (int)dataGridViewMaterias.CurrentRow.Cells["Id_materia"].Value;
                MateriaDTO dto = await APIMateria.GetAsync(id);
                MateriaDetalleForm form = new MateriaDetalleForm(dto);
                form.ShowDialog();
                await LoadMaterias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar materia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewMaterias.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una materia para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = (int)dataGridViewMaterias.CurrentRow.Cells["Id_materia"].Value;
                string descripcionMateria = dataGridViewMaterias.CurrentRow.Cells["Desc_materia"].Value?.ToString() ?? "esta materia";

                // Mostrar mensaje de confirmación
                DialogResult confirmResult = MessageBox.Show(
                    $"¿Está seguro que desea eliminar la materia '{descripcionMateria}'?\n\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // Solo eliminar si el usuario confirma
                if (confirmResult == DialogResult.Yes)
                {
                    await APIMateria.DeleteAsync(id);
                    MessageBox.Show("Materia eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadMaterias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar materia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
