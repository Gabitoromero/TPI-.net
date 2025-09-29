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
        public UsuarioList()
        {
            InitializeComponent();
        }

        public async void UsuarioList_Load(object sender, EventArgs e)
        {
            try
            {
                List<ShowUsuarioDTO> usuarios = await APIUsuario.GetAllAsync();
                dataGridViewUsuarios.DataSource = usuarios;
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error al cargar usuarios: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int idUser = (int)dataGridViewUsuarios.CurrentRow.Cells["Id"].Value;
                await APIUsuario.DeleteAsync(idUser);
                MessageBox.Show("Usuario eliminado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UsuarioList_Load(sender, e); // Recargar la lista de usuarios
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error al modificar usuario: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                UsuarioDetalle userDetailForm = new UsuarioDetalle(userToModify);
                userDetailForm.ShowDialog();
                UsuarioList_Load(sender, e); // Recargar la lista de usuarios después de modificar

            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
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
    }
}
