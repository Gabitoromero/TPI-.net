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
                comboBoxCondicion.Items.AddRange(new string[] { "Inscripto", "Regular", "Libre", "Aprobado", "Reprobado" });

                comboBoxCondicion.SelectedItem = alumnoOriginal.Condicion;

                label2.Visible = false;
                numericNota.Visible = false;

                if (comboBoxCondicion.SelectedItem?.ToString() == "Aprobado")
                {
                    label2.Visible = true;
                    numericNota.Visible = true;
                    numericNota.Minimum = 6;
                    numericNota.Maximum = 10;
                    if (alumnoOriginal.Nota.HasValue)
                    {
                        numericNota.Value = alumnoOriginal.Nota.Value;
                    }
                    else
                    {
                        numericNota.Value = 6;
                    }
                }

                if (comboBoxCondicion.SelectedItem?.ToString() == "Reprobado")
                {
                    label2.Visible = true;
                    numericNota.Visible = true;
                    numericNota.Minimum = 1;
                    numericNota.Maximum = 5;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxCondicion_SelectedIndexChanged(object? sender, EventArgs e)
        {
            label2.Visible = false;
            numericNota.Visible = false;

            if (comboBoxCondicion.SelectedItem?.ToString() == "Aprobado")
            {
                label2.Visible = true;
                numericNota.Visible = true;
                numericNota.Minimum = 6;
                numericNota.Maximum = 10;
            }

            if (comboBoxCondicion.SelectedItem?.ToString() == "Reprobado")
            {
                label2.Visible = true;
                numericNota.Visible = true;
                numericNota.Minimum = 1;
                numericNota.Maximum = 5;
            }
        }

        private void BtnVolver_Click(object? sender, EventArgs e)
        {
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
                    Nota = (nuevaCondicion == "Aprobado" || nuevaCondicion == "Reprobado") ? (int?)numericNota.Value : null
                };

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

        private void comboBoxCondicion_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (alumnoOriginal.Condicion == "Aprobado")
            {
                label2.Visible = true;
                numericNota.Visible = true;
                numericNota.Minimum = 6;
                numericNota.Maximum = 10;
                if (alumnoOriginal.Nota.HasValue)
                {
                    numericNota.Value = alumnoOriginal.Nota.Value;
                }
                else
                {
                    numericNota.Value = 6;
                }
            }

            if (alumnoOriginal.Condicion == "Reprobado")
            {
                label2.Visible = true;
                numericNota.Visible = true;
                numericNota.Minimum = 1;
                numericNota.Maximum = 5;
            }
            else
            {
                label2.Visible = false;
                numericNota.Visible = false;
            }
        }
    }
}
