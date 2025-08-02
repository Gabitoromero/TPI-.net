namespace WinForms
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
            btnListar = new Button();
            gridEspecialidades = new DataGridView();
            btnMostrarUnaEsp = new Button();
            numUpDownIdEsp = new NumericUpDown();
            btnAddEsp = new Button();
            gridUnicaEsp = new PropertyGrid();
            gridNuevaEsp = new PropertyGrid();
            labelDescripcion = new Label();
            txtDescripcion = new TextBox();
            ((System.ComponentModel.ISupportInitialize)gridEspecialidades).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numUpDownIdEsp).BeginInit();
            SuspendLayout();
            // 
            // btnListar
            // 
            btnListar.Location = new Point(9, 9);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(258, 53);
            btnListar.TabIndex = 0;
            btnListar.Text = "Listar especialidades";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += this.btnListar_Click;
            // 
            // gridEspecialidades
            // 
            gridEspecialidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridEspecialidades.Location = new Point(9, 68);
            gridEspecialidades.Name = "gridEspecialidades";
            gridEspecialidades.Size = new Size(258, 167);
            gridEspecialidades.TabIndex = 1;
            // 
            // btnMostrarUnaEsp
            // 
            btnMostrarUnaEsp.Location = new Point(284, 11);
            btnMostrarUnaEsp.Name = "btnMostrarUnaEsp";
            btnMostrarUnaEsp.Size = new Size(149, 51);
            btnMostrarUnaEsp.TabIndex = 2;
            btnMostrarUnaEsp.Text = "Buscar";
            btnMostrarUnaEsp.UseVisualStyleBackColor = true;
            // 
            // numUpDownIdEsp
            // 
            numUpDownIdEsp.Location = new Point(443, 30);
            numUpDownIdEsp.Name = "numUpDownIdEsp";
            numUpDownIdEsp.Size = new Size(107, 23);
            numUpDownIdEsp.TabIndex = 3;
            // 
            // btnAddEsp
            // 
            btnAddEsp.Location = new Point(577, 12);
            btnAddEsp.Name = "btnAddEsp";
            btnAddEsp.Size = new Size(142, 49);
            btnAddEsp.TabIndex = 4;
            btnAddEsp.Text = "Agregar especialidad";
            btnAddEsp.UseVisualStyleBackColor = true;
            // 
            // gridUnicaEsp
            // 
            gridUnicaEsp.Location = new Point(283, 77);
            gridUnicaEsp.Name = "gridUnicaEsp";
            gridUnicaEsp.Size = new Size(274, 158);
            gridUnicaEsp.TabIndex = 5;
            // 
            // gridNuevaEsp
            // 
            gridNuevaEsp.Location = new Point(577, 77);
            gridNuevaEsp.Name = "gridNuevaEsp";
            gridNuevaEsp.Size = new Size(315, 158);
            gridNuevaEsp.TabIndex = 6;
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(725, 20);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(72, 15);
            labelDescripcion.TabIndex = 7;
            labelDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(725, 38);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(167, 23);
            txtDescripcion.TabIndex = 8;
            // 
            // EspecialidadForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 245);
            Controls.Add(txtDescripcion);
            Controls.Add(labelDescripcion);
            Controls.Add(gridNuevaEsp);
            Controls.Add(gridUnicaEsp);
            Controls.Add(btnAddEsp);
            Controls.Add(numUpDownIdEsp);
            Controls.Add(btnMostrarUnaEsp);
            Controls.Add(gridEspecialidades);
            Controls.Add(btnListar);
            Name = "EspecialidadForm";
            Text = "Especialidades";
            Load += this.EspecialidadForm_Load;
            ((System.ComponentModel.ISupportInitialize)gridEspecialidades).EndInit();
            ((System.ComponentModel.ISupportInitialize)numUpDownIdEsp).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnListar;
        private DataGridView gridEspecialidades;
        private Button btnMostrarUnaEsp;
        private NumericUpDown numUpDownIdEsp;
        private Button btnAddEsp;
        private PropertyGrid gridUnicaEsp;
        private PropertyGrid gridNuevaEsp;
        private Label labelDescripcion;
        private TextBox txtDescripcion;
    }
}