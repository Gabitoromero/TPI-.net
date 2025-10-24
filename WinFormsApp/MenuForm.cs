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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void Menu_Load(object? sender, EventArgs e)
        {
           
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error al cerrar sesión: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnModulosCRUD_Click(object sender, EventArgs e)
        {
            try
            {
                MateriaListaForm matForm = new MateriaListaForm();
                matForm.ShowDialog();
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
        private void btnEspecialidadesCRUD_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                using (var espForm = new EspecialidadListaForm())
                {
                    espForm.ShowDialog();
                }
                this.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error al abrir especialidades: {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show(); // Asegurar que se muestre incluso si hay error
            }
        }
        private void btnUsuariosCRUD_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioList formuser = new UsuarioList();
                formuser.ShowDialog();

            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }

        }
        private void btnCursos_Click(object sender, EventArgs e)
        {
            try
            {
                CursoListaForm curForm = new CursoListaForm();
                curForm.ShowDialog();
            }
            catch (Exception err)
            {
                throw new ArgumentException(err.Message);
            }
        }
        private void btnComisiones_Click(object sender, EventArgs e)
        {
            try
            {
                ComisionListaForm comForm = new ComisionListaForm();
                comForm.ShowDialog();
            }
            catch (ArgumentException err)
            {
                throw new ArgumentException(err.Message);
            }
        }
    }
}
