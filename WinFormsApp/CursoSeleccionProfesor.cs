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
    public partial class CursoSeleccionProfesor : Form
    {
        private int idCurso;
        private int idProfesorSeleccionado;
        public bool ProfesorAgregado { get; private set; }

        public CursoSeleccionProfesor(int idCurso)
        {
            InitializeComponent();
            this.idCurso = idCurso;
            this.ProfesorAgregado = false;
            dataGridProfesores.CellDoubleClick += DataGridProfesores_CellDoubleClick;
        }

        private async void CursoSeleccionProfesor_Load(object sender, EventArgs e)
        {
            await LoadProfesores();
            checkBoxTitular.Checked = false;
            btnAgregar.Enabled = false;
        }

        private async Task LoadProfesores()
        {
            try
            {
                var profesores = await APIUsuario.GetProfesoresAsync();

                dataGridProfesores.DataSource = null;
                dataGridProfesores.DataSource = profesores;

                // Configurar headers
                if (dataGridProfesores.Columns["Id"] != null)
                    dataGridProfesores.Columns["Id"].HeaderText = "ID";

                if (dataGridProfesores.Columns["NombreUsuario"] != null)
                    dataGridProfesores.Columns["NombreUsuario"].HeaderText = "Usuario";

                if (dataGridProfesores.Columns["Email"] != null)
                    dataGridProfesores.Columns["Email"].HeaderText = "Email";

                if (dataGridProfesores.Columns["Tipo"] != null)
                    dataGridProfesores.Columns["Tipo"].HeaderText = "Tipo";

                dataGridProfesores.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar profesores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridProfesores_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; 

            try
            {
                idProfesorSeleccionado = (int)dataGridProfesores.Rows[e.RowIndex].Cells["Id"].Value;
                
                dataGridProfesores.ClearSelection();
                dataGridProfesores.Rows[e.RowIndex].Selected = true;
                
                btnAgregar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar profesor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAgregar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (idProfesorSeleccionado == 0)
                {
                    MessageBox.Show("Seleccione un profesor haciendo doble clic en la fila.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string cargo = checkBoxTitular.Checked ? "Titular" : "Auxiliar";
                string nombreProfesor = dataGridProfesores.SelectedRows.Count > 0 ? dataGridProfesores.SelectedRows[0].Cells["NombreUsuario"].Value?.ToString() ?? "este profesor" : "este profesor";
              
                DialogResult confirmResult = MessageBox.Show($"¿Está seguro que desea agregar al profesor '{nombreProfesor}' al curso?\n\nCargo: {cargo}","Confirmar Asignación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    Profesor_CursoDTO dto = new Profesor_CursoDTO
                    {
                        IdDictado = 0, 
                        IdProfesor = idProfesorSeleccionado,
                        IdCurso = idCurso,
                        Cargo = cargo
                    };

                    await APIUsuario.AddProfesorCursoAsync(dto);
                    MessageBox.Show("Profesor agregado correctamente al curso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    ProfesorAgregado = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar profesor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Operación cancelada.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
