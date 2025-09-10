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
            /*try
            {
                var especialidades = await APIEspecialidad.GetAllAsync();
            }*/
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
                if (esp != null)
                {
                    gridUnicaEsp.SelectedObject = esp;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error al obtener especialidades: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private async void btnAddEsp_Click(object sender, EventArgs e)
        {
            try
            {
                NewEspecialidadDTO nuevaEsp = new NewEspecialidadDTO();
                nuevaEsp.Descripcion = txtDesc.Text;
                if (string.IsNullOrWhiteSpace(nuevaEsp.Descripcion))
                {
                    MessageBox.Show("La descripción no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                EspecialidadDTO espAdded = await APIEspecialidad.AddAsync(nuevaEsp);
                gridNuevaEsp.SelectedObject = espAdded;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelDescripcion_Click(object sender, EventArgs e)
        {

        }
    }
}
