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
    public partial class MisMaterias : UserControl
    {
        private int _userId;
        private string _tipo = string.Empty;

        public MisMaterias()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            dataGridView = new DataGridView();
            actionButton = new Button();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Top;
            dataGridView.Height = 240;
            // 
            // actionButton
            // 
            actionButton.Text = "Acción";
            actionButton.Dock = DockStyle.Bottom;
            actionButton.Height = 36;

            Controls.Add(dataGridView);
            Controls.Add(actionButton);
            ResumeLayout(false);
        }

        private DataGridView dataGridView;
        private Button actionButton;

        public async Task LoadForUserAsync(int userId, string tipo)
        {
            _userId = userId;
            _tipo = tipo?.ToLowerInvariant() ?? string.Empty;

            if (_tipo == "profesor")
            {
                actionButton.BackColor = Color.LightSalmon;
                actionButton.Text = "Ver dictados";
                List<ShowProfesor_CursoDTO> items = await APIUsuario.GetProfesorCursosAsync(_userId);
                dataGridView.DataSource = items.Select(i => new {
                    i.IdDictado,
                    Curso = i.Curso != null ? $"{i.Curso.Id_curso} (M:{i.Curso.Id_materia}) C:{i.Curso.Id_comision}" : string.Empty,
                    Profesor = i.Profesor?.NombreUsuario,
                    i.Cargo
                }).ToList();
            }
            else if (_tipo == "alumno")
            {
                actionButton.BackColor = Color.LightSkyBlue;
                actionButton.Text = "Ver inscripciones";
                List<ShowAlumno_CursoDTO> items = await APIUsuario.GetAlumnoCursosAsync(_userId);
                dataGridView.DataSource = items.Select(i => new {
                    i.IdInscripcion,
                    Curso = i.Curso != null ? $"{i.Curso.Id_curso} (M:{i.Curso.Id_materia}) C:{i.Curso.Id_comision}" : string.Empty,
                    Alumno = i.Alumno?.NombreUsuario,
                    Condicion = i.Condicion,
                    Nota = i.Nota
                }).ToList();
            }
            else
            {
                actionButton.BackColor = SystemColors.Control;
                actionButton.Text = "No disponible";
                dataGridView.DataSource = null;
            }
        }
    }
}
