namespace WinFormsApp
{
    partial class ModulosDeletePutForm
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
            buttonListarModulos = new Button();
            GridModulos = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            textIDModulo = new TextBox();
            textDescripcion = new TextBox();
            buttonModificarModulo = new Button();
            buttonEliminarModulo = new Button();
            ((System.ComponentModel.ISupportInitialize)GridModulos).BeginInit();
            SuspendLayout();
            // 
            // buttonListarModulos
            // 
            buttonListarModulos.Location = new Point(24, 22);
            buttonListarModulos.Name = "buttonListarModulos";
            buttonListarModulos.Size = new Size(403, 39);
            buttonListarModulos.TabIndex = 0;
            buttonListarModulos.Text = "Listar módulos";
            buttonListarModulos.UseVisualStyleBackColor = true;
            buttonListarModulos.Click += buttonListarModulos_Click;
            // 
            // GridModulos
            // 
            GridModulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridModulos.Location = new Point(24, 76);
            GridModulos.MultiSelect = false;
            GridModulos.Name = "GridModulos";
            GridModulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridModulos.Size = new Size(403, 350);
            GridModulos.TabIndex = 1;
            GridModulos.SelectionChanged += GridModulos_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(447, 76);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 2;
            label1.Text = "ID Módulo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(447, 132);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 3;
            label2.Text = "Descripción";
            // 
            // textIDModulo
            // 
            textIDModulo.BackColor = SystemColors.InactiveBorder;
            textIDModulo.Enabled = false;
            textIDModulo.Location = new Point(525, 73);
            textIDModulo.Name = "textIDModulo";
            textIDModulo.Size = new Size(241, 23);
            textIDModulo.TabIndex = 4;
            // 
            // textDescripcion
            // 
            textDescripcion.Location = new Point(525, 129);
            textDescripcion.Name = "textDescripcion";
            textDescripcion.Size = new Size(241, 23);
            textDescripcion.TabIndex = 5;
            // 
            // buttonModificarModulo
            // 
            buttonModificarModulo.Location = new Point(467, 391);
            buttonModificarModulo.Name = "buttonModificarModulo";
            buttonModificarModulo.Size = new Size(140, 35);
            buttonModificarModulo.TabIndex = 6;
            buttonModificarModulo.Text = "Modificar";
            buttonModificarModulo.UseVisualStyleBackColor = true;
            buttonModificarModulo.Click += buttonModificarModulo_Click;
            // 
            // buttonEliminarModulo
            // 
            buttonEliminarModulo.Location = new Point(626, 391);
            buttonEliminarModulo.Name = "buttonEliminarModulo";
            buttonEliminarModulo.Size = new Size(140, 35);
            buttonEliminarModulo.TabIndex = 7;
            buttonEliminarModulo.Text = "Eliminar";
            buttonEliminarModulo.UseVisualStyleBackColor = true;
            buttonEliminarModulo.Click += buttonEliminarModulo_Click;
            // 
            // ModulosDeletePutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonEliminarModulo);
            Controls.Add(buttonModificarModulo);
            Controls.Add(textDescripcion);
            Controls.Add(textIDModulo);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(GridModulos);
            Controls.Add(buttonListarModulos);
            Name = "ModulosDeletePutForm";
            Text = "Módulos - Modificar / Eliminar";
            Load += ModulosDeletePutForm_Load;
            ((System.ComponentModel.ISupportInitialize)GridModulos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonListarModulos;
        private DataGridView GridModulos;
        private Label label1;
        private Label label2;
        private TextBox textIDModulo;
        private TextBox textDescripcion;
        private Button buttonModificarModulo;
        private Button buttonEliminarModulo;
    }
}
