namespace WinFormsApp
{
    partial class AlumnoCursoPutForm
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
            comboBoxCondicion = new ComboBox();
            label1 = new Label();
            numericNota = new NumericUpDown();
            label2 = new Label();
            btnGuardar = new Button();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)numericNota).BeginInit();
            SuspendLayout();
            // 
            // comboBoxCondicion
            // 
            comboBoxCondicion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCondicion.FormattingEnabled = true;
            comboBoxCondicion.Location = new Point(116, 21);
            comboBoxCondicion.Name = "comboBoxCondicion";
            comboBoxCondicion.Size = new Size(121, 23);
            comboBoxCondicion.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 24);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 1;
            label1.Text = "Condición:";
            // 
            // numericNota
            // 
            numericNota.Location = new Point(116, 61);
            numericNota.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericNota.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericNota.Name = "numericNota";
            numericNota.Size = new Size(120, 23);
            numericNota.TabIndex = 2;
            numericNota.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericNota.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 63);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 3;
            label2.Text = "Nota:";
            label2.Visible = false;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(162, 108);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(22, 108);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 5;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // AlumnoCursoPutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(265, 144);
            Controls.Add(btnVolver);
            Controls.Add(btnGuardar);
            Controls.Add(label2);
            Controls.Add(numericNota);
            Controls.Add(label1);
            Controls.Add(comboBoxCondicion);
            Name = "AlumnoCursoPutForm";
            Text = "Alumno";
            //Load += AlumnoCursoPutForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)numericNota).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxCondicion;
        private Label label1;
        private NumericUpDown numericNota;
        private Label label2;
        private Button btnGuardar;
        private Button btnVolver;
    }
}