namespace WinFormsApp
{
    partial class CursoSeleccionProfesor
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
            dataGridProfesores = new DataGridView();
            checkBoxTitular = new CheckBox();
            btnAgregar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridProfesores).BeginInit();
            SuspendLayout();
            // 
            // dataGridProfesores
            // 
            dataGridProfesores.AllowUserToAddRows = false;
            dataGridProfesores.AllowUserToDeleteRows = false;
            dataGridProfesores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProfesores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProfesores.Location = new Point(12, 35);
            dataGridProfesores.Name = "dataGridProfesores";
            dataGridProfesores.ReadOnly = true;
            dataGridProfesores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProfesores.Size = new Size(560, 300);
            dataGridProfesores.TabIndex = 0;
            // 
            // checkBoxTitular
            // 
            checkBoxTitular.AutoSize = true;
            checkBoxTitular.Location = new Point(12, 350);
            checkBoxTitular.Name = "checkBoxTitular";
            checkBoxTitular.Size = new Size(158, 19);
            checkBoxTitular.TabIndex = 1;
            checkBoxTitular.Text = "Asignar como Titular";
            checkBoxTitular.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.MediumSeaGreen;
            btnAgregar.Location = new Point(497, 346);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.Control;
            btnCancelar.Location = new Point(416, 346);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(306, 19);
            label1.TabIndex = 4;
            label1.Text = "Seleccione un profesor (doble clic en la fila)";
            // 
            // CursoSeleccionProfesor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 381);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnAgregar);
            Controls.Add(checkBoxTitular);
            Controls.Add(dataGridProfesores);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CursoSeleccionProfesor";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Agregar Profesor al Curso";
            Load += CursoSeleccionProfesor_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridProfesores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridProfesores;
        private CheckBox checkBoxTitular;
        private Button btnAgregar;
        private Button btnCancelar;
        private Label label1;
    }
}