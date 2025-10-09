namespace WinFormsApp
{
    partial class ComisionDetalleForm
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
            labelAnio = new Label();
            numericAnio = new NumericUpDown();
            labelPlan = new Label();
            comboBoxPlan = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)numericAnio).BeginInit();
            SuspendLayout();
            // 
            // labelDesc
            // 
            labelDesc.AutoSize = true;
            labelDesc.Location = new Point(20, 27);
            labelDesc.Name = "labelDesc";
            labelDesc.Size = new Size(72, 15);
            labelDesc.TabIndex = 7;
            labelDesc.Text = "Descripcion:";
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(120, 24);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(180, 23);
            txtDesc.TabIndex = 6;
            // 
            // labelAnio
            // 
            labelAnio.AutoSize = true;
            labelAnio.Location = new Point(20, 70);
            labelAnio.Name = "labelAnio";
            labelAnio.Size = new Size(100, 15);
            labelAnio.TabIndex = 5;
            labelAnio.Text = "Año especialidad:";
            // 
            // numericAnio
            // 
            numericAnio.Location = new Point(180, 68);
            numericAnio.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericAnio.Name = "numericAnio";
            numericAnio.Size = new Size(120, 23);
            numericAnio.TabIndex = 4;
            // 
            // labelPlan
            // 
            labelPlan.AutoSize = true;
            labelPlan.Location = new Point(20, 114);
            labelPlan.Name = "labelPlan";
            labelPlan.Size = new Size(33, 15);
            labelPlan.TabIndex = 3;
            labelPlan.Text = "Plan:";
            // 
            // comboBoxPlan
            // 
            comboBoxPlan.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPlan.Location = new Point(120, 111);
            comboBoxPlan.Name = "comboBoxPlan";
            comboBoxPlan.Size = new Size(180, 23);
            comboBoxPlan.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.ActiveCaption;
            btnGuardar.Location = new Point(221, 165);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.Location = new Point(19, 165);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // ComisionDetalleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 200);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(comboBoxPlan);
            Controls.Add(labelPlan);
            Controls.Add(numericAnio);
            Controls.Add(labelAnio);
            Controls.Add(txtDesc);
            Controls.Add(labelDesc);
            Name = "ComisionDetalleForm";
            Text = "Detalle Comision";
            Load += ComisionDetalleForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericAnio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label labelDesc;
        private TextBox txtDesc;
        private Label labelAnio;
        private NumericUpDown numericAnio;
        private Label labelPlan;
        private ComboBox comboBoxPlan;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
