namespace WinFormsApp
{
    partial class CursoDetalleForm
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
            labelAnio = new Label();
            numericAnio = new NumericUpDown();
            labelCupo = new Label();
            numericCupo = new NumericUpDown();
            btnGuardar = new Button();
            btnCancelar = new Button();
            labelComision = new Label();
            comboBoxComision = new ComboBox();
            labelMateria = new Label();
            comboBoxMateria = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numericAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCupo).BeginInit();
            SuspendLayout();
            // 
            // labelAnio
            // 
            labelAnio.AutoSize = true;
            labelAnio.Location = new Point(20, 60);
            labelAnio.Name = "labelAnio";
            labelAnio.Size = new Size(90, 15);
            labelAnio.TabIndex = 2;
            labelAnio.Text = "Año calendario:";
            // 
            // numericAnio
            // 
            numericAnio.Location = new Point(120, 58);
            numericAnio.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericAnio.Name = "numericAnio";
            numericAnio.Size = new Size(120, 23);
            numericAnio.TabIndex = 3;
            // 
            // labelCupo
            // 
            labelCupo.AutoSize = true;
            labelCupo.Location = new Point(20, 140);
            labelCupo.Name = "labelCupo";
            labelCupo.Size = new Size(39, 15);
            labelCupo.TabIndex = 4;
            labelCupo.Text = "Cupo:";
            // 
            // numericCupo
            // 
            numericCupo.Location = new Point(120, 138);
            numericCupo.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericCupo.Name = "numericCupo";
            numericCupo.Size = new Size(120, 23);
            numericCupo.TabIndex = 5;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.MediumSeaGreen;
            btnGuardar.Location = new Point(177, 186);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.Control;
            btnCancelar.Location = new Point(20, 186);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // labelComision
            // 
            labelComision.AutoSize = true;
            labelComision.Location = new Point(20, 100);
            labelComision.Name = "labelComision";
            labelComision.Size = new Size(61, 15);
            labelComision.TabIndex = 8;
            labelComision.Text = "Comisión:";
            // 
            // comboBoxComision
            // 
            comboBoxComision.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxComision.Location = new Point(120, 96);
            comboBoxComision.Name = "comboBoxComision";
            comboBoxComision.Size = new Size(120, 23);
            comboBoxComision.TabIndex = 9;
            // 
            // labelMateria
            // 
            labelMateria.AutoSize = true;
            labelMateria.Location = new Point(20, 21);
            labelMateria.Name = "labelMateria";
            labelMateria.Size = new Size(50, 15);
            labelMateria.TabIndex = 10;
            labelMateria.Text = "Materia:";
            // 
            // comboBoxMateria
            // 
            comboBoxMateria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMateria.Location = new Point(120, 18);
            comboBoxMateria.Name = "comboBoxMateria";
            comboBoxMateria.Size = new Size(120, 23);
            comboBoxMateria.TabIndex = 11;
            // 
            // CursoDetalleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 221);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(numericCupo);
            Controls.Add(labelCupo);
            Controls.Add(comboBoxComision);
            Controls.Add(labelComision);
            Controls.Add(comboBoxMateria);
            Controls.Add(labelMateria);
            Controls.Add(numericAnio);
            Controls.Add(labelAnio);
            Name = "CursoDetalleForm";
            Text = "Detalle Curso";
            Load += CursoDetalleForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCupo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelAnio;
        private NumericUpDown numericAnio;
        private Label labelCupo;
        private NumericUpDown numericCupo;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label labelComision;
        private ComboBox comboBoxComision;
        private Label labelMateria;
        private ComboBox comboBoxMateria;
    }
}
