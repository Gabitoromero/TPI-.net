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

namespace WinFormsApp
{
    public partial class AlumnoCursoPutForm : Form
    {
        private ShowAlumno_CursoDTO alumnoOriginal;

        public AlumnoCursoPutForm(ShowAlumno_CursoDTO alumno)
        {
            InitializeComponent();
            alumnoOriginal = alumno;
            Load += AlumnoCursoPutForm_Load;
            btnVolver.Click += BtnVolver_Click;
            btnGuardar.Click += BtnGuardar_Click;
            comboBoxCondicion.SelectedIndexChanged += ComboBoxCondicion_SelectedIndexChanged;
        }

        private void AlumnoCursoPutForm_Load(object? sender, EventArgs e)
        {
            try
            {
                comboBoxCondicion.Items.Clear();
                comboBoxCondicion.Items.AddRange(new string[] { "Inscripto", "Regular", "Libre", "Aprobado" });

                comboBoxCondicion.SelectedItem = alumnoOriginal.Condicion;

                if (alumnoOriginal.Condicion == "Aprobado" && alumnoOriginal.Nota.HasValue)
                {
                    numericNota.Value = alumnoOriginal.Nota.Value;
                    label2.Visible = true;
                    numericNota.Visible = true;
                }
                else
                {
                    label2.Visible = false;
                    numericNota.Visible = false;
                }

                Text = $"Alumno: {alumnoOriginal.Alumno.NombreUsuario}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxCondicion_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboBoxCondicion.SelectedItem?.ToString() == "Aprobado")
            {
                label2.Visible = true;
                numericNota.Visible = true;
            }
            else
            {
                label2.Visible = false;
                numericNota.Visible = false;
            }
        }

        private void BtnVolver_Click(object? sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void BtnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                string nuevaCondicion = comboBoxCondicion.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(nuevaCondicion))
                {
                    MessageBox.Show("Debe seleccionar una condición.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nuevaCondicion == "Inscripto")
                {
                    MessageBox.Show("No se puede cambiar la condición a 'Inscripto'. Solo puede seleccionar: Regular, Libre o Aprobado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Alumno_CursoDTO dto = new Alumno_CursoDTO
                {
                    IdInscripcion = alumnoOriginal.IdInscripcion,
                    IdAlumno = alumnoOriginal.Alumno.Id,
                    IdCurso = alumnoOriginal.Curso.Id_curso,
                    Condicion = nuevaCondicion,
                    Nota = nuevaCondicion == "Aprobado" ? (int?)numericNota.Value : null
                };

                // Enviar la actualización al servidor
                await APIUsuario.PutAlumnoCursoAsync(dto);

                MessageBox.Show("Alumno actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
