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
    public partial class MenuProfesor : Form
    {
        public MenuProfesor()
        {
            InitializeComponent();
        }

        private void btnVerCursos_Click(object? sender, EventArgs e)
        {
            this.Hide();
            using (var detalle = new ProfesorCursosDetalle())
            {
                detalle.ShowDialog();
            }
            this.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuProfesor_Load(object sender, EventArgs e)
        {
            // Puedes agregar lógica de inicialización si es necesario
        }
    }
}
