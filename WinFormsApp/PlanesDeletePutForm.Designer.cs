namespace WinFormsApp
{
    partial class PlanesDeletePutForm
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
            GridPlanes = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textIDPlan = new TextBox();
            textDesc = new TextBox();
            buttonModificarPlan = new Button();
            buttonEliminarPlan = new Button();
            numIDEsp = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)GridPlanes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numIDEsp).BeginInit();
            SuspendLayout();
            // 
            // buttonListarPlanes
            // 
            buttonListarPlanes.Location = new Point(24, 22);
            buttonListarPlanes.Name = "buttonListarPlanes";
            buttonListarPlanes.Size = new Size(403, 39);
            buttonListarPlanes.TabIndex = 0;
            buttonListarPlanes.Text = "Listar planes";
            buttonListarPlanes.UseVisualStyleBackColor = true;
            buttonListarPlanes.Click += buttonListarPlanes_Click;
            // 
            // GridPlanes
            // 
            GridPlanes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridPlanes.Location = new Point(24, 76);
            GridPlanes.MultiSelect = false;
            GridPlanes.Name = "GridPlanes";
            GridPlanes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridPlanes.Size = new Size(403, 350);
            GridPlanes.TabIndex = 1;
            GridPlanes.SelectionChanged += GridPlanes_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(447, 76);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 2;
            label1.Text = "ID Plan";
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(447, 186);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 4;
            label3.Text = "Especialidad";
            // 
            // textIDPlan
            // 
            textIDPlan.BackColor = SystemColors.InactiveBorder;
            textIDPlan.Enabled = false;
            textIDPlan.Location = new Point(525, 73);
            textIDPlan.Name = "textIDPlan";
            textIDPlan.Size = new Size(241, 23);
            textIDPlan.TabIndex = 5;
            // 
            // textDesc
            // 
            textDesc.Location = new Point(525, 129);
            textDesc.Name = "textDesc";
            textDesc.Size = new Size(241, 23);
            textDesc.TabIndex = 6;
            // 
            // buttonModificarPlan
            // 
            buttonModificarPlan.Location = new Point(467, 391);
            buttonModificarPlan.Name = "buttonModificarPlan";
            buttonModificarPlan.Size = new Size(140, 35);
            buttonModificarPlan.TabIndex = 8;
            buttonModificarPlan.Text = "Modificar";
            buttonModificarPlan.UseVisualStyleBackColor = true;
            buttonModificarPlan.Click += buttonModificarPlan_Click;
            // 
            // buttonEliminarPlan
            // 
            buttonEliminarPlan.Location = new Point(626, 391);
            buttonEliminarPlan.Name = "buttonEliminarPlan";
            buttonEliminarPlan.Size = new Size(140, 35);
            buttonEliminarPlan.TabIndex = 9;
            buttonEliminarPlan.Text = "Eliminar";
            buttonEliminarPlan.UseVisualStyleBackColor = true;
            buttonEliminarPlan.Click += buttonEliminarPlan_Click;
            // 
            // numIDEsp
            // 
            numIDEsp.Location = new Point(525, 184);
            numIDEsp.Name = "numIDEsp";
            numIDEsp.Size = new Size(241, 23);
            numIDEsp.TabIndex = 10;
            // 
            // PlanesDeletePutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(numIDEsp);
            Controls.Add(buttonEliminarPlan);
            Controls.Add(buttonModificarPlan);
            Controls.Add(textDesc);
            Controls.Add(textIDPlan);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(GridPlanes);
            Controls.Add(buttonListarPlanes);
            Name = "PlanesDeletePutForm";
            Text = "PlanesDeletePutForm";
            Load += PlanesDeletePutForm_Load;
            ((System.ComponentModel.ISupportInitialize)GridPlanes).EndInit();
            ((System.ComponentModel.ISupportInitialize)numIDEsp).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonListarPlanes;
        private DataGridView GridPlanes;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textIDPlan;
        private TextBox textDesc;
        private Button buttonModificarPlan;
        private Button buttonEliminarPlan;
        private NumericUpDown numIDEsp;
    }
}