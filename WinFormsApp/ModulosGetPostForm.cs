using System;
using System.Collections.Generic;
using System.Windows.Forms;
using API.Entities;
using DTOs;

namespace WinFormsApp
{
    public partial class ModulosGetPostForm : Form
    {
        public ModulosGetPostForm()
        {
            InitializeComponent();
        }

        private async void buttonListarModulos_Click(object sender, EventArgs e)
        {
            try
            {
                List<ModuloDTO> modulos = await APIModulo.GetAllAsync();
                GridModulos.DataSource = modulos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar los módulos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonBuscarModulo_Click(object sender, EventArgs e)
        {
            try
            {
                ModuloDTO modulo = await APIModulo.GetAsync((int)numIDModulo.Value);

                if (modulo == null)
                {
                    throw new Exception("No se encontró el módulo con el ID especificado.");
                }

                GridModulo.SelectedObject = modulo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el módulo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonAgregarModulo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textDesc.Text))
                {
                    MessageBox.Show("La descripción del módulo no puede estar vacía.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ModuloDTO nuevoModulo = new ModuloDTO
                {
                    Descripcion = textDesc.Text
                };

                ModuloDTO moduloAñadido = await APIModulo.AddAsync(nuevoModulo);
                GridNuevoModulo.SelectedObject = moduloAñadido;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el módulo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}