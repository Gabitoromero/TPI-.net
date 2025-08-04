using DTOs;
using API.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WinFormsApp
{
    public partial class UsuarioDeletePutForm : Form
    {
        public UsuarioDeletePutForm()
        {
            InitializeComponent();
        }

        private void UsuarioDeletePutForm_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e) { }

        private void labNombre_Click(object sender, EventArgs e)
        {

        }

        private async void btnListarUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                List < ShowUsuarioDTO > usuarios = await APIUsuario.GetAllAsync();
                gridUsers.DataSource = usuarios;

            }
            catch (Exception ex)
            {
                MessageBox.Show("OOPS! An error occurred while listing users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxIdUser_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxIdUser.Text))
                {
                    MessageBox.Show("Please select a user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                PutUsuarioDTO updatedUser = new PutUsuarioDTO();
                
                if (textBoxApellido.Text != null) { updatedUser.Apellido = textBoxApellido.Text; }
                if (textBoxNom.Text != null) { updatedUser.Nombre = textBoxNom.Text; }
                if(textBoxNomUser.Text!= null) { updatedUser.NombreUsuario = textBoxNomUser.Text;}
                if (textBoxEmail.Text != null) { updatedUser.Email = textBoxEmail.Text; }
                if (textBoxContr.Text!= null) {updatedUser.Clave = textBoxContr.Text;}
                if (checkBoxHabilitado.Checked != null) { updatedUser.Habilitado = checkBoxHabilitado.Checked; }


                var response = await APIUsuario.UpdateAsync(updatedUser);
                btnListarUsuarios_Click(sender, e);
                MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("OOPS! An error occurred while updating the user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void btnEliminarUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxIdUser.Text))
                {
                    MessageBox.Show("Please select a user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int userId = int.Parse(textBoxIdUser.Text);
                await APIUsuario.DeleteAsync(userId);
                MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("OOPS! An error occurred while deleting the user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void GridUsers_SelectionChanged(object sender, EventArgs e)
        {
            
                if(gridUsers.CurrentRow != null)
                {
                    ShowUsuarioDTO user = (ShowUsuarioDTO)gridUsers.CurrentRow.DataBoundItem;
                    textBoxIdUser.Text = user.Id.ToString();
                    textBoxNomUser.Text = user.NombreUsuario;                  
                    textBoxEmail.Text = user.Email;
                    

                }
                
            
        }
    }
}
