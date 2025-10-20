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
    public partial class MenuAlumno : Form
    {

        public MenuAlumno()
        {
            InitializeComponent();
            btnVerInscripciones.Click += btnVerInscripciones_Click;
        }

        private void btnVerInscripciones_Click(object? sender, EventArgs e)
        {
            this.Hide();
            using (var detalle = new InscripcionDetalle())
            {
                detalle.ShowDialog();
            }
            this.Show();
        }

        private void MenuAlumno_Load(object sender, EventArgs e)
        {
            // Puedes agregar lógica de inicialización si es necesario
        }
    }
}
