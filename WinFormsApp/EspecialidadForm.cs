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
using Domain.Model;

namespace WinFormsApp
{
    public partial class EspecialidadForm : Form
    {
        public EspecialidadForm()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
         
            
        }
        private async void btnListarEsp_Click(object sender, EventArgs e)
        {
            try
            {
                var especialidades = await APIEspecialidad.GetAllAsync();
                gridEsp.DataSource = especialidades;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener especialidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnMostrarUnaEsp_Click(object sender, EventArgs e)
        {
            try
            {

                EspecialidadDTO esp = await APIEspecialidad.GetAsync((int)numUpDownEsp.Value);
                // Si el servicio devolvió null (o no existe), limpiamos la property grid
                if (esp == null)
                {
                    gridUnicaEsp.SelectedObject = null;
                    gridUnicaEsp.Refresh();
                    MessageBox.Show($"La especialidad con Id {numUpDownEsp} no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                gridUnicaEsp.SelectedObject = esp;
                
            }
            catch (Exception err)
            {
                // Si ocurre cualquier error (por ejemplo 404 desde el API), limpiamos la property grid
                gridUnicaEsp.SelectedObject = null;
                gridUnicaEsp.Refresh();
                MessageBox.Show($"Error al obtener especialidades: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private async void btnAddEsp_Click(object sender, EventArgs e)
        {
            try
            {
                var formPostEsp = new EspecialidadPostForm();
                formPostEsp.ShowDialog();
                this.btnListarEsp_Click(sender, e); // Actualizar la lista de especialidades después de cerrar el formulario
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void labelDescripcion_Click(object sender, EventArgs e)
        {

        }

        private async void btnModificarEspecialidad_Click(object sender, EventArgs e)
        {
            try
            {
                int idEsp = (int)numUpDownEsp.Value;
                EspecialidadDTO esp = await APIEspecialidad.GetAsync(idEsp);
                if (esp != null)
                {
                    var formPUTDELEsp = new EspecialidadDeletePutForm(idEsp);
                    formPUTDELEsp.ShowDialog();
                }

                this.btnListarEsp_Click(sender, e); // Actualizar la lista de especialidades después de cerrar el formulario
                this.btnMostrarUnaEsp_Click(sender, e); // Actualizar la especialidad mostrada después de cerrar el formulario
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
