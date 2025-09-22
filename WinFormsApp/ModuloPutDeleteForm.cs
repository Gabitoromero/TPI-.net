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
    public partial class ModuloPutDeleteForm : Form
    {
        private int _id;
        public ModuloPutDeleteForm(int id)
        {
            InitializeComponent();
            _id = id;
        }
        public async void ModuloPutDeleteForm_Load(object sender, EventArgs e)
        {
            try
            {
                ModuloDTO moduloDTO = await APIModulo.GetAsync(_id);
                if (moduloDTO != null)
                {

                    txtBoxNuevaDescripcion.Text = moduloDTO.Descripcion;
                    txtBoxNuevaDescripcion.Enabled = true;

                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error al obtener módulos: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                APIModulo.DeleteAsync(_id);
            }
            finally
            {
                MessageBox.Show("Modulo eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private async void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                ModuloDTO modificado = await APIModulo.GetAsync(_id);
                if(modificado != null)
                {
                    
                    if (string.IsNullOrWhiteSpace(modificado.Descripcion))
                    {
                        MessageBox.Show("La descripción no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    modificado.Descripcion = txtBoxNuevaDescripcion.Text;
                    ModuloDTO moduloUpdated = await APIModulo.UpdateAsync(modificado);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar módulo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("Módulo modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
