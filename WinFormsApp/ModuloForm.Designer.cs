namespace WinFormsApp
{
    partial class ModuloForm
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
        private System.Windows.Forms.NumericUpDown numIDModulo;
        private System.Windows.Forms.Button btnListarModulos;
        private System.Windows.Forms.Button btnBuscarModulo;
        private System.Windows.Forms.Button btnAgregarModulo;
        private System.Windows.Forms.Label labelID;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GridModulos = new DataGridView();
            GridModulo = new PropertyGrid();
            numIDModulo = new NumericUpDown();
            btnListarModulos = new Button();
            btnBuscarModulo = new Button();
            btnAgregarModulo = new Button();
            labelID = new Label();
            btnModificarModulo = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)GridModulos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numIDModulo).BeginInit();
            SuspendLayout();
            // 
            // GridModulos
            // 
            GridModulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridModulos.Location = new Point(14, 60);
            GridModulos.Name = "GridModulos";
            GridModulos.ReadOnly = true;
            GridModulos.Size = new Size(233, 228);
            GridModulos.TabIndex = 0;
            // 
            // GridModulo
            // 
            GridModulo.Enabled = false;
            GridModulo.Location = new Point(253, 100);
            GridModulo.Name = "GridModulo";
            GridModulo.Size = new Size(292, 188);
            GridModulo.TabIndex = 1;
            // 
            // numIDModulo
            // 
            numIDModulo.Location = new Point(407, 21);
            numIDModulo.Name = "numIDModulo";
            numIDModulo.Size = new Size(120, 23);
            numIDModulo.TabIndex = 3;
            // 
            // btnListarModulos
            // 
            btnListarModulos.Location = new Point(14, 8);
            btnListarModulos.Name = "btnListarModulos";
            btnListarModulos.Size = new Size(233, 46);
            btnListarModulos.TabIndex = 5;
            btnListarModulos.Text = "Listar módulos";
            btnListarModulos.UseVisualStyleBackColor = true;
            btnListarModulos.Click += buttonListarModulos_Click;
            // 
            // btnBuscarModulo
            // 
            btnBuscarModulo.Location = new Point(253, 60);
            btnBuscarModulo.Name = "btnBuscarModulo";
            btnBuscarModulo.Size = new Size(292, 34);
            btnBuscarModulo.TabIndex = 6;
            btnBuscarModulo.Text = "Buscar";
            btnBuscarModulo.UseVisualStyleBackColor = true;
            btnBuscarModulo.Click += buttonBuscarModulo_Click;
            // 
            // btnAgregarModulo
            // 
            btnAgregarModulo.Location = new Point(111, 308);
            btnAgregarModulo.Name = "btnAgregarModulo";
            btnAgregarModulo.Size = new Size(91, 30);
            btnAgregarModulo.TabIndex = 7;
            btnAgregarModulo.Text = "Agregar +";
            btnAgregarModulo.UseVisualStyleBackColor = true;
            btnAgregarModulo.Click += buttonAgregarModulo_Click;
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Location = new Point(299, 23);
            labelID.Name = "labelID";
            labelID.Size = new Size(83, 15);
            labelID.TabIndex = 8;
            labelID.Text = "Buscar por ID :";
            // 
            // btnModificarModulo
            // 
            btnModificarModulo.Location = new Point(345, 308);
            btnModificarModulo.Name = "btnModificarModulo";
            btnModificarModulo.Size = new Size(127, 30);
            btnModificarModulo.TabIndex = 11;
            btnModificarModulo.Text = "Modificar";
            btnModificarModulo.Click += btnModificarModulo_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.IndianRed;
            btnCerrar.Location = new Point(14, 308);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(91, 30);
            btnCerrar.TabIndex = 10;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // ModuloForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(565, 350);
            Controls.Add(btnCerrar);
            Controls.Add(btnModificarModulo);
            Controls.Add(labelID);
            Controls.Add(btnAgregarModulo);
            Controls.Add(btnBuscarModulo);
            Controls.Add(btnListarModulos);
            Controls.Add(numIDModulo);
            Controls.Add(GridModulo);
            Controls.Add(GridModulos);
            Name = "ModuloForm";
            Text = "Gestión de Módulos";
            Load += ModulosGetPostForm_Load;
            ((System.ComponentModel.ISupportInitialize)GridModulos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numIDModulo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnModificarModulo;
        private Button btnCerrar;
    }
}
