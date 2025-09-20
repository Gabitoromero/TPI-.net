using API.Entities;
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

namespace WinFormsApp
{
    public partial class EspecialidadDeletePutForm : Form
    {
        private int _idEsp;
        public EspecialidadDeletePutForm(int idEsp)
        {
            InitializeComponent();
            _idEsp = idEsp;
        }

        private async void EspecialidadDeletePutForm_Load(object sender, EventArgs e)
        {
            try
            {
                EspecialidadDTO esp = await APIEspecialidad.GetAsync(_idEsp);
                if (esp != null)
                {
                    txtBoxDesc.Text = esp.Descripcion;
                    txtBoxDesc.Enabled = true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error al obtener especialidades: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarEsp_Click(object sender, EventArgs e)
        {
            try
            {
                APIEspecialidad.DeleteAsync(_idEsp);
            }
            finally
            {
                MessageBox.Show("Especialidad eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private async void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                EspecialidadDTO espToUpdate = new EspecialidadDTO
                {
                    Id = _idEsp,
                    Descripcion = txtBoxDesc.Text
                };
                if (string.IsNullOrWhiteSpace(espToUpdate.Descripcion))
                {
                    MessageBox.Show("La descripción no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var updatedEsp = await APIEspecialidad.PutAsync(espToUpdate);
                    if (updatedEsp != null)
                    {
                        MessageBox.Show("Especialidad actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la especialidad para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
