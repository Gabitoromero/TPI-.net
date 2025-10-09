namespace WinFormsApp
{
    partial class PlanDetalleForm
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
            labelDescripcion = new Label();
            txtBoxDescripcion = new TextBox();
            labelEspecialidad = new Label();
            comboBoxEspecialidades = new ComboBox();
            btnCancelar = new Button();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(22, 16);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(75, 15);
            labelDescripcion.TabIndex = 0;
            labelDescripcion.Text = "Descripcion: ";
            // 
            // txtBoxDescripcion
            // 
            txtBoxDescripcion.Location = new Point(114, 15);
            txtBoxDescripcion.Multiline = true;
            txtBoxDescripcion.Name = "txtBoxDescripcion";
            txtBoxDescripcion.Size = new Size(274, 74);
            txtBoxDescripcion.TabIndex = 1;
            // 
            // labelEspecialidad
            // 
            labelEspecialidad.AutoSize = true;
            labelEspecialidad.Location = new Point(25, 101);
            labelEspecialidad.Name = "labelEspecialidad";
            labelEspecialidad.Size = new Size(75, 15);
            labelEspecialidad.TabIndex = 2;
            labelEspecialidad.Text = "Especialidad:";
            // 
            // comboBoxEspecialidades
            // 
            comboBoxEspecialidades.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEspecialidades.FormattingEnabled = true;
            comboBoxEspecialidades.Location = new Point(117, 101);
            comboBoxEspecialidades.Name = "comboBoxEspecialidades";
            comboBoxEspecialidades.Size = new Size(267, 23);
            comboBoxEspecialidades.TabIndex = 3;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.Location = new Point(68, 148);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(89, 27);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.ActiveCaption;
            btnGuardar.Location = new Point(254, 148);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(89, 27);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // PlanDetalleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 187);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Controls.Add(comboBoxEspecialidades);
            Controls.Add(labelEspecialidad);
            Controls.Add(txtBoxDescripcion);
            Controls.Add(labelDescripcion);
            Name = "PlanDetalleForm";
            Text = "Nuevo Plan";
            Load += PlanDetalleForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDescripcion;
        private TextBox txtBoxDescripcion;
        private Label labelEspecialidad;
        private ComboBox comboBoxEspecialidades;
        private Button btnCancelar;
        private Button btnGuardar;
    }
}