using DTOs;
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

namespace WinFormsApp
{
    public partial class UsuarioList : Form
    {
        private string? activeFilter = null;

        public UsuarioList()
        {
            InitializeComponent();
            dataGridViewUsuarios.SelectionChanged += DataGridViewUsuarios_SelectionChanged;
        }

        private void DataGridViewUsuarios_SelectionChanged(object? sender, EventArgs e)
        {
            bool haySeleccion = dataGridViewUsuarios.SelectedRows.Count > 0 && dataGridViewUsuarios.CurrentRow != null;
            btnModificar.Enabled = haySeleccion;
            btnEliminar.Enabled = haySeleccion;
        }

        public async void UsuarioList_Load(object sender, EventArgs e)
        {
            try
            {
                await ApplyFilterAsync(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadAllUsersAsync()
        {
            List<ShowUsuarioDTO> usuarios = await APIUsuario.GetAllAsync();
            dataGridViewUsuarios.DataSource = usuarios;
            EnsureTipoColumnVisible();
        }

        private async Task LoadProfesoresAsync()
        {
            List<ShowUsuarioDTO> usuarios = await APIUsuario.GetProfesoresAsync();
            dataGridViewUsuarios.DataSource = usuarios;
            EnsureTipoColumnVisible();
        }

        private async Task LoadAlumnosAsync()
        {
            List<ShowUsuarioDTO> usuarios = await APIUsuario.GetAlumnosAsync();
            dataGridViewUsuarios.DataSource = usuarios;
            EnsureTipoColumnVisible();
        }

        private void EnsureTipoColumnVisible()
        {
            if (dataGridViewUsuarios.Columns.Contains("Tipo"))
            {
                dataGridViewUsuarios.Columns["Tipo"].Visible = true;
            }
            else
            {
                dataGridViewUsuarios.Refresh();
            }
        }

        private void UpdateFilterButtonsAppearance()
        {
            btnAlumnos.UseVisualStyleBackColor = false;
            btnProfesores.UseVisualStyleBackColor = false;

            if (activeFilter == "alumno")
            {
                btnAlumnos.BackColor = Color.DimGray;
                btnAlumnos.ForeColor = Color.White;
                btnProfesores.BackColor = SystemColors.Control;
                btnProfesores.ForeColor = SystemColors.ControlText;
            }
            else if (activeFilter == "profesor")
            {
                btnProfesores.BackColor = Color.DimGray;
                btnProfesores.ForeColor = Color.White;
                btnAlumnos.BackColor = SystemColors.Control;
                btnAlumnos.ForeColor = SystemColors.ControlText;
            }
            else
            {
                btnAlumnos.BackColor = SystemColors.Control;
                btnAlumnos.ForeColor = SystemColors.ControlText;
                btnProfesores.BackColor = SystemColors.Control;
                btnProfesores.ForeColor = SystemColors.ControlText;
            }
        }

        private async Task ApplyFilterAsync(string? tipo)
        {
            if (tipo != null && activeFilter == tipo)
            {
                tipo = null;
            }

            if (tipo == null)
            {
                await LoadAllUsersAsync();
            }
            else if (tipo == "alumno")
            {
                await LoadAlumnosAsync();
            }
            else if (tipo == "profesor")
            {
                await LoadProfesoresAsync();
            }

            activeFilter = tipo;
            UpdateFilterButtonsAppearance();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int idUser = (int)dataGridViewUsuarios.CurrentRow.Cells["Id"].Value;
                string nombreUsuario = dataGridViewUsuarios.CurrentRow.Cells["NombreUsuario"].Value?.ToString() ?? "este usuario";

                DialogResult confirmResult = MessageBox.Show(
                    $"¿Está seguro que desea eliminar al usuario '{nombreUsuario}'?\n\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    await APIUsuario.DeleteAsync(idUser);
                    MessageBox.Show("Usuario eliminado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UsuarioList_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAlumnos_Click(object sender, EventArgs e)
        {
            try
            {
                await ApplyFilterAsync("alumno");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnProfesores_Click(object sender, EventArgs e)
        {
            try
            {
                await ApplyFilterAsync("profesor");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int idUser = (int)dataGridViewUsuarios.CurrentRow.Cells["Id"].Value;
                FullUsuarioDTO userToModify = await APIUsuario.GetAsync(idUser);
                
                this.Hide();
                using (var userDetailForm = new UsuarioDetalle(userToModify))
                {
                    userDetailForm.ShowDialog();
                }
                this.Show();
                UsuarioList_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nomBuscado = textBoxBuscador.Text?.Trim();
                if (string.IsNullOrEmpty(nomBuscado))
                {
                    MessageBox.Show("Ingrese el nombre a buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dataGridViewUsuarios.Rows.Count == 0)
                {
                    MessageBox.Show("No hay usuarios para buscar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dataGridViewUsuarios.ClearSelection();

                bool encontrado = false;
                foreach (DataGridViewRow row in dataGridViewUsuarios.Rows)
                {
                    if (row.IsNewRow) continue;
                    string? nombreFila = null;
                    if (dataGridViewUsuarios.Columns.Contains("NombreUsuario"))
                    {
                        nombreFila = row.Cells["NombreUsuario"].Value?.ToString();
                    }
                    else
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            var val = row.Cells[i].Value?.ToString();
                            if (!string.IsNullOrEmpty(val) && val.Equals(nomBuscado, StringComparison.OrdinalIgnoreCase))
                            {
                                nombreFila = val;
                                break;
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(nombreFila) && nombreFila.IndexOf(nomBuscado, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        row.Selected = true;
                        dataGridViewUsuarios.CurrentCell = row.Cells[0];
                        dataGridViewUsuarios.FirstDisplayedScrollingRowIndex = row.Index;
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    MessageBox.Show("No se encontró ningún usuario con ese nombre.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoProfesional_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var registForm = new RegisterForm(autoRegistro: false))
            {
                DialogResult result = registForm.ShowDialog();
                
                if (result == DialogResult.OK)
                {
                    UsuarioList_Load(sender, new EventArgs());
                }
            }
            this.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
