namespace WinFormsApp
{
    partial class UsuarioForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gridUsuarios = new DataGridView();
            btnListar = new Button();
            btnMostrarUnUser = new Button();
            numUpDownIdUser = new NumericUpDown();
            gridUnicoUsuario = new PropertyGrid();
            btnAddUsuario = new Button();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtNombreUsuario = new TextBox();
            txtEmail = new TextBox();
            txtClave = new TextBox();
            labelNombre = new Label();
            labelApellido = new Label();
            labelNombreUsuario = new Label();
            labelEmail = new Label();
            labelClave = new Label();
            gridNuevoUsuario = new PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)gridUsuarios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numUpDownIdUser).BeginInit();
            SuspendLayout();
            // 
            // gridUsuarios
            // 
            gridUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridUsuarios.Location = new Point(12, 68);
            gridUsuarios.Name = "gridUsuarios";
            gridUsuarios.Size = new Size(316, 445);
            gridUsuarios.TabIndex = 0;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(12, 6);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(316, 56);
            btnListar.TabIndex = 1;
            btnListar.Text = "Listar usuarios";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // btnMostrarUnUser
            // 
            btnMostrarUnUser.Location = new Point(349, 6);
            btnMostrarUnUser.Name = "btnMostrarUnUser";
            btnMostrarUnUser.Size = new Size(187, 56);
            btnMostrarUnUser.TabIndex = 3;
            btnMostrarUnUser.Text = "Buscar";
            btnMostrarUnUser.UseVisualStyleBackColor = true;
            btnMostrarUnUser.Click += btnMostrarUno_Click;
            // 
            // numUpDownIdUser
            // 
            numUpDownIdUser.Location = new Point(542, 25);
            numUpDownIdUser.Name = "numUpDownIdUser";
            numUpDownIdUser.Size = new Size(130, 23);
            numUpDownIdUser.TabIndex = 4;
            // 
            // gridUnicoUsuario
            // 
            gridUnicoUsuario.Location = new Point(344, 68);
            gridUnicoUsuario.Name = "gridUnicoUsuario";
            gridUnicoUsuario.Size = new Size(328, 445);
            gridUnicoUsuario.TabIndex = 5;
            // 
            // btnAddUsuario
            // 
            btnAddUsuario.Location = new Point(680, 6);
            btnAddUsuario.Name = "btnAddUsuario";
            btnAddUsuario.Size = new Size(327, 56);
            btnAddUsuario.TabIndex = 6;
            btnAddUsuario.Text = "Agregar usuario";
            btnAddUsuario.UseVisualStyleBackColor = true;
            btnAddUsuario.Click += btnAddUsuario_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(790, 68);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(217, 23);
            txtNombre.TabIndex = 7;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(790, 97);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(217, 23);
            txtApellido.TabIndex = 8;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(790, 124);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(217, 23);
            txtNombreUsuario.TabIndex = 9;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(790, 153);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(217, 23);
            txtEmail.TabIndex = 10;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(790, 182);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(220, 23);
            txtClave.TabIndex = 11;
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(691, 68);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(54, 15);
            labelNombre.TabIndex = 12;
            labelNombre.Text = "Nombre:";
            // 
            // labelApellido
            // 
            labelApellido.AutoSize = true;
            labelApellido.Location = new Point(691, 100);
            labelApellido.Name = "labelApellido";
            labelApellido.Size = new Size(54, 15);
            labelApellido.TabIndex = 13;
            labelApellido.Text = "Apellido:";
            // 
            // labelNombreUsuario
            // 
            labelNombreUsuario.AutoSize = true;
            labelNombreUsuario.Location = new Point(688, 132);
            labelNombreUsuario.Name = "labelNombreUsuario";
            labelNombreUsuario.Size = new Size(96, 15);
            labelNombreUsuario.TabIndex = 14;
            labelNombreUsuario.Text = "Nombre usuario:";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(691, 160);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(39, 15);
            labelEmail.TabIndex = 15;
            labelEmail.Text = "Email:";
            // 
            // labelClave
            // 
            labelClave.AutoSize = true;
            labelClave.Location = new Point(691, 190);
            labelClave.Name = "labelClave";
            labelClave.Size = new Size(39, 15);
            labelClave.TabIndex = 16;
            labelClave.Text = "Clave:";
            // 
            // gridNuevoUsuario
            // 
            gridNuevoUsuario.Location = new Point(691, 211);
            gridNuevoUsuario.Name = "gridNuevoUsuario";
            gridNuevoUsuario.Size = new Size(319, 302);
            gridNuevoUsuario.TabIndex = 17;
            // 
            // UsuarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1019, 525);
            Controls.Add(gridNuevoUsuario);
            Controls.Add(labelClave);
            Controls.Add(labelEmail);
            Controls.Add(labelNombreUsuario);
            Controls.Add(labelApellido);
            Controls.Add(labelNombre);
            Controls.Add(txtClave);
            Controls.Add(txtEmail);
            Controls.Add(txtNombreUsuario);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(btnAddUsuario);
            Controls.Add(gridUnicoUsuario);
            Controls.Add(numUpDownIdUser);
            Controls.Add(btnMostrarUnUser);
            Controls.Add(btnListar);
            Controls.Add(gridUsuarios);
            Name = "UsuarioForm";
            Text = "Usuarios";
            ((System.ComponentModel.ISupportInitialize)gridUsuarios).EndInit();
            ((System.ComponentModel.ISupportInitialize)numUpDownIdUser).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridUsuarios;
        private Button btnListar;
        private TextBox txtNombre;
        private Button btnMostrarUnUser;
        private NumericUpDown numericUpDown1;
        private PropertyGrid propertyGridUsuario;
        private NumericUpDown numericUpDownID;
        private NumericUpDown numUpDownIdUser;
        private PropertyGrid GridUnicoUsuario;
        private PropertyGrid gridUnicoUsuario;
        private Button btnAddUsuario;
        private TextBox txtApellido;
        private TextBox txtNombreUsuario;
        private TextBox txtEmail;
        private TextBox txtClave;
        private Label labelNombre;
        private Label labelApellido;
        private Label labelNombreUsuario;
        private Label labelEmail;
        private Label labelClave;
        private PropertyGrid gridNuevoUsuario;
    }
}
