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
            button2 = new Button();
            textBox1 = new TextBox();
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
            btnListarEsp.Click += this.btnListarEsp_Click;
            // 
            // button2
            // 
            button2.Location = new Point(600, 12);
            button2.Name = "button2";
            button2.Size = new Size(140, 66);
            button2.TabIndex = 1;
            button2.Text = "Agregar especialidad";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(749, 52);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(181, 23);
            textBox1.TabIndex = 2;
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
            labelDescripcion.Location = new Point(776, 18);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(72, 15);
            labelDescripcion.TabIndex = 5;
            labelDescripcion.Text = "Descripción:";
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
            Controls.Add(textBox1);
            Controls.Add(button2);
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
        private Button button2;
        private TextBox textBox1;
        private PropertyGrid gridUnicaEsp;
        private PropertyGrid gridNuevaEsp;
        private Label labelDescripcion;
        private NumericUpDown numUpDownEsp;
        private Button btnMostrarUnaEsp;
        private DataGridView gridEsp;
    }
}