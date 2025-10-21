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
        }

        private void btnVerInscripciones_Click_2(object? sender, EventArgs e)
        {
            this.Hide();
            using (var detalle = new InscripcionDetalle())
            {
                detalle.ShowDialog();
            }
            this.Show();
        }

        private void btnNuevaInscripcion_Click(object? sender, EventArgs e)
        {
            this.Hide();
            using (var nuevaInscripcion = new InscripcionNueva())
            {
                DialogResult result = nuevaInscripcion.ShowDialog();
                // Si la inscripción fue exitosa, podrías actualizar algo o mostrar un mensaje adicional
            }
            this.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuAlumno_Load(object sender, EventArgs e)
        {
            // Puedes agregar lógica de inicialización si es necesario
        }
    }
}
