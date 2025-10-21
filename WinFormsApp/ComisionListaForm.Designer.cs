namespace WinFormsApp
{
    partial class ComisionListaForm
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
            dataGridViewComisiones = new DataGridView();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewComisiones).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewComisiones
            // 
            dataGridViewComisiones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewComisiones.Location = new Point(20, 20);
            dataGridViewComisiones.Name = "dataGridViewComisiones";
            dataGridViewComisiones.Size = new Size(420, 220);
            dataGridViewComisiones.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(365, 250);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(200, 250);
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
            // ComisionListaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 291);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(dataGridViewComisiones);
            Name = "ComisionListaForm";
            Text = "Comisiones";
            Load += ComisionListaForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewComisiones).EndInit();
            ResumeLayout(false);
        }

        private DataGridView dataGridViewComisiones;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
    }
}
