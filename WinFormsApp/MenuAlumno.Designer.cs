namespace WinFormsApp
{
    partial class MenuAlumno
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
            btnVerInscripciones = new Button();
            btnVolver = new Button();
            label1 = new Label();
            btnNuevaInscripcion = new Button();
            SuspendLayout();
            // 
            // btnVerInscripciones
            // 
            btnVerInscripciones.Location = new Point(77, 52);
            btnVerInscripciones.Name = "btnVerInscripciones";
            btnVerInscripciones.Size = new Size(136, 27);
            btnVerInscripciones.TabIndex = 0;
            btnVerInscripciones.Text = "Mis cursos";
            btnVerInscripciones.UseVisualStyleBackColor = true;
            btnVerInscripciones.Click += this.btnVerInscripciones_Click_2;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.IndianRed;
            btnVolver.Location = new Point(97, 138);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(90, 23);
            btnVolver.TabIndex = 1;
            btnVolver.Text = "Cerrar Sesión";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 21);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 2;
            label1.Text = "Seleccione :";
            // 
            // btnNuevaInscripcion
            // 
            btnNuevaInscripcion.Location = new Point(80, 85);
            btnNuevaInscripcion.Name = "btnNuevaInscripcion";
            btnNuevaInscripcion.Size = new Size(133, 27);
            btnNuevaInscripcion.TabIndex = 3;
            btnNuevaInscripcion.Text = "Inscribirme";
            btnNuevaInscripcion.UseVisualStyleBackColor = true;
            btnNuevaInscripcion.Click += btnNuevaInscripcion_Click;
            // 
            // MenuAlumno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(269, 173);
            Controls.Add(btnNuevaInscripcion);
            Controls.Add(label1);
            Controls.Add(btnVolver);
            Controls.Add(btnVerInscripciones);
            Name = "MenuAlumno";
            Text = "Alumnos";
            Load += MenuAlumno_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVerInscripciones;
        private Button btnVolver;
        private Label label1;
        private Button btnNuevaInscripcion;
    }
}