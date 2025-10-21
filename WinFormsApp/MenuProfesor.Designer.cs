namespace WinFormsApp
{
    partial class MenuProfesor
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
            btnVerCursos = new Button();
            btnVolver = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnVerCursos
            // 
            btnVerCursos.Location = new Point(77, 52);
            btnVerCursos.Name = "btnVerCursos";
            btnVerCursos.Size = new Size(136, 27);
            btnVerCursos.TabIndex = 0;
            btnVerCursos.Text = "Mis Cursos";
            btnVerCursos.UseVisualStyleBackColor = true;
            btnVerCursos.Click += btnVerCursos_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.IndianRed;
            btnVolver.Location = new Point(97, 105);
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
            // MenuProfesor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(269, 150);
            Controls.Add(label1);
            Controls.Add(btnVolver);
            Controls.Add(btnVerCursos);
            Name = "MenuProfesor";
            Text = "Profesores";
            Load += MenuProfesor_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVerCursos;
        private Button btnVolver;
        private Label label1;
    }
}
