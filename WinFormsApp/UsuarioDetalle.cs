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
            checkBoxHabilitado.Checked = _user.Habilitado;
            textBoxFechaAlta.Text = _user.FechaAlta.ToString();
        }
        public void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
                {
                    throw new Exception("El nombre no puede estar vacío");
                }
                _user.Nombre = textBoxNombre.Text.Trim();

                if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
                {
                    throw new Exception("El email no puede estar vacío");
                }
                _user.Email = textBoxEmail.Text.Trim();

                if (string.IsNullOrWhiteSpace(textBoxNomUsuario.Text))
                {
                    throw new Exception("El nombre de usuario no puede estar vacío");
                }
                _user.NombreUsuario = textBoxNomUsuario.Text.Trim();

                if (string.IsNullOrWhiteSpace(textBoxApellido.Text))
                {
                    throw new Exception("El apellido no puede estar vacío");
                }
                _user.Apellido = textBoxApellido.Text.Trim(); 

                _user.Habilitado = checkBoxHabilitado.Checked;

               
                PutUsuarioDTO putUsuarioDTO = new PutUsuarioDTO
                {
                    Id = _user.Id,
                    Nombre = _user.Nombre,
                    Apellido = _user.Apellido,
                    NombreUsuario = _user.NombreUsuario,
                    Email = _user.Email,
                    Clave = _user.Clave,
                    Habilitado = _user.Habilitado,
                    IdPlan = _user.IdPlan
                };
                APIUsuario.UpdateAsync(putUsuarioDTO);
                MessageBox.Show("Usuario modificado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
