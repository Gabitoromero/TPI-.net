using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using API.Clients;
using Microsoft.AspNetCore.Http.Timeouts;

namespace WinFormsApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.VisibleChanged += LoginForm_VisibleChanged;
        }
        private void LoginForm_VisibleChanged(object? sender, EventArgs e)
        {
            if (this.Visible)
            {
                // Clear any previously entered credentials when the form becomes visible again
                textBoxUsername.Text = string.Empty;
                textBoxClave.Text = string.Empty;
                textBoxUsername.Focus();
            }
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBoxUsername.Text;
                string password = textBoxClave.Text;

                bool loginSuccess = await APIUsuario.LoginAsync(new LoginRequest { NombreUsuario = username, Clave = password });

                if (loginSuccess)
                {
                    string tipoUsuario = GetTipoUsuario();
                    if (tipoUsuario == "admin")
                    {
                        MenuForm form = new MenuForm();
                        Hide();
                        form.FormClosed += (s, args) =>
                        {
                            Show();
                        };
                        form.Show();

                    } 
                    else if (tipoUsuario == "alumno")
                    {
                        MenuAlumno form = new MenuAlumno();
                        Hide();
                        form.FormClosed += (s, args) =>
                        {
                            Show();
                        };
                        form.Show();

                    }

                }
                else
                {
                    MessageBox.Show("Datos inválidos, pruebe de nuevo.", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al loguearse: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void linkLabelRegistrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var registerForm = new RegisterForm(autoRegistro: true); // Indica que es autoregistro
                Hide();
                DialogResult result = registerForm.ShowDialog();
                
                if(result == DialogResult.OK)
                {
                    
                    // Registro exitoso, abrir MenuForm
                    var menuForm = new MenuForm();
                    menuForm.FormClosed += (s, args) =>
                    {
                        Show(); // Vuelve a mostrar login al cerrar menú
                    };
                    menuForm.Show();
                }
                else
                {
                    // Usuario canceló el registro, volver a mostrar login
                    Show();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario de registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Show();
            }
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
        private string GetTipoUsuario()
        {
            return APIUsuario.LoginResponse.Tipo;
        }
    }
}
