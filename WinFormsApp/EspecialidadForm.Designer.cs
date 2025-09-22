namespace WinFormsApp
{
    partial class EspecialidadForm
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
            btnListarEsp = new Button();
            btnAddEsp = new Button();
            gridUnicaEsp = new PropertyGrid();
            numUpDownEsp = new NumericUpDown();
            btnMostrarUnaEsp = new Button();
            gridEsp = new DataGridView();
            btnModificarEspecialidad = new Button();
            labelBusqueda = new Label();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)numUpDownEsp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridEsp).BeginInit();
            SuspendLayout();
            // 
            // btnListarEsp
            // 
            btnListarEsp.Location = new Point(12, 12);
            btnListarEsp.Name = "btnListarEsp";
            btnListarEsp.Size = new Size(237, 36);
            btnListarEsp.TabIndex = 0;
            btnListarEsp.Text = "Listar especialidades";
            btnListarEsp.UseVisualStyleBackColor = true;
            btnListarEsp.Click += btnListarEsp_Click;
            // 
            // btnAddEsp
            // 
            btnAddEsp.Location = new Point(107, 304);
            btnAddEsp.Name = "btnAddEsp";
            btnAddEsp.Size = new Size(84, 31);
            btnAddEsp.TabIndex = 1;
            btnAddEsp.Text = "Agregar +";
            btnAddEsp.UseVisualStyleBackColor = true;
            btnAddEsp.Click += btnAddEsp_Click;
            // 
            // gridUnicaEsp
            // 
            gridUnicaEsp.Enabled = false;
            gridUnicaEsp.Location = new Point(255, 106);
            gridUnicaEsp.Name = "gridUnicaEsp";
            gridUnicaEsp.Size = new Size(306, 185);
            gridUnicaEsp.TabIndex = 3;
            // 
            // numUpDownEsp
            // 
            numUpDownEsp.Location = new Point(404, 21);
            numUpDownEsp.Name = "numUpDownEsp";
            numUpDownEsp.Size = new Size(141, 23);
            numUpDownEsp.TabIndex = 6;
            // 
            // btnMostrarUnaEsp
            // 
            btnMostrarUnaEsp.Location = new Point(255, 52);
            btnMostrarUnaEsp.Name = "btnMostrarUnaEsp";
            btnMostrarUnaEsp.Size = new Size(306, 36);
            btnMostrarUnaEsp.TabIndex = 7;
            btnMostrarUnaEsp.Text = "Buscar";
            btnMostrarUnaEsp.UseVisualStyleBackColor = true;
            btnMostrarUnaEsp.Click += btnMostrarUnaEsp_Click;
            // 
            // gridEsp
            // 
            gridEsp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridEsp.Location = new Point(12, 52);
            gridEsp.Name = "gridEsp";
            gridEsp.Size = new Size(237, 239);
            gridEsp.TabIndex = 8;
            // 
            // btnModificarEspecialidad
            // 
            btnModificarEspecialidad.Location = new Point(332, 304);
            btnModificarEspecialidad.Name = "btnModificarEspecialidad";
            btnModificarEspecialidad.Size = new Size(157, 31);
            btnModificarEspecialidad.TabIndex = 9;
            btnModificarEspecialidad.Text = "Modificar";
            btnModificarEspecialidad.UseVisualStyleBackColor = true;
            btnModificarEspecialidad.Click += btnModificarEspecialidad_Click;
            // 
            // labelBusqueda
            // 
            labelBusqueda.AutoSize = true;
            labelBusqueda.Location = new Point(288, 23);
            labelBusqueda.Name = "labelBusqueda";
            labelBusqueda.Size = new Size(83, 15);
            labelBusqueda.TabIndex = 10;
            labelBusqueda.Text = "Buscar por ID :";
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.IndianRed;
            btnCerrar.Location = new Point(12, 304);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(89, 31);
            btnCerrar.TabIndex = 11;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // EspecialidadForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(573, 347);
            Controls.Add(btnCerrar);
            Controls.Add(labelBusqueda);
            Controls.Add(btnModificarEspecialidad);
            Controls.Add(gridEsp);
            Controls.Add(btnMostrarUnaEsp);
            Controls.Add(numUpDownEsp);
            Controls.Add(gridUnicaEsp);
            Controls.Add(btnAddEsp);
            Controls.Add(btnListarEsp);
            Name = "EspecialidadForm";
            Text = "Especialidades";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numUpDownEsp).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridEsp).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnListarEsp;
        private Button btnAddEsp;
        private PropertyGrid gridUnicaEsp;
        private NumericUpDown numUpDownEsp;
        private Button btnMostrarUnaEsp;
        private DataGridView gridEsp;
        private Button btnModificarEspecialidad;
        private Label labelBusqueda;
        private Button btnCerrar;
    }
}