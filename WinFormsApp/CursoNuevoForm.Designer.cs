namespace WinFormsApp
{
    partial class CursoNuevoForm
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
            comboBoxMaterias = new ComboBox();
            comboBoxComision = new ComboBox();
            numericAnio = new NumericUpDown();
            numericCupo = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnCancelar = new Button();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)numericAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCupo).BeginInit();
            SuspendLayout();
            // 
            // comboBoxMaterias
            // 
            comboBoxMaterias.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMaterias.FormattingEnabled = true;
            comboBoxMaterias.Location = new Point(139, 31);
            comboBoxMaterias.Name = "comboBoxMaterias";
            comboBoxMaterias.Size = new Size(121, 23);
            comboBoxMaterias.TabIndex = 0;
            // 
            // comboBoxComision
            // 
            comboBoxComision.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxComision.FormattingEnabled = true;
            comboBoxComision.Location = new Point(139, 68);
            comboBoxComision.Name = "comboBoxComision";
            comboBoxComision.Size = new Size(121, 23);
            comboBoxComision.TabIndex = 1;
            // 
            // numericAnio
            // 
            numericAnio.Location = new Point(140, 112);
            numericAnio.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numericAnio.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            numericAnio.Name = "numericAnio";
            numericAnio.Size = new Size(120, 23);
            numericAnio.TabIndex = 2;
            numericAnio.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            // 
            // numericCupo
            // 
            numericCupo.Location = new Point(139, 151);
            numericCupo.Name = "numericCupo";
            numericCupo.Size = new Size(120, 23);
            numericCupo.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 34);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 4;
            label1.Text = "Materia:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 76);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 5;
            label2.Text = "Comisión:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(62, 151);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 7;
            label4.Text = "Cupo:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 114);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 8;
            label5.Text = "Año calendario:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(12, 196);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.MediumSeaGreen;
            btnGuardar.Location = new Point(208, 196);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // CursoNuevoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(295, 229);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericCupo);
            Controls.Add(numericAnio);
            Controls.Add(comboBoxComision);
            Controls.Add(comboBoxMaterias);
            Name = "CursoNuevoForm";
            Text = "Nuevo Curso";
            Load += CursoNuevoForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCupo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxMaterias;
        private ComboBox comboBoxComision;
        private NumericUpDown numericAnio;
        private NumericUpDown numericCupo;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Button btnCancelar;
        private Button btnGuardar;
    }
}