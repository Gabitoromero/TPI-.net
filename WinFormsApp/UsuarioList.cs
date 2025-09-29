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

            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }
    }
}
