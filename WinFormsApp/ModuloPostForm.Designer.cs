namespace WinFormsApp
{
    partial class ModuloPostForm
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
            textBoxDescripcion = new TextBox();
            labelDescripcion = new Label();
            btnGuardar = new Button();
            btnCerrar = new Button();
            SuspendLayout();
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(26, 36);
            textBoxDescripcion.Multiline = true;
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(413, 124);
            textBoxDescripcion.TabIndex = 0;
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(26, 18);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(69, 15);
            labelDescripcion.TabIndex = 1;
            labelDescripcion.Text = "Descripción";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.MediumSeaGreen;
            btnGuardar.Location = new Point(332, 178);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(107, 41);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += button1_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.IndianRed;
            btnCerrar.Location = new Point(26, 178);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(107, 41);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // ModuloPostForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 231);
            Controls.Add(btnCerrar);
            Controls.Add(btnGuardar);
            Controls.Add(labelDescripcion);
            Controls.Add(textBoxDescripcion);
            Name = "ModuloPostForm";
            Text = "Nuevo Módulo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxDescripcion;
        private Label labelDescripcion;
        private Button btnGuardar;
        private Button btnCerrar;
    }
}