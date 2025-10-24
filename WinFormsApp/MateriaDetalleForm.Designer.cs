namespace WinFormsApp
{
    partial class MateriaDetalleForm
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

        private void InitializeComponent()
        {
            labelDesc = new Label();
            txtDesc = new TextBox();
            labelHsSem = new Label();
            numericHsSem = new NumericUpDown();
            labelHsTot = new Label();
            numericHsTot = new NumericUpDown();
            labelPlan = new Label();
            comboBoxPlan = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)numericHsSem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericHsTot).BeginInit();
            SuspendLayout();
            // 
            // labelDesc
            // 
            labelDesc.AutoSize = true;
            labelDesc.Location = new Point(20, 23);
            labelDesc.Name = "labelDesc";
            labelDesc.Size = new Size(72, 15);
            labelDesc.TabIndex = 9;
            labelDesc.Text = "Descripcion:";
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(120, 23);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(180, 23);
            txtDesc.TabIndex = 8;
            // 
            // labelHsSem
            // 
            labelHsSem.AutoSize = true;
            labelHsSem.Location = new Point(20, 67);
            labelHsSem.Name = "labelHsSem";
            labelHsSem.Size = new Size(82, 15);
            labelHsSem.TabIndex = 7;
            labelHsSem.Text = "Hs semanales:";
            // 
            // numericHsSem
            // 
            numericHsSem.Location = new Point(120, 65);
            numericHsSem.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericHsSem.Name = "numericHsSem";
            numericHsSem.Size = new Size(120, 23);
            numericHsSem.TabIndex = 6;
            // 
            // labelHsTot
            // 
            labelHsTot.AutoSize = true;
            labelHsTot.Location = new Point(20, 111);
            labelHsTot.Name = "labelHsTot";
            labelHsTot.Size = new Size(62, 15);
            labelHsTot.TabIndex = 5;
            labelHsTot.Text = "Hs totales:";
            // 
            // numericHsTot
            // 
            numericHsTot.Location = new Point(120, 109);
            numericHsTot.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericHsTot.Name = "numericHsTot";
            numericHsTot.Size = new Size(120, 23);
            numericHsTot.TabIndex = 4;
            // 
            // labelPlan
            // 
            labelPlan.AutoSize = true;
            labelPlan.Location = new Point(20, 160);
            labelPlan.Name = "labelPlan";
            labelPlan.Size = new Size(33, 15);
            labelPlan.TabIndex = 3;
            labelPlan.Text = "Plan:";
            // 
            // comboBoxPlan
            // 
            comboBoxPlan.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPlan.Location = new Point(120, 158);
            comboBoxPlan.Name = "comboBoxPlan";
            comboBoxPlan.Size = new Size(180, 23);
            comboBoxPlan.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.MediumSeaGreen;
            btnGuardar.Location = new Point(225, 205);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.Control;
            btnCancelar.Location = new Point(20, 205);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // MateriaDetalleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 240);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(comboBoxPlan);
            Controls.Add(labelPlan);
            Controls.Add(numericHsTot);
            Controls.Add(labelHsTot);
            Controls.Add(numericHsSem);
            Controls.Add(labelHsSem);
            Controls.Add(txtDesc);
            Controls.Add(labelDesc);
            Name = "MateriaDetalleForm";
            Text = "Detalle Materia";
            Load += MateriaDetalleForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericHsSem).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericHsTot).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label labelDesc;
        private TextBox txtDesc;
        private Label labelHsSem;
        private NumericUpDown numericHsSem;
        private Label labelHsTot;
        private NumericUpDown numericHsTot;
        private Label labelPlan;
        private ComboBox comboBoxPlan;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
