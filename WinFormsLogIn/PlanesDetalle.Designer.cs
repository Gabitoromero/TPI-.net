namespace WindowsForms
{
    partial class PlanesDetalle
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
            labelIdPlan = new Label();
            textIdPlan = new TextBox();
            label1 = new Label();
            textDesc = new TextBox();
            label2 = new Label();
            textIdEsp = new TextBox();
            buttonAceptarPlan = new Button();
            buttonCancelarPlan = new Button();
            SuspendLayout();
            // 
            // labelIdPlan
            // 
            labelIdPlan.AutoSize = true;
            labelIdPlan.Location = new Point(111, 66);
            labelIdPlan.Name = "labelIdPlan";
            labelIdPlan.Size = new Size(43, 15);
            labelIdPlan.TabIndex = 0;
            labelIdPlan.Text = "Id Plan";
            labelIdPlan.Click += label1_Click;
            // 
            // textIdPlan
            // 
            textIdPlan.Enabled = false;
            textIdPlan.Location = new Point(203, 66);
            textIdPlan.Name = "textIdPlan";
            textIdPlan.Size = new Size(153, 23);
            textIdPlan.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(111, 124);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 2;
            label1.Text = "Descripcion";
            label1.Click += label1_Click_1;
            // 
            // textDesc
            // 
            textDesc.Enabled = false;
            textDesc.Location = new Point(203, 121);
            textDesc.Name = "textDesc";
            textDesc.Size = new Size(153, 23);
            textDesc.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(111, 182);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 4;
            label2.Text = "Id Especialidad";
            // 
            // textIdEsp
            // 
            textIdEsp.Enabled = false;
            textIdEsp.Location = new Point(203, 182);
            textIdEsp.Name = "textIdEsp";
            textIdEsp.Size = new Size(153, 23);
            textIdEsp.TabIndex = 5;
            // 
            // buttonAceptarPlan
            // 
            buttonAceptarPlan.Location = new Point(355, 271);
            buttonAceptarPlan.Name = "buttonAceptarPlan";
            buttonAceptarPlan.Size = new Size(75, 23);
            buttonAceptarPlan.TabIndex = 6;
            buttonAceptarPlan.Text = "Aceptar";
            buttonAceptarPlan.UseVisualStyleBackColor = true;
            // 
            // buttonCancelarPlan
            // 
            buttonCancelarPlan.Location = new Point(448, 271);
            buttonCancelarPlan.Name = "buttonCancelarPlan";
            buttonCancelarPlan.Size = new Size(75, 23);
            buttonCancelarPlan.TabIndex = 7;
            buttonCancelarPlan.Text = "Cancelar";
            buttonCancelarPlan.UseVisualStyleBackColor = true;
            // 
            // PlanesDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 306);
            Controls.Add(buttonCancelarPlan);
            Controls.Add(buttonAceptarPlan);
            Controls.Add(textIdEsp);
            Controls.Add(label2);
            Controls.Add(textDesc);
            Controls.Add(label1);
            Controls.Add(textIdPlan);
            Controls.Add(labelIdPlan);
            Name = "PlanesDetalle";
            Text = "PlanesDetalle";
            Load += PlanesDetalle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelIdPlan;
        private TextBox textIdPlan;
        private Label label1;
        private TextBox textDesc;
        private Label label2;
        private TextBox textIdEsp;
        private Button buttonAceptarPlan;
        private Button buttonCancelarPlan;
    }
}