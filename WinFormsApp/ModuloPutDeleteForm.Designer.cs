namespace WinFormsApp
{
    partial class ModuloPutDeleteForm
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
            labelNuevaDesc = new Label();
            txtBoxNuevaDescripcion = new TextBox();
            btnEliminar = new Button();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // labelNuevaDesc
            // 
            labelNuevaDesc.AutoSize = true;
            labelNuevaDesc.Location = new Point(21, 11);
            labelNuevaDesc.Name = "labelNuevaDesc";
            labelNuevaDesc.Size = new Size(108, 15);
            labelNuevaDesc.TabIndex = 0;
            labelNuevaDesc.Text = "Nueva descripción:";
            // 
            // txtBoxNuevaDescripcion
            // 
            txtBoxNuevaDescripcion.Location = new Point(21, 29);
            txtBoxNuevaDescripcion.Multiline = true;
            txtBoxNuevaDescripcion.Name = "txtBoxNuevaDescripcion";
            txtBoxNuevaDescripcion.Size = new Size(400, 85);
            txtBoxNuevaDescripcion.TabIndex = 1;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.Location = new Point(21, 129);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(185, 28);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.ActiveCaption;
            btnGuardar.Location = new Point(224, 129);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(197, 28);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // ModuloPutDeleteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 165);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminar);
            Controls.Add(txtBoxNuevaDescripcion);
            Controls.Add(labelNuevaDesc);
            Name = "ModuloPutDeleteForm";
            Text = "Modulos - DELETE/PUT";
            Load += ModuloPutDeleteForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNuevaDesc;
        private TextBox txtBoxNuevaDescripcion;
        private Button btnEliminar;
        private Button btnGuardar;
    }
}