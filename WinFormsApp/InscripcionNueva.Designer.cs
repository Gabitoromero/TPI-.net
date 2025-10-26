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
            dataGridCursos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridCursos).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.Control;
            btnCancelar.Location = new Point(12, 184);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Volver";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // dataGridCursos
            // 
            dataGridCursos.AllowUserToAddRows = false;
            dataGridCursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridCursos.Location = new Point(12, 12);
            dataGridCursos.MultiSelect = false;
            dataGridCursos.Name = "dataGridCursos";
            dataGridCursos.ReadOnly = true;
            dataGridCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridCursos.Size = new Size(347, 150);
            dataGridCursos.TabIndex = 8;
            dataGridCursos.CellContentClick += dataGridCursos_CellContentClick;
            // 
            // InscripcionNueva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(371, 219);
            Controls.Add(dataGridCursos);
            Controls.Add(btnCancelar);
            Name = "InscripcionNueva";
            Text = "Nueva Inscripción";
            Load += InscripcionNueva_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridCursos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCancelar;
        private DataGridView dataGridCursos;
    }
}