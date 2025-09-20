namespace WinFormsApp
{
    partial class EspecialidadDeletePutForm
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
            btnEliminarEsp = new Button();
            btnGuardarCambios = new Button();
            labelNuevaDesc = new Label();
            txtBoxDesc = new TextBox();
            SuspendLayout();
            // 
            // btnEliminarEsp
            // 
            btnEliminarEsp.BackColor = Color.IndianRed;
            btnEliminarEsp.Location = new Point(12, 175);
            btnEliminarEsp.Name = "btnEliminarEsp";
            btnEliminarEsp.Size = new Size(222, 28);
            btnEliminarEsp.TabIndex = 1;
            btnEliminarEsp.Text = "Eliminar";
            btnEliminarEsp.UseVisualStyleBackColor = false;
            btnEliminarEsp.Click += btnEliminarEsp_Click;
            // 
            // btnGuardarCambios
            // 
            btnGuardarCambios.BackColor = SystemColors.ActiveCaption;
            btnGuardarCambios.Location = new Point(240, 173);
            btnGuardarCambios.Name = "btnGuardarCambios";
            btnGuardarCambios.Size = new Size(253, 30);
            btnGuardarCambios.TabIndex = 2;
            btnGuardarCambios.Text = "Guardar";
            btnGuardarCambios.UseVisualStyleBackColor = false;
            btnGuardarCambios.Click += btnGuardarCambios_Click;
            // 
            // labelNuevaDesc
            // 
            labelNuevaDesc.AutoSize = true;
            labelNuevaDesc.Location = new Point(21, 16);
            labelNuevaDesc.Name = "labelNuevaDesc";
            labelNuevaDesc.Size = new Size(108, 15);
            labelNuevaDesc.TabIndex = 3;
            labelNuevaDesc.Text = "Nueva descripción:";
            // 
            // txtBoxDesc
            // 
            txtBoxDesc.Location = new Point(12, 34);
            txtBoxDesc.Multiline = true;
            txtBoxDesc.Name = "txtBoxDesc";
            txtBoxDesc.Size = new Size(481, 135);
            txtBoxDesc.TabIndex = 4;
            // 
            // EspecialidadDeletePutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 206);
            Controls.Add(txtBoxDesc);
            Controls.Add(labelNuevaDesc);
            Controls.Add(btnGuardarCambios);
            Controls.Add(btnEliminarEsp);
            Name = "EspecialidadDeletePutForm";
            Text = "Especialidades - DELETE/PUT";
            Load += EspecialidadDeletePutForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnEliminarEsp;
        private Button btnGuardarCambios;
        private Label labelNuevaDesc;
        private TextBox txtBoxDesc;
    }
}