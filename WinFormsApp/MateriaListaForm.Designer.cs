namespace WinFormsApp
{
    partial class MateriaListaForm
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

        private void InitializeComponent()
        {
            dataGridViewMaterias = new DataGridView();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMaterias).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMaterias
            // 
            dataGridViewMaterias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMaterias.Location = new Point(20, 20);
            dataGridViewMaterias.Name = "dataGridViewMaterias";
            dataGridViewMaterias.Size = new Size(540, 220);
            dataGridViewMaterias.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(469, 250);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar +";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(256, 250);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.Location = new Point(20, 250);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // MateriaListaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 291);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(dataGridViewMaterias);
            Name = "MateriaListaForm";
            Text = "Materias";
            Load += MateriaListaForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMaterias).EndInit();
            ResumeLayout(false);
        }

        private DataGridView dataGridViewMaterias;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
    }
}
