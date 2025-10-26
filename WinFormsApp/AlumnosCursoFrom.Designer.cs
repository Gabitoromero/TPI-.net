namespace WinFormsApp
{
    partial class AlumnosCursoForm
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
            dataGridViewAlumnosCurso = new DataGridView();
            btnVolver = new Button();
            btnModificar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAlumnosCurso).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewAlumnosCurso
            // 
            dataGridViewAlumnosCurso.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAlumnosCurso.Location = new Point(12, 12);
            dataGridViewAlumnosCurso.Name = "dataGridViewAlumnosCurso";
            dataGridViewAlumnosCurso.Size = new Size(408, 227);
            dataGridViewAlumnosCurso.TabIndex = 0;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(12, 251);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 1;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click_1;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(345, 251);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click_2;
            // 
            // AlumnosCursoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 286);
            Controls.Add(btnModificar);
            Controls.Add(btnVolver);
            Controls.Add(dataGridViewAlumnosCurso);
            Name = "AlumnosCursoForm";
            Text = "Alumnos";
            ((System.ComponentModel.ISupportInitialize)dataGridViewAlumnosCurso).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewAlumnosCurso;
        private Button btnVolver;
        private Button btnModificar;
    }
}