namespace WinFormsApp
{
    partial class EspecialidadPostForm
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
            btnGuardar = new Button();
            labelDescripcion = new Label();
            textBoxDESC = new TextBox();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.MediumSeaGreen;
            btnGuardar.Location = new Point(245, 163);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 41);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(12, 19);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(75, 15);
            labelDescripcion.TabIndex = 1;
            labelDescripcion.Text = "Descripción: ";
            // 
            // textBoxDESC
            // 
            textBoxDESC.Location = new Point(12, 45);
            textBoxDESC.Multiline = true;
            textBoxDESC.Name = "textBoxDESC";
            textBoxDESC.Size = new Size(353, 97);
            textBoxDESC.TabIndex = 2;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.Location = new Point(12, 163);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(127, 41);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // EspecialidadPostForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 218);
            Controls.Add(btnCancelar);
            Controls.Add(textBoxDESC);
            Controls.Add(labelDescripcion);
            Controls.Add(btnGuardar);
            Name = "EspecialidadPostForm";
            Text = "Nueva especialidad";
            Load += EspecialidadPostForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardar;
        private Label labelDescripcion;
        private TextBox textBoxDESC;
        private Button btnCancelar;
    }
}