namespace WinFormsApp
{
    partial class CursoDetalleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelAnio = new Label();
            numericAnio = new NumericUpDown();
            labelCupo = new Label();
            numericCupo = new NumericUpDown();
            btnGuardar = new Button();
            btnCancelar = new Button();
            labelComision = new Label();
            comboBoxComision = new ComboBox();
            labelMateria = new Label();
            comboBoxMateria = new ComboBox();
            dataGridAlumnosCurso = new DataGridView();
            dataGridProfesoresCurso = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            btnEliminarAlumnoCurso = new Button();
            btnAgregarProfesorCurso = new Button();
            btnEliminarProfesorCurso = new Button();
            btnModificarCurso = new Button();
            ((System.ComponentModel.ISupportInitialize)numericAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCupo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridAlumnosCurso).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProfesoresCurso).BeginInit();
            SuspendLayout();
            // 
            // labelAnio
            // 
            labelAnio.AutoSize = true;
            labelAnio.Location = new Point(427, 21);
            labelAnio.Name = "labelAnio";
            labelAnio.Size = new Size(90, 15);
            labelAnio.TabIndex = 2;
            labelAnio.Text = "Año calendario:";
            // 
            // numericAnio
            // 
            numericAnio.Enabled = false;
            numericAnio.Location = new Point(523, 18);
            numericAnio.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericAnio.Name = "numericAnio";
            numericAnio.Size = new Size(64, 23);
            numericAnio.TabIndex = 3;
            // 
            // labelCupo
            // 
            labelCupo.AutoSize = true;
            labelCupo.Location = new Point(621, 21);
            labelCupo.Name = "labelCupo";
            labelCupo.Size = new Size(39, 15);
            labelCupo.TabIndex = 4;
            labelCupo.Text = "Cupo:";
            // 
            // numericCupo
            // 
            numericCupo.Enabled = false;
            numericCupo.Location = new Point(675, 18);
            numericCupo.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericCupo.Name = "numericCupo";
            numericCupo.Size = new Size(43, 23);
            numericCupo.TabIndex = 5;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.MediumSeaGreen;
            btnGuardar.Location = new Point(643, 261);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.Control;
            btnCancelar.Location = new Point(22, 261);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // labelComision
            // 
            labelComision.AutoSize = true;
            labelComision.Location = new Point(204, 21);
            labelComision.Name = "labelComision";
            labelComision.Size = new Size(61, 15);
            labelComision.TabIndex = 8;
            labelComision.Text = "Comisión:";
            // 
            // comboBoxComision
            // 
            comboBoxComision.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxComision.Enabled = false;
            comboBoxComision.Location = new Point(271, 18);
            comboBoxComision.Name = "comboBoxComision";
            comboBoxComision.Size = new Size(120, 23);
            comboBoxComision.TabIndex = 9;
            // 
            // labelMateria
            // 
            labelMateria.AutoSize = true;
            labelMateria.Location = new Point(22, 21);
            labelMateria.Name = "labelMateria";
            labelMateria.Size = new Size(50, 15);
            labelMateria.TabIndex = 10;
            labelMateria.Text = "Materia:";
            // 
            // comboBoxMateria
            // 
            comboBoxMateria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMateria.Enabled = false;
            comboBoxMateria.Location = new Point(78, 18);
            comboBoxMateria.Name = "comboBoxMateria";
            comboBoxMateria.Size = new Size(120, 23);
            comboBoxMateria.TabIndex = 11;
            // 
            // dataGridAlumnosCurso
            // 
            dataGridAlumnosCurso.AllowUserToAddRows = false;
            dataGridAlumnosCurso.AllowUserToDeleteRows = false;
            dataGridAlumnosCurso.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridAlumnosCurso.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridAlumnosCurso.Location = new Point(22, 92);
            dataGridAlumnosCurso.Name = "dataGridAlumnosCurso";
            dataGridAlumnosCurso.ReadOnly = true;
            dataGridAlumnosCurso.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridAlumnosCurso.Size = new Size(323, 150);
            dataGridAlumnosCurso.TabIndex = 12;
            // 
            // dataGridProfesoresCurso
            // 
            dataGridProfesoresCurso.AllowUserToAddRows = false;
            dataGridProfesoresCurso.AllowUserToDeleteRows = false;
            dataGridProfesoresCurso.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProfesoresCurso.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProfesoresCurso.Location = new Point(389, 92);
            dataGridProfesoresCurso.Name = "dataGridProfesoresCurso";
            dataGridProfesoresCurso.ReadOnly = true;
            dataGridProfesoresCurso.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProfesoresCurso.Size = new Size(329, 150);
            dataGridProfesoresCurso.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 64);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 14;
            label1.Text = "Alumnos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(387, 64);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 15;
            label2.Text = "Profesores";
            // 
            // btnEliminarAlumnoCurso
            // 
            btnEliminarAlumnoCurso.BackColor = Color.IndianRed;
            btnEliminarAlumnoCurso.Location = new Point(270, 60);
            btnEliminarAlumnoCurso.Name = "btnEliminarAlumnoCurso";
            btnEliminarAlumnoCurso.Size = new Size(75, 23);
            btnEliminarAlumnoCurso.TabIndex = 16;
            btnEliminarAlumnoCurso.Text = "Eliminar";
            btnEliminarAlumnoCurso.UseVisualStyleBackColor = false;
            btnEliminarAlumnoCurso.Visible = false;
            btnEliminarAlumnoCurso.Click += btnEliminarAlumnoCurso_Click;
            // 
            // btnAgregarProfesorCurso
            // 
            btnAgregarProfesorCurso.BackColor = Color.Khaki;
            btnAgregarProfesorCurso.Location = new Point(500, 60);
            btnAgregarProfesorCurso.Name = "btnAgregarProfesorCurso";
            btnAgregarProfesorCurso.Size = new Size(127, 23);
            btnAgregarProfesorCurso.TabIndex = 18;
            btnAgregarProfesorCurso.Text = "Agregar Profesor";
            btnAgregarProfesorCurso.UseVisualStyleBackColor = false;
            btnAgregarProfesorCurso.Click += btnAgregarProfesorCurso_Click;
            // 
            // btnEliminarProfesorCurso
            // 
            btnEliminarProfesorCurso.BackColor = Color.IndianRed;
            btnEliminarProfesorCurso.Location = new Point(643, 60);
            btnEliminarProfesorCurso.Name = "btnEliminarProfesorCurso";
            btnEliminarProfesorCurso.Size = new Size(75, 23);
            btnEliminarProfesorCurso.TabIndex = 19;
            btnEliminarProfesorCurso.Text = "Eliminar";
            btnEliminarProfesorCurso.UseVisualStyleBackColor = false;
            btnEliminarProfesorCurso.Visible = false;
            btnEliminarProfesorCurso.Click += btnEliminarProfesorCurso_Click;
            // 
            // btnModificarCurso
            // 
            btnModificarCurso.Location = new Point(314, 261);
            btnModificarCurso.Name = "btnModificarCurso";
            btnModificarCurso.Size = new Size(114, 23);
            btnModificarCurso.TabIndex = 20;
            btnModificarCurso.Text = "Modificar Curso";
            btnModificarCurso.UseVisualStyleBackColor = true;
            btnModificarCurso.Click += btnModificarCurso_Click;
            // 
            // CursoDetalleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 296);
            Controls.Add(btnModificarCurso);
            Controls.Add(btnEliminarProfesorCurso);
            Controls.Add(btnAgregarProfesorCurso);
            Controls.Add(btnEliminarAlumnoCurso);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridProfesoresCurso);
            Controls.Add(dataGridAlumnosCurso);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(numericCupo);
            Controls.Add(labelCupo);
            Controls.Add(comboBoxComision);
            Controls.Add(labelComision);
            Controls.Add(comboBoxMateria);
            Controls.Add(labelMateria);
            Controls.Add(numericAnio);
            Controls.Add(labelAnio);
            Name = "CursoDetalleForm";
            Text = "Detalle Curso";
            Load += CursoDetalleForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCupo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridAlumnosCurso).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProfesoresCurso).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelAnio;
        private NumericUpDown numericAnio;
        private Label labelCupo;
        private NumericUpDown numericCupo;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label labelComision;
        private ComboBox comboBoxComision;
        private Label labelMateria;
        private ComboBox comboBoxMateria;
        private DataGridView dataGridAlumnosCurso;
        private DataGridView dataGridProfesoresCurso;
        private Label label1;
        private Label label2;
        private Button btnEliminarAlumnoCurso;
        private Button btnAgregarProfesorCurso;
        private Button btnEliminarProfesorCurso;
        private Button btnModificarCurso;
    }
}
