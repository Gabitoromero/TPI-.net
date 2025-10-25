using API.Clients;
using Domain.Model;
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
    public partial class CursoNuevoForm : Form
    {
        public CursoNuevoForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void CursoNuevoForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<ComisionDTO> comisiones = await APIComision.GetAllAsync();
                if (comisiones.Count == 0)
                {
                    MessageBox.Show("No se pudieron cargar las comisiones.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                comboBoxComision.DataSource = comisiones;
                comboBoxComision.DisplayMember = "Desc_comision";
                comboBoxComision.ValueMember = "Id_comision";

                List<MateriaDTO> materias = await APIMateria.GetAllAsync();
                if (materias.Count == 0)
                {
                    MessageBox.Show("No se pudieron cargar las materias.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                comboBoxMaterias.DataSource = materias;
                comboBoxMaterias.DisplayMember = "Desc_materia";
                comboBoxMaterias.ValueMember = "Id_materia";
                
                numericAnio.Maximum = 2100;
                int anioActual = DateTime.Now.Year;
                numericAnio.Value = anioActual;
                numericCupo.Value = 0;
                comboBoxComision.SelectedIndex = -1;
                comboBoxMaterias.SelectedIndex = -1;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                NewCursoDTO dto = new NewCursoDTO
                {
                    Id_curso = 0,
                    Anio_calendario = (int)numericAnio.Value,
                    Cupo = (int)numericCupo.Value,
                    Id_comision = comboBoxComision.SelectedValue != null ? (int)comboBoxComision.SelectedValue : 0,
                    Id_materia = comboBoxMaterias.SelectedValue != null ? (int)comboBoxMaterias.SelectedValue : 0
                };

                await APICurso.AddAsync(dto);
                MessageBox.Show("Curso agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
