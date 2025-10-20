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
            textBoxBuscador = new TextBox();
            btnBuscar = new Button();
            dataGridViewEspecialidades = new DataGridView();
            btnEliminar = new Button();
            btnAgregar = new Button();
            btnModificar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEspecialidades).BeginInit();
            SuspendLayout();
            // 
            // textBoxBuscador
            // 
            textBoxBuscador.Location = new Point(30, 26);
            textBoxBuscador.Name = "textBoxBuscador";
            textBoxBuscador.PlaceholderText = "Buscar por descripción";
            textBoxBuscador.Size = new Size(175, 23);
            textBoxBuscador.TabIndex = 0;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(223, 25);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(69, 23);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dataGridViewEspecialidades
            // 
            dataGridViewEspecialidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEspecialidades.Location = new Point(30, 66);
            dataGridViewEspecialidades.Name = "dataGridViewEspecialidades";
            dataGridViewEspecialidades.Size = new Size(267, 190);
            dataGridViewEspecialidades.TabIndex = 2;
            dataGridViewEspecialidades.CellDoubleClick += dataGridViewEspecialidades_CellDoubleClick;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.Location = new Point(30, 278);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(217, 278);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar +";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(130, 278);
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
            ClientSize = new Size(329, 319);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(btnEliminar);
            Controls.Add(dataGridViewEspecialidades);
            Controls.Add(btnBuscar);
            Controls.Add(textBoxBuscador);
            Name = "EspecialidadListaForm";
            Text = "Especialidades";
            Load += EspecialidadListaForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewEspecialidades).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxBuscador;
        private Button btnBuscar;
        private DataGridView dataGridViewEspecialidades;
        private Button btnEliminar;
        private Button btnAgregar;
        private Button btnModificar;
    }
}
