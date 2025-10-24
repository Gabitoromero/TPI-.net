namespace WinFormsApp
{
    partial class EspecialidadListaForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dataGridViewEspecialidades = new DataGridView();
            btnEliminar = new Button();
            btnAgregar = new Button();
            btnModificar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEspecialidades).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewEspecialidades
            // 
            dataGridViewEspecialidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEspecialidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEspecialidades.Location = new Point(12, 12);
            dataGridViewEspecialidades.Name = "dataGridViewEspecialidades";
            dataGridViewEspecialidades.Size = new Size(404, 229);
            dataGridViewEspecialidades.TabIndex = 2;
            dataGridViewEspecialidades.CellDoubleClick += dataGridViewEspecialidades_CellDoubleClick;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.Location = new Point(12, 262);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = SystemColors.ActiveCaption;
            btnAgregar.Location = new Point(341, 262);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar +";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(174, 262);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // EspecialidadListaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 300);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(btnEliminar);
            Controls.Add(dataGridViewEspecialidades);
            Name = "EspecialidadListaForm";
            Text = "Especialidades";
            Load += EspecialidadListaForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewEspecialidades).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridViewEspecialidades;
        private Button btnEliminar;
        private Button btnAgregar;
        private Button btnModificar;
    }
}
