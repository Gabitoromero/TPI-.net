namespace WinFormsApp
{
    partial class MenuForm
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
            btnEspecialidadesCRUD = new Button();
            btnMaterias = new Button();
            btnUsuariosCRUD = new Button();
            btnPlanesCRUD = new Button();
            labelCRUD = new Label();
            btnCerrar = new Button();
            btnCursos = new Button();
            btnComisiones = new Button();
            panelContent = new Panel();
            SuspendLayout();
            // 
            // btnEspecialidadesCRUD
            // 
            btnEspecialidadesCRUD.Location = new Point(39, 58);
            btnEspecialidadesCRUD.Name = "btnEspecialidadesCRUD";
            btnEspecialidadesCRUD.Size = new Size(157, 37);
            btnEspecialidadesCRUD.TabIndex = 0;
            btnEspecialidadesCRUD.Text = "Especialidades";
            btnEspecialidadesCRUD.UseVisualStyleBackColor = true;
            btnEspecialidadesCRUD.Click += btnEspecialidadesCRUD_Click;
            // 
            // btnMaterias
            // 
            btnMaterias.Location = new Point(257, 117);
            btnMaterias.Name = "btnMaterias";
            btnMaterias.Size = new Size(157, 37);
            btnMaterias.TabIndex = 1;
            btnMaterias.Text = "Materias";
            btnMaterias.UseVisualStyleBackColor = true;
            btnMaterias.Click += btnModulosCRUD_Click;
            // 
            // btnUsuariosCRUD
            // 
            btnUsuariosCRUD.Location = new Point(39, 175);
            btnUsuariosCRUD.Name = "btnUsuariosCRUD";
            btnUsuariosCRUD.Size = new Size(157, 37);
            btnUsuariosCRUD.TabIndex = 2;
            btnUsuariosCRUD.Text = "Usuarios";
            btnUsuariosCRUD.UseVisualStyleBackColor = true;
            btnUsuariosCRUD.Click += btnUsuariosCRUD_Click;
            // 
            // btnPlanesCRUD
            // 
            btnPlanesCRUD.Location = new Point(39, 117);
            btnPlanesCRUD.Name = "btnPlanesCRUD";
            btnPlanesCRUD.Size = new Size(157, 37);
            btnPlanesCRUD.TabIndex = 3;
            btnPlanesCRUD.Text = "Planes";
            btnPlanesCRUD.UseVisualStyleBackColor = true;
            btnPlanesCRUD.Click += btnPlanesCRUD_Click;
            // 
            // labelCRUD
            // 
            labelCRUD.AutoSize = true;
            labelCRUD.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCRUD.Location = new Point(12, 9);
            labelCRUD.Name = "labelCRUD";
            labelCRUD.Size = new Size(123, 30);
            labelCRUD.TabIndex = 4;
            labelCRUD.Text = "Gestion de :";
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.IndianRed;
            btnCerrar.Location = new Point(172, 243);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(110, 22);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar sesión";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnCursos
            // 
            btnCursos.Location = new Point(257, 58);
            btnCursos.Name = "btnCursos";
            btnCursos.Size = new Size(157, 37);
            btnCursos.TabIndex = 6;
            btnCursos.Text = "Cursos";
            btnCursos.UseVisualStyleBackColor = true;
            btnCursos.Click += btnCursos_Click;
            // 
            // btnComisiones
            // 
            btnComisiones.Location = new Point(257, 175);
            btnComisiones.Name = "btnComisiones";
            btnComisiones.Size = new Size(157, 37);
            btnComisiones.TabIndex = 7;
            btnComisiones.Text = "Comisiones";
            btnComisiones.UseVisualStyleBackColor = true;
            btnComisiones.Click += btnComisiones_Click;
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(613, 562);
            panelContent.TabIndex = 8;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 562);
            Controls.Add(panelContent);
            Controls.Add(btnComisiones);
            Controls.Add(btnCursos);
            Controls.Add(btnCerrar);
            Controls.Add(labelCRUD);
            Controls.Add(btnPlanesCRUD);
            Controls.Add(btnUsuariosCRUD);
            Controls.Add(btnMaterias);
            Controls.Add(btnEspecialidadesCRUD);
            Name = "MenuForm";
            Text = "Menú Principal";
            Load += Menu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEspecialidadesCRUD;
        private Button btnMaterias;
        private Button btnUsuariosCRUD;
        private Button btnPlanesCRUD;
        private Label labelCRUD;
        private Button btnCerrar;
        private Button btnCursos;
        private Button btnComisiones;
        private Panel panelContent;
    }
}