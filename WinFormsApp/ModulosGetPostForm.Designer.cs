namespace WinFormsApp
{
    partial class ModulosGetPostForm
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

        private System.Windows.Forms.DataGridView GridModulos;
        private System.Windows.Forms.PropertyGrid GridModulo;
        private System.Windows.Forms.PropertyGrid GridNuevoModulo;
        private System.Windows.Forms.NumericUpDown numIDModulo;
        private System.Windows.Forms.TextBox textDesc;
        private System.Windows.Forms.Button buttonListarModulos;
        private System.Windows.Forms.Button buttonBuscarModulo;
        private System.Windows.Forms.Button buttonAgregarModulo;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelDesc;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GridModulos = new DataGridView();
            GridModulo = new PropertyGrid();
            GridNuevoModulo = new PropertyGrid();
            numIDModulo = new NumericUpDown();
            textDesc = new TextBox();
            buttonListarModulos = new Button();
            buttonBuscarModulo = new Button();
            buttonAgregarModulo = new Button();
            labelID = new Label();
            labelDesc = new Label();
            ((System.ComponentModel.ISupportInitialize)GridModulos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numIDModulo).BeginInit();
            SuspendLayout();
            // 
            // GridModulos
            // 
            GridModulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridModulos.Location = new Point(12, 12);
            GridModulos.Name = "GridModulos";
            GridModulos.ReadOnly = true;
            GridModulos.Size = new Size(360, 200);
            GridModulos.TabIndex = 0;
            // 
            // GridModulo
            // 
            GridModulo.Location = new Point(400, 12);
            GridModulo.Name = "GridModulo";
            GridModulo.Size = new Size(380, 200);
            GridModulo.TabIndex = 1;
            // 
            // GridNuevoModulo
            // 
            GridNuevoModulo.Location = new Point(400, 225);
            GridNuevoModulo.Name = "GridNuevoModulo";
            GridNuevoModulo.Size = new Size(380, 200);
            GridNuevoModulo.TabIndex = 2;
            // 
            // numIDModulo
            // 
            numIDModulo.Location = new Point(100, 225);
            numIDModulo.Name = "numIDModulo";
            numIDModulo.Size = new Size(120, 23);
            numIDModulo.TabIndex = 3;
            // 
            // textDesc
            // 
            textDesc.Location = new Point(100, 260);
            textDesc.Name = "textDesc";
            textDesc.Size = new Size(200, 23);
            textDesc.TabIndex = 4;
            // 
            // buttonListarModulos
            // 
            buttonListarModulos.Location = new Point(12, 300);
            buttonListarModulos.Name = "buttonListarModulos";
            buttonListarModulos.Size = new Size(120, 30);
            buttonListarModulos.TabIndex = 5;
            buttonListarModulos.Text = "Listar Módulos";
            buttonListarModulos.UseVisualStyleBackColor = true;
            buttonListarModulos.Click += buttonListarModulos_Click;
            // 
            // buttonBuscarModulo
            // 
            buttonBuscarModulo.Location = new Point(138, 300);
            buttonBuscarModulo.Name = "buttonBuscarModulo";
            buttonBuscarModulo.Size = new Size(120, 30);
            buttonBuscarModulo.TabIndex = 6;
            buttonBuscarModulo.Text = "Buscar Módulo";
            buttonBuscarModulo.UseVisualStyleBackColor = true;
            buttonBuscarModulo.Click += buttonBuscarModulo_Click;
            // 
            // buttonAgregarModulo
            // 
            buttonAgregarModulo.Location = new Point(264, 300);
            buttonAgregarModulo.Name = "buttonAgregarModulo";
            buttonAgregarModulo.Size = new Size(120, 30);
            buttonAgregarModulo.TabIndex = 7;
            buttonAgregarModulo.Text = "Agregar Módulo";
            buttonAgregarModulo.UseVisualStyleBackColor = true;
            buttonAgregarModulo.Click += buttonAgregarModulo_Click;
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Location = new Point(12, 227);
            labelID.Name = "labelID";
            labelID.Size = new Size(85, 15);
            labelID.TabIndex = 8;
            labelID.Text = "ID del Módulo:";
            // 
            // labelDesc
            // 
            labelDesc.AutoSize = true;
            labelDesc.Location = new Point(12, 263);
            labelDesc.Name = "labelDesc";
            labelDesc.Size = new Size(72, 15);
            labelDesc.TabIndex = 9;
            labelDesc.Text = "Descripción:";
            // 
            // ModulosGetPostForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelDesc);
            Controls.Add(labelID);
            Controls.Add(buttonAgregarModulo);
            Controls.Add(buttonBuscarModulo);
            Controls.Add(buttonListarModulos);
            Controls.Add(textDesc);
            Controls.Add(numIDModulo);
            Controls.Add(GridNuevoModulo);
            Controls.Add(GridModulo);
            Controls.Add(GridModulos);
            Name = "ModulosGetPostForm";
            Text = "Gestión de Módulos";
            ((System.ComponentModel.ISupportInitialize)GridModulos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numIDModulo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
