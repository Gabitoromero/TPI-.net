using DTOs;
using API.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class UsuarioDetalle : Form
    {
        private FullUsuarioDTO _user;
        public UsuarioDetalle(FullUsuarioDTO user)
        {
            InitializeComponent();
            _user = user;
        }
        public void UsuarioDetalle_Load(object sender, EventArgs e)
        {
            textBoxId.Text = _user.Id.ToString();
            textBoxEmail.Text = _user.Email;
            textBoxNomUsuario.Text = _user.NombreUsuario;
            textBoxNombre.Text = _user.Nombre;
            textBoxApellido.Text = _user.Apellido;
            textBoxClave.Text = _user.Clave;
            checkBoxHabilitado.Checked = _user.Habilitado;
        }
        public async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBoxNombre.Text == null)
                {
                    throw new Exception("El nombre no puede estar vacío");
                }else{
                    _user.Nombre = textBoxNombre.Text;
                }
                if(textBoxEmail.Text == null)
                {
                    throw new Exception("El email no puede estar vacío");
                }else{
                    _user.Email = textBoxEmail.Text;
                }
                if(textBoxNomUsuario.Text == null)
                {
                    throw new Exception("El nombre de usuario no puede estar vacío");
                }else { 
                    _user.NombreUsuario = textBoxNomUsuario.Text;
                }
                if (textBoxApellido.Text == null)
                {
                    throw new Exception("El apellido no puede estar vacío");
                }else{
                    textBoxApellido.Text = _user.Apellido;
                }
                if(textBoxClave.Text == null)
                {
                  throw new Exception("La clave no puede estar vacía");
                }else{
                    _user.Clave = textBoxClave.Text;
                }
                _user.Habilitado = checkBoxHabilitado.Checked;
                PutUsuarioDTO putUsuarioDTO = new PutUsuarioDTO
                {
                    Id = _user.Id,
                    Nombre = _user.Nombre,
                    Apellido = _user.Apellido,
                    NombreUsuario = _user.NombreUsuario,
                    Email = _user.Email,
                    Clave = _user.Clave,
                    Habilitado = _user.Habilitado
                };
                await APIUsuario.UpdateAsync(putUsuarioDTO);
                MessageBox.Show("Usuario modificado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error al modificar usuario: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
