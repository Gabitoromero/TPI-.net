namespace WinFormsApp
{
    partial class InscripcionNueva
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
            btnCancelar = new Button();
            btnGuardar = new Button();
            dataGridCursos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridCursos).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.Control;
            btnCancelar.Location = new Point(25, 184);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Volver";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.ActiveCaption;
            btnGuardar.Location = new Point(261, 184);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Confirmar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // dataGridCursos
            // 
            dataGridCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridCursos.Location = new Point(25, 12);
            dataGridCursos.Name = "dataGridCursos";
            dataGridCursos.Size = new Size(311, 150);
            dataGridCursos.TabIndex = 8;
            dataGridCursos.CellContentClick += dataGridCursos_CellContentClick;
            // 
            // InscripcionNueva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 219);
            Controls.Add(dataGridCursos);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Name = "InscripcionNueva";
            Text = "Nueva Inscripción";
            Load += InscripcionNueva_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridCursos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCancelar;
        private Button btnGuardar;
        private DataGridView dataGridCursos;
    }
}