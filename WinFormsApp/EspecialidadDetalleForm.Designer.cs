namespace WinFormsApp
{
    partial class EspecialidadDetalleForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            labelDescripcion = new Label();
            txtBoxDescripcion = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(20, 21);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(75, 15);
            labelDescripcion.TabIndex = 0;
            labelDescripcion.Text = "Descripción:";
            // 
            // txtBoxDescripcion
            // 
            txtBoxDescripcion.Location = new Point(100, 18);
            txtBoxDescripcion.Name = "txtBoxDescripcion";
            txtBoxDescripcion.Size = new Size(180, 23);
            txtBoxDescripcion.TabIndex = 1;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.ActiveCaption;
            btnGuardar.Location = new Point(205, 60);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.Location = new Point(20, 60);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // EspecialidadDetalleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 101);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtBoxDescripcion);
            Controls.Add(labelDescripcion);
            Name = "EspecialidadDetalleForm";
            Text = "Detalle Especialidad";
            Load += EspecialidadDetalleForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDescripcion;
        private TextBox txtBoxDescripcion;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
