namespace WinFormsApp
{
    partial class ProfesorCursosDetalle
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
            dataGridViewCursos = new DataGridView();
            btnCerrar = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCursos).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewCursos
            // 
            dataGridViewCursos.AllowUserToAddRows = false;
            dataGridViewCursos.AllowUserToDeleteRows = false;
            dataGridViewCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCursos.Location = new Point(12, 45);
            dataGridViewCursos.Name = "dataGridViewCursos";
            dataGridViewCursos.ReadOnly = true;
            dataGridViewCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCursos.Size = new Size(560, 300);
            dataGridViewCursos.TabIndex = 0;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(247, 360);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(90, 30);
            btnCerrar.TabIndex = 1;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(186, 21);
            label1.TabIndex = 2;
            label1.Text = "Mis Cursos Asignados";
            // 
            // ProfesorCursosDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 411);
            Controls.Add(label1);
            Controls.Add(btnCerrar);
            Controls.Add(dataGridViewCursos);
            Name = "ProfesorCursosDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cursos del Profesor";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCursos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewCursos;
        private Button btnCerrar;
        private Label label1;
    }
}
