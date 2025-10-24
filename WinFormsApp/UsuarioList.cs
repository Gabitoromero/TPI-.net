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
        private string? activeFilter = null; // null = all, "alumno" or "profesor"
        public UsuarioList()
        {
            InitializeComponent();
        }

        public async void UsuarioList_Load(object sender, EventArgs e)
        {
            try
            {
                await ApplyFilterAsync(null); // load all and update UI
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error al cargar usuarios: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // If DTO has Tipo property but column not auto-generated yet, force refresh
                dataGridViewUsuarios.Refresh();
            }
        }

        private void UpdateFilterButtonsAppearance()
        {
            // Reset to default
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
            // Toggle behavior: if tipo equals activeFilter, clear filter (show all)
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

                // Mostrar mensaje de confirmación
                DialogResult confirmResult = MessageBox.Show(
                    $"¿Está seguro que desea eliminar al usuario '{nombreUsuario}'?\n\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // Solo eliminar si el usuario confirma
                if (confirmResult == DialogResult.Yes)
                {
                    await APIUsuario.DeleteAsync(idUser);
                    MessageBox.Show("Usuario eliminado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UsuarioList_Load(sender, e); // Recargar la lista de usuarios
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error al eliminar usuario: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error al cargar alumnos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error al cargar profesores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                UsuarioList_Load(sender, e); // Recargar la lista de usuarios después de modificar
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error al modificar usuario: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error al buscar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    UsuarioList_Load(sender, new EventArgs()); // Recargar la lista de usuarios después de agregar uno nuevo
                }
            }
            this.Show();
        }
    }
}
