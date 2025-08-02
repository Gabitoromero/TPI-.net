namespace WinFormsApp
{
    partial class PlanesGetPostForm
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
            buttonListarPlanes = new Button();
            buttonBuscarPlan = new Button();
            numIDPlan = new NumericUpDown();
            buttonAgregarPlan = new Button();
            labelDescripcion = new Label();
            label2 = new Label();
            textDesc = new TextBox();
            GridPlanes = new DataGridView();
            numIDEsp = new NumericUpDown();
            GridPlan = new PropertyGrid();
            GridNuevoPlan = new PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)numIDPlan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GridPlanes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numIDEsp).BeginInit();
            SuspendLayout();
            // 
            // buttonListarPlanes
            // 
            buttonListarPlanes.Location = new Point(12, 12);
            buttonListarPlanes.Name = "buttonListarPlanes";
            buttonListarPlanes.Size = new Size(219, 52);
            buttonListarPlanes.TabIndex = 0;
            buttonListarPlanes.Text = "Listar planes";
            buttonListarPlanes.UseVisualStyleBackColor = true;
            buttonListarPlanes.Click += buttonListarPlanes_Click;
            // 
            // buttonBuscarPlan
            // 
            buttonBuscarPlan.Location = new Point(251, 12);
            buttonBuscarPlan.Name = "buttonBuscarPlan";
            buttonBuscarPlan.Size = new Size(125, 52);
            buttonBuscarPlan.TabIndex = 1;
            buttonBuscarPlan.Text = "Buscar";
            buttonBuscarPlan.UseVisualStyleBackColor = true;
            buttonBuscarPlan.Click += buttonBuscarPlan_Click;
            // 
            // numIDPlan
            // 
            numIDPlan.Location = new Point(382, 29);
            numIDPlan.Name = "numIDPlan";
            numIDPlan.Size = new Size(110, 23);
            numIDPlan.TabIndex = 2;
            // 
            // buttonAgregarPlan
            // 
            buttonAgregarPlan.Location = new Point(508, 12);
            buttonAgregarPlan.Name = "buttonAgregarPlan";
            buttonAgregarPlan.Size = new Size(263, 52);
            buttonAgregarPlan.TabIndex = 3;
            buttonAgregarPlan.Text = "Agregar plan";
            buttonAgregarPlan.UseVisualStyleBackColor = true;
            buttonAgregarPlan.Click += buttonAgregarPlan_Click;
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(508, 78);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(69, 15);
            labelDescripcion.TabIndex = 4;
            labelDescripcion.Text = "Descripcion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(508, 112);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 5;
            label2.Text = "Especialidad";
            // 
            // textDesc
            // 
            textDesc.Location = new Point(595, 75);
            textDesc.Name = "textDesc";
            textDesc.Size = new Size(176, 23);
            textDesc.TabIndex = 6;
            // 
            // GridPlanes
            // 
            GridPlanes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridPlanes.Location = new Point(12, 78);
            GridPlanes.Name = "GridPlanes";
            GridPlanes.ReadOnly = true;
            GridPlanes.Size = new Size(219, 329);
            GridPlanes.TabIndex = 10;
            // 
            // numIDEsp
            // 
            numIDEsp.Location = new Point(594, 109);
            numIDEsp.Name = "numIDEsp";
            numIDEsp.Size = new Size(176, 23);
            numIDEsp.TabIndex = 11;
            // 
            // GridPlan
            // 
            GridPlan.Location = new Point(251, 78);
            GridPlan.Name = "GridPlan";
            GridPlan.Size = new Size(241, 327);
            GridPlan.TabIndex = 12;
            // 
            // GridNuevoPlan
            // 
            GridNuevoPlan.Location = new Point(508, 138);
            GridNuevoPlan.Name = "GridNuevoPlan";
            GridNuevoPlan.Size = new Size(262, 267);
            GridNuevoPlan.TabIndex = 13;
            // 
            // PlanesGetPostForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 417);
            Controls.Add(GridNuevoPlan);
            Controls.Add(GridPlan);
            Controls.Add(numIDEsp);
            Controls.Add(GridPlanes);
            Controls.Add(textDesc);
            Controls.Add(label2);
            Controls.Add(labelDescripcion);
            Controls.Add(buttonAgregarPlan);
            Controls.Add(numIDPlan);
            Controls.Add(buttonBuscarPlan);
            Controls.Add(buttonListarPlanes);
            Name = "PlanesGetPostForm";
            Text = "PlanesForm";
            ((System.ComponentModel.ISupportInitialize)numIDPlan).EndInit();
            ((System.ComponentModel.ISupportInitialize)GridPlanes).EndInit();
            ((System.ComponentModel.ISupportInitialize)numIDEsp).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonListarPlanes;
        private Button buttonBuscarPlan;
        private NumericUpDown numIDPlan;
        private Button buttonAgregarPlan;
        private Label labelDescripcion;
        private Label label2;
        private TextBox textDesc;
        private TextBox textBox2;
        private PropertyGrid propertyGrid1;
        private PropertyGrid propertyGrid2;
        private DataGridView GridPlanes;
        private NumericUpDown numIDEsp;
        private PropertyGrid GridPlan;
        private PropertyGrid GridNuevoPlan;
    }
}