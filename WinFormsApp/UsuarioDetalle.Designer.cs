namespace WinFormsApp
{
    partial class UsuarioDetalle
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
            btnGuardar = new Button();
            Id = new Label();
            nombre = new Label();
            apellido = new Label();
            email = new Label();
            nombreUsuario = new Label();
            clave = new Label();
            habilitado = new Label();
            textBoxId = new TextBox();
            textBoxNombre = new TextBox();
            textBoxApellido = new TextBox();
            textBoxNomUsuario = new TextBox();
            textBoxEmail = new TextBox();
            textBoxClave = new TextBox();
            checkBoxHabilitado = new CheckBox();
            fechaAlta = new Label();
            textBoxFechaAlta = new TextBox();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.MediumSeaGreen;
            btnGuardar.Location = new Point(124, 350);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(189, 26);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += this.btnGuardar_Click;
            // 
            // Id
            // 
            Id.AutoSize = true;
            Id.Location = new Point(31, 28);
            Id.Name = "Id";
            Id.Size = new Size(23, 15);
            Id.TabIndex = 1;
            Id.Text = "Id :";
            // 
            // nombre
            // 
            nombre.AutoSize = true;
            nombre.Location = new Point(31, 62);
            nombre.Name = "nombre";
            nombre.Size = new Size(57, 15);
            nombre.TabIndex = 2;
            nombre.Text = "Nombre :";
            // 
            // apellido
            // 
            apellido.AutoSize = true;
            apellido.Location = new Point(31, 99);
            apellido.Name = "apellido";
            apellido.Size = new Size(57, 15);
            apellido.TabIndex = 3;
            apellido.Text = "Apellido :";
            // 
            // email
            // 
            email.AutoSize = true;
            email.Location = new Point(31, 182);
            email.Name = "email";
            email.Size = new Size(42, 15);
            email.TabIndex = 4;
            email.Text = "Email :";
            // 
            // nombreUsuario
            // 
            nombreUsuario.AutoSize = true;
            nombreUsuario.Location = new Point(31, 138);
            nombreUsuario.Name = "nombreUsuario";
            nombreUsuario.Size = new Size(115, 15);
            nombreUsuario.TabIndex = 5;
            nombreUsuario.Text = "Nombre de usuario :";
            // 
            // clave
            // 
            clave.AutoSize = true;
            clave.Location = new Point(31, 222);
            clave.Name = "clave";
            clave.Size = new Size(73, 15);
            clave.TabIndex = 6;
            clave.Text = "Contraseña :";
            // 
            // habilitado
            // 
            habilitado.AutoSize = true;
            habilitado.Location = new Point(31, 259);
            habilitado.Name = "habilitado";
            habilitado.Size = new Size(68, 15);
            habilitado.TabIndex = 7;
            habilitado.Text = "Habilitado :";
            // 
            // textBoxId
            // 
            textBoxId.Enabled = false;
            textBoxId.Location = new Point(172, 25);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new Size(100, 23);
            textBoxId.TabIndex = 8;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(172, 59);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(189, 23);
            textBoxNombre.TabIndex = 9;
            // 
            // textBoxApellido
            // 
            textBoxApellido.Location = new Point(172, 96);
            textBoxApellido.Name = "textBoxApellido";
            textBoxApellido.Size = new Size(189, 23);
            textBoxApellido.TabIndex = 10;
            // 
            // textBoxNomUsuario
            // 
            textBoxNomUsuario.Location = new Point(172, 135);
            textBoxNomUsuario.Name = "textBoxNomUsuario";
            textBoxNomUsuario.Size = new Size(189, 23);
            textBoxNomUsuario.TabIndex = 11;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(172, 179);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(189, 23);
            textBoxEmail.TabIndex = 12;
            // 
            // textBoxClave
            // 
            textBoxClave.Location = new Point(172, 219);
            textBoxClave.Name = "textBoxClave";
            textBoxClave.Size = new Size(189, 23);
            textBoxClave.TabIndex = 13;
            // 
            // checkBoxHabilitado
            // 
            checkBoxHabilitado.AutoSize = true;
            checkBoxHabilitado.Location = new Point(208, 260);
            checkBoxHabilitado.Name = "checkBoxHabilitado";
            checkBoxHabilitado.Size = new Size(15, 14);
            checkBoxHabilitado.TabIndex = 14;
            checkBoxHabilitado.UseVisualStyleBackColor = true;
            // 
            // fechaAlta
            // 
            fechaAlta.AutoSize = true;
            fechaAlta.Location = new Point(31, 297);
            fechaAlta.Name = "fechaAlta";
            fechaAlta.Size = new Size(82, 15);
            fechaAlta.TabIndex = 15;
            fechaAlta.Text = "Fecha de alta :";
            // 
            // textBoxFechaAlta
            // 
            textBoxFechaAlta.Enabled = false;
            textBoxFechaAlta.Location = new Point(172, 294);
            textBoxFechaAlta.Name = "textBoxFechaAlta";
            textBoxFechaAlta.Size = new Size(189, 23);
            textBoxFechaAlta.TabIndex = 16;
            // 
            // UsuarioDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 388);
            Controls.Add(textBoxFechaAlta);
            Controls.Add(fechaAlta);
            Controls.Add(checkBoxHabilitado);
            Controls.Add(textBoxClave);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxNomUsuario);
            Controls.Add(textBoxApellido);
            Controls.Add(textBoxNombre);
            Controls.Add(textBoxId);
            Controls.Add(habilitado);
            Controls.Add(clave);
            Controls.Add(nombreUsuario);
            Controls.Add(email);
            Controls.Add(apellido);
            Controls.Add(nombre);
            Controls.Add(Id);
            Controls.Add(btnGuardar);
            Name = "UsuarioDetalle";
            Text = "Detalle Usuario";
            Load += UsuarioDetalle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardar;
        private Label Id;
        private Label nombre;
        private Label apellido;
        private Label email;
        private Label nombreUsuario;
        private Label clave;
        private Label habilitado;
        private TextBox textBoxId;
        private TextBox textBoxNombre;
        private TextBox textBoxApellido;
        private TextBox textBoxNomUsuario;
        private TextBox textBoxEmail;
        private TextBox textBoxClave;
        private CheckBox checkBoxHabilitado;
        private Label fechaAlta;
        private TextBox textBoxFechaAlta;
    }
}