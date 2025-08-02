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
            txtDesc = new TextBox();
            gridUnicaEsp = new PropertyGrid();
            gridNuevaEsp = new PropertyGrid();
            labelDescripcion = new Label();
            numUpDownEsp = new NumericUpDown();
            btnMostrarUnaEsp = new Button();
            gridEsp = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)numUpDownEsp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridEsp).BeginInit();
            SuspendLayout();
            // 
            // btnListarEsp
            // 
            btnListarEsp.Location = new Point(12, 12);
            btnListarEsp.Name = "btnListarEsp";
            btnListarEsp.Size = new Size(263, 63);
            btnListarEsp.TabIndex = 0;
            btnListarEsp.Text = "Listar especialidades";
            btnListarEsp.UseVisualStyleBackColor = true;
            btnListarEsp.Click += btnListarEsp_Click;
            // 
            // btnAddEsp
            // 
            btnAddEsp.Location = new Point(600, 12);
            btnAddEsp.Name = "btnAddEsp";
            btnAddEsp.Size = new Size(140, 66);
            btnAddEsp.TabIndex = 1;
            btnAddEsp.Text = "Agregar especialidad";
            btnAddEsp.UseVisualStyleBackColor = true;
            btnAddEsp.Click += btnAddEsp_Click;
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(749, 52);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(181, 23);
            txtDesc.TabIndex = 2;
            // 
            // gridUnicaEsp
            // 
            gridUnicaEsp.Location = new Point(284, 90);
            gridUnicaEsp.Name = "gridUnicaEsp";
            gridUnicaEsp.Size = new Size(306, 201);
            gridUnicaEsp.TabIndex = 3;
            // 
            // gridNuevaEsp
            // 
            gridNuevaEsp.Location = new Point(600, 90);
            gridNuevaEsp.Name = "gridNuevaEsp";
            gridNuevaEsp.Size = new Size(336, 201);
            gridNuevaEsp.TabIndex = 4;
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(749, 21);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(72, 15);
            labelDescripcion.TabIndex = 5;
            labelDescripcion.Text = "Descripción:";
            labelDescripcion.Click += labelDescripcion_Click;
            // 
            // numUpDownEsp
            // 
            numUpDownEsp.Location = new Point(452, 37);
            numUpDownEsp.Name = "numUpDownEsp";
            numUpDownEsp.Size = new Size(141, 23);
            numUpDownEsp.TabIndex = 6;
            // 
            // btnMostrarUnaEsp
            // 
            btnMostrarUnaEsp.Location = new Point(284, 12);
            btnMostrarUnaEsp.Name = "btnMostrarUnaEsp";
            btnMostrarUnaEsp.Size = new Size(156, 64);
            btnMostrarUnaEsp.TabIndex = 7;
            btnMostrarUnaEsp.Text = "Buscar";
            btnMostrarUnaEsp.UseVisualStyleBackColor = true;
            btnMostrarUnaEsp.Click += btnMostrarUnaEsp_Click;
            // 
            // gridEsp
            // 
            gridEsp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridEsp.Location = new Point(12, 90);
            gridEsp.Name = "gridEsp";
            gridEsp.Size = new Size(263, 201);
            gridEsp.TabIndex = 8;
            // 
            // EspecialidadForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 314);
            Controls.Add(gridEsp);
            Controls.Add(btnMostrarUnaEsp);
            Controls.Add(numUpDownEsp);
            Controls.Add(labelDescripcion);
            Controls.Add(gridNuevaEsp);
            Controls.Add(gridUnicaEsp);
            Controls.Add(txtDesc);
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
        private TextBox txtDesc;
        private PropertyGrid gridUnicaEsp;
        private PropertyGrid gridNuevaEsp;
        private Label labelDescripcion;
        private NumericUpDown numUpDownEsp;
        private Button btnMostrarUnaEsp;
        private DataGridView gridEsp;
    }
}