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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnEspecialidadesCRUD_Click(object sender, EventArgs e)
        {
            try
            {
                EspecialidadForm espForm = new EspecialidadForm();
                espForm.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error al modificar especialidad: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModulosCRUD_Click(object sender, EventArgs e)
        {
            try
            {
                ModuloForm espForm = new ModuloForm();
                espForm.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error al modificar especialidad: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnPlanesCRUD_Click(object sender, EventArgs e)
        {
            try
            {
                PlanListaForm planListaForm = new PlanListaForm();
                planListaForm.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error al modificar plan: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
