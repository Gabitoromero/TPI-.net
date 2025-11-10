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
            habilitado = new Label();
            textBoxId = new TextBox();
            textBoxNombre = new TextBox();
            textBoxApellido = new TextBox();
            textBoxNomUsuario = new TextBox();
            textBoxEmail = new TextBox();
            checkBoxHabilitado = new CheckBox();
            fechaAlta = new Label();
            textBoxFechaAlta = new TextBox();
            txtBoxDireccion = new TextBox();
            textBoxTel = new TextBox();
            monthCalendar1 = new MonthCalendar();
            labelDirecc = new Label();
            labelFecha = new Label();
            label3 = new Label();
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
            btnGuardar.Click += btnGuardar_Click;
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
            // habilitado
            // 
            habilitado.AutoSize = true;
            habilitado.Location = new Point(31, 228);
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
            // checkBoxHabilitado
            // 
            checkBoxHabilitado.AutoSize = true;
            checkBoxHabilitado.Location = new Point(172, 229);
            checkBoxHabilitado.Name = "checkBoxHabilitado";
            checkBoxHabilitado.Size = new Size(15, 14);
            checkBoxHabilitado.TabIndex = 14;
            checkBoxHabilitado.UseVisualStyleBackColor = true;
            // 
            // fechaAlta
            // 
            fechaAlta.AutoSize = true;
            fechaAlta.Location = new Point(31, 270);
            fechaAlta.Name = "fechaAlta";
            fechaAlta.Size = new Size(82, 15);
            fechaAlta.TabIndex = 15;
            fechaAlta.Text = "Fecha de alta :";
            // 
            // textBoxFechaAlta
            // 
            textBoxFechaAlta.Enabled = false;
            textBoxFechaAlta.Location = new Point(172, 267);
            textBoxFechaAlta.Name = "textBoxFechaAlta";
            textBoxFechaAlta.Size = new Size(189, 23);
            textBoxFechaAlta.TabIndex = 16;
            // 
            // txtBoxDireccion
            // 
            txtBoxDireccion.Location = new Point(488, 25);
            txtBoxDireccion.Name = "txtBoxDireccion";
            txtBoxDireccion.Size = new Size(173, 23);
            txtBoxDireccion.TabIndex = 17;
            // 
            // textBoxTel
            // 
            textBoxTel.Location = new Point(488, 58);
            textBoxTel.Name = "textBoxTel";
            textBoxTel.Size = new Size(173, 23);
            textBoxTel.TabIndex = 18;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(418, 135);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 19;
            // 
            // labelDirecc
            // 
            labelDirecc.AutoSize = true;
            labelDirecc.Location = new Point(414, 28);
            labelDirecc.Name = "labelDirecc";
            labelDirecc.Size = new Size(66, 15);
            labelDirecc.TabIndex = 20;
            labelDirecc.Text = "Direccion : ";
            // 
            // labelFecha
            // 
            labelFecha.AutoSize = true;
            labelFecha.Location = new Point(415, 62);
            labelFecha.Name = "labelFecha";
            labelFecha.Size = new Size(59, 15);
            labelFecha.TabIndex = 21;
            labelFecha.Text = "Telefono :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(418, 101);
            label3.Name = "label3";
            label3.Size = new Size(123, 15);
            label3.TabIndex = 22;
            label3.Text = "Fecha de nacimiento: ";
            // 
            // UsuarioDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(673, 388);
            Controls.Add(label3);
            Controls.Add(labelFecha);
            Controls.Add(labelDirecc);
            Controls.Add(monthCalendar1);
            Controls.Add(textBoxTel);
            Controls.Add(txtBoxDireccion);
            Controls.Add(textBoxFechaAlta);
            Controls.Add(fechaAlta);
            Controls.Add(checkBoxHabilitado);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxNomUsuario);
            Controls.Add(textBoxApellido);
            Controls.Add(textBoxNombre);
            Controls.Add(textBoxId);
            Controls.Add(habilitado);
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
        private Label habilitado;
        private TextBox textBoxId;
        private TextBox textBoxNombre;
        private TextBox textBoxApellido;
        private TextBox textBoxNomUsuario;
        private TextBox textBoxEmail;
        private CheckBox checkBoxHabilitado;
        private Label fechaAlta;
        private TextBox textBoxFechaAlta;
        private TextBox txtBoxDireccion;
        private TextBox textBoxTel;
        private MonthCalendar monthCalendar1;
        private Label labelDirecc;
        private Label labelFecha;
        private Label label3;
    }
}