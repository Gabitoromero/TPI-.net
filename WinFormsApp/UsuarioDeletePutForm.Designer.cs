namespace WinFormsApp
{
    partial class UsuarioDeletePutForm
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
            btnListarUsuarios = new Button();
            gridUsers = new DataGridView();
            checkBoxHabilitado = new CheckBox();
            labIdUsuario = new Label();
            labNomUsuario = new Label();
            labNombre = new Label();
            labApellido = new Label();
            labEmail = new Label();
            labContr = new Label();
            textBoxIdUser = new TextBox();
            textBoxNomUser = new TextBox();
            textBoxNom = new TextBox();
            textBoxApellido = new TextBox();
            textBoxEmail = new TextBox();
            textBoxContr = new TextBox();
            btnEliminarUser = new Button();
            btnModificarUsuario = new Button();
            ((System.ComponentModel.ISupportInitialize)gridUsers).BeginInit();
            SuspendLayout();
            // 
            // btnListarUsuarios
            // 
            btnListarUsuarios.Location = new Point(28, 15);
            btnListarUsuarios.Name = "btnListarUsuarios";
            btnListarUsuarios.Size = new Size(392, 60);
            btnListarUsuarios.TabIndex = 0;
            btnListarUsuarios.Text = "Listar usuarios";
            btnListarUsuarios.UseVisualStyleBackColor = true;
            btnListarUsuarios.Click += btnListarUsuarios_Click;
            // 
            // gridUsers
            // 
            gridUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridUsers.Location = new Point(25, 81);
            gridUsers.MultiSelect = false;
            gridUsers.Name = "gridUsers";
            gridUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridUsers.Size = new Size(395, 416);
            gridUsers.TabIndex = 1;
            // 
            // checkBoxHabilitado
            // 
            checkBoxHabilitado.AutoSize = true;
            checkBoxHabilitado.Location = new Point(450, 336);
            checkBoxHabilitado.Name = "checkBoxHabilitado";
            checkBoxHabilitado.RightToLeft = RightToLeft.Yes;
            checkBoxHabilitado.Size = new Size(81, 19);
            checkBoxHabilitado.TabIndex = 2;
            checkBoxHabilitado.Text = "Habilitado";
            checkBoxHabilitado.UseVisualStyleBackColor = true;
            // 
            // labIdUsuario
            // 
            labIdUsuario.AutoSize = true;
            labIdUsuario.Location = new Point(450, 33);
            labIdUsuario.Name = "labIdUsuario";
            labIdUsuario.Size = new Size(24, 15);
            labIdUsuario.TabIndex = 3;
            labIdUsuario.Text = "ID :";
            // 
            // labNomUsuario
            // 
            labNomUsuario.AutoSize = true;
            labNomUsuario.Location = new Point(449, 82);
            labNomUsuario.Name = "labNomUsuario";
            labNomUsuario.Size = new Size(115, 15);
            labNomUsuario.TabIndex = 4;
            labNomUsuario.Text = "Nombre de usuario :";
            // 
            // labNombre
            // 
            labNombre.AutoSize = true;
            labNombre.Location = new Point(449, 135);
            labNombre.Name = "labNombre";
            labNombre.Size = new Size(57, 15);
            labNombre.TabIndex = 5;
            labNombre.Text = "Nombre :";
            labNombre.Click += labNombre_Click;
            // 
            // labApellido
            // 
            labApellido.AutoSize = true;
            labApellido.Location = new Point(449, 183);
            labApellido.Name = "labApellido";
            labApellido.Size = new Size(57, 15);
            labApellido.TabIndex = 6;
            labApellido.Text = "Apellido :";
            // 
            // labEmail
            // 
            labEmail.AutoSize = true;
            labEmail.Location = new Point(450, 240);
            labEmail.Name = "labEmail";
            labEmail.Size = new Size(42, 15);
            labEmail.TabIndex = 7;
            labEmail.Text = "Email :";
            // 
            // labContr
            // 
            labContr.AutoSize = true;
            labContr.Location = new Point(449, 288);
            labContr.Name = "labContr";
            labContr.Size = new Size(42, 15);
            labContr.TabIndex = 8;
            labContr.Text = "Clave :";
            labContr.Click += label5_Click;
            // 
            // textBoxIdUser
            // 
            textBoxIdUser.Enabled = false;
            textBoxIdUser.Location = new Point(596, 33);
            textBoxIdUser.Name = "textBoxIdUser";
            textBoxIdUser.Size = new Size(275, 23);
            textBoxIdUser.TabIndex = 9;
            textBoxIdUser.TextChanged += textBoxIdUser_TextChanged;
            // 
            // textBoxNomUser
            // 
            textBoxNomUser.Location = new Point(596, 82);
            textBoxNomUser.Name = "textBoxNomUser";
            textBoxNomUser.Size = new Size(275, 23);
            textBoxNomUser.TabIndex = 10;
            // 
            // textBoxNom
            // 
            textBoxNom.Location = new Point(596, 127);
            textBoxNom.Name = "textBoxNom";
            textBoxNom.Size = new Size(275, 23);
            textBoxNom.TabIndex = 11;
            // 
            // textBoxApellido
            // 
            textBoxApellido.Location = new Point(596, 183);
            textBoxApellido.Name = "textBoxApellido";
            textBoxApellido.Size = new Size(275, 23);
            textBoxApellido.TabIndex = 12;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(596, 237);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(275, 23);
            textBoxEmail.TabIndex = 13;
            // 
            // textBoxContr
            // 
            textBoxContr.Location = new Point(596, 288);
            textBoxContr.Name = "textBoxContr";
            textBoxContr.Size = new Size(275, 23);
            textBoxContr.TabIndex = 14;
            // 
            // btnEliminarUser
            // 
            btnEliminarUser.BackColor = Color.IndianRed;
            btnEliminarUser.Location = new Point(676, 425);
            btnEliminarUser.Name = "btnEliminarUser";
            btnEliminarUser.Size = new Size(195, 54);
            btnEliminarUser.TabIndex = 15;
            btnEliminarUser.Text = "Eliminar";
            btnEliminarUser.UseVisualStyleBackColor = false;
            btnEliminarUser.Click += btnEliminarUser_Click;
            // 
            // btnModificarUsuario
            // 
            btnModificarUsuario.Location = new Point(450, 425);
            btnModificarUsuario.Name = "btnModificarUsuario";
            btnModificarUsuario.Size = new Size(220, 54);
            btnModificarUsuario.TabIndex = 16;
            btnModificarUsuario.Text = "Modificar";
            btnModificarUsuario.UseVisualStyleBackColor = true;
            btnModificarUsuario.Click += btnModificarUsuario_Click;
            // 
            // UsuarioDeletePutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(908, 508);
            Controls.Add(btnModificarUsuario);
            Controls.Add(btnEliminarUser);
            Controls.Add(textBoxContr);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxApellido);
            Controls.Add(textBoxNom);
            Controls.Add(textBoxNomUser);
            Controls.Add(textBoxIdUser);
            Controls.Add(labContr);
            Controls.Add(labEmail);
            Controls.Add(labApellido);
            Controls.Add(labNombre);
            Controls.Add(labNomUsuario);
            Controls.Add(labIdUsuario);
            Controls.Add(checkBoxHabilitado);
            Controls.Add(gridUsers);
            Controls.Add(btnListarUsuarios);
            Name = "UsuarioDeletePutForm";
            Text = "UsuarioDeletePut";
            Load += UsuarioDeletePutForm_Load;
            ((System.ComponentModel.ISupportInitialize)gridUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnListarUsuarios;
        private DataGridView gridUsers;
        private CheckBox checkBoxHabilitado;
        private Label labIdUsuario;
        private Label labNomUsuario;
        private Label labNombre;
        private Label labApellido;
        private Label labEmail;
        private Label labContr;
        private TextBox textBoxIdUser;
        private TextBox textBoxNomUser;
        private TextBox textBoxNom;
        private TextBox textBoxApellido;
        private TextBox textBoxEmail;
        private TextBox textBoxContr;
        private Button btnEliminarUser;
        private Button btnModificarUsuario;
    }
}