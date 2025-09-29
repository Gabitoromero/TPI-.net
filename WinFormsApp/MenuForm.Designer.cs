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
            btnModulosCRUD = new Button();
            btnUsuariosCRUD = new Button();
            btnPlanesCRUD = new Button();
            labelCRUD = new Label();
            btnCerrar = new Button();
            SuspendLayout();
            // 
            // btnEspecialidadesCRUD
            // 
            btnEspecialidadesCRUD.Location = new Point(185, 68);
            btnEspecialidadesCRUD.Name = "btnEspecialidadesCRUD";
            btnEspecialidadesCRUD.Size = new Size(157, 37);
            btnEspecialidadesCRUD.TabIndex = 0;
            btnEspecialidadesCRUD.Text = "Especialidades";
            btnEspecialidadesCRUD.UseVisualStyleBackColor = true;
            btnEspecialidadesCRUD.Click += btnEspecialidadesCRUD_Click;
            // 
            // btnModulosCRUD
            // 
            btnModulosCRUD.Location = new Point(185, 111);
            btnModulosCRUD.Name = "btnModulosCRUD";
            btnModulosCRUD.Size = new Size(157, 37);
            btnModulosCRUD.TabIndex = 1;
            btnModulosCRUD.Text = "Modulos";
            btnModulosCRUD.UseVisualStyleBackColor = true;
            btnModulosCRUD.Click += btnModulosCRUD_Click;
            // 
            // btnUsuariosCRUD
            // 
            btnUsuariosCRUD.Location = new Point(185, 154);
            btnUsuariosCRUD.Name = "btnUsuariosCRUD";
            btnUsuariosCRUD.Size = new Size(157, 37);
            btnUsuariosCRUD.TabIndex = 2;
            btnUsuariosCRUD.Text = "Usuarios";
            btnUsuariosCRUD.UseVisualStyleBackColor = true;
            // 
            // btnPlanesCRUD
            // 
            btnPlanesCRUD.Location = new Point(185, 197);
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
            labelCRUD.Location = new Point(222, 37);
            labelCRUD.Name = "labelCRUD";
            labelCRUD.Size = new Size(69, 15);
            labelCRUD.TabIndex = 4;
            labelCRUD.Text = "Gestion de :";
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.IndianRed;
            btnCerrar.Location = new Point(9, 263);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(67, 22);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 290);
            Controls.Add(btnCerrar);
            Controls.Add(labelCRUD);
            Controls.Add(btnPlanesCRUD);
            Controls.Add(btnUsuariosCRUD);
            Controls.Add(btnModulosCRUD);
            Controls.Add(btnEspecialidadesCRUD);
            Name = "MenuForm";
            Text = "Menú Principal";
            Load += Menu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEspecialidadesCRUD;
        private Button btnModulosCRUD;
        private Button btnUsuariosCRUD;
        private Button btnPlanesCRUD;
        private Label labelCRUD;
        private Button btnCerrar;
    }
}