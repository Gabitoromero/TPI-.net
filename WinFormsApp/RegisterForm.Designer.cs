namespace WinFormsApp
{
    partial class RegisterForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBoxNombre = new TextBox();
            textBoxApellido = new TextBox();
            textBoxUsername = new TextBox();
            textBoxEmail = new TextBox();
            textBoxClave = new TextBox();
            label6 = new Label();
            buttonBack = new Button();
            buttonRegister = new Button();
            label7 = new Label();
            textBoxDireccion = new TextBox();
            labelTelefono = new Label();
            maskedTextBoxTelefono = new MaskedTextBox();
            labelFechaNac = new Label();
            dateTimePickerFechaNacimiento = new DateTimePicker();
            labelPlan = new Label();
            comboBoxPlan = new ComboBox();
            comboBoxTipoUsuario = new ComboBox();
            label8 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(80, 128);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Apellido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 165);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre de Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(80, 88);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 2;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(95, 206);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(64, 252);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 4;
            label5.Text = "Contraseña";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(151, 85);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(183, 23);
            textBoxNombre.TabIndex = 5;
            // 
            // textBoxApellido
            // 
            textBoxApellido.Location = new Point(151, 125);
            textBoxApellido.Name = "textBoxApellido";
            textBoxApellido.Size = new Size(183, 23);
            textBoxApellido.TabIndex = 6;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(151, 162);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(183, 23);
            textBoxUsername.TabIndex = 7;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(151, 203);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(183, 23);
            textBoxEmail.TabIndex = 8;
            // 
            // textBoxClave
            // 
            textBoxClave.Location = new Point(151, 249);
            textBoxClave.Name = "textBoxClave";
            textBoxClave.PasswordChar = '*';
            textBoxClave.Size = new Size(183, 23);
            textBoxClave.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16F);
            label6.Location = new Point(272, 27);
            label6.Name = "label6";
            label6.Size = new Size(177, 30);
            label6.TabIndex = 10;
            label6.Text = "Registrar Usuario";
            // 
            // buttonBack
            // 
            buttonBack.BackColor = Color.IndianRed;
            buttonBack.Location = new Point(167, 357);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(167, 32);
            buttonBack.TabIndex = 11;
            buttonBack.Text = "Volver";
            buttonBack.UseVisualStyleBackColor = false;
            buttonBack.Click += buttonBack_Click;
            // 
            // buttonRegister
            // 
            buttonRegister.BackColor = Color.SteelBlue;
            buttonRegister.Location = new Point(359, 357);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(167, 32);
            buttonRegister.TabIndex = 12;
            buttonRegister.Text = "Registrar";
            buttonRegister.UseVisualStyleBackColor = false;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(418, 165);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 13;
            label7.Text = "Dirección";
            // 
            // textBoxDireccion
            // 
            textBoxDireccion.Location = new Point(504, 162);
            textBoxDireccion.Name = "textBoxDireccion";
            textBoxDireccion.Size = new Size(183, 23);
            textBoxDireccion.TabIndex = 14;
            // 
            // labelTelefono
            // 
            labelTelefono.AutoSize = true;
            labelTelefono.Location = new Point(422, 206);
            labelTelefono.Name = "labelTelefono";
            labelTelefono.Size = new Size(53, 15);
            labelTelefono.TabIndex = 15;
            labelTelefono.Text = "Teléfono";
            // 
            // maskedTextBoxTelefono
            // 
            maskedTextBoxTelefono.Location = new Point(504, 203);
            maskedTextBoxTelefono.Mask = "0000000000";
            maskedTextBoxTelefono.Name = "maskedTextBoxTelefono";
            maskedTextBoxTelefono.Size = new Size(183, 23);
            maskedTextBoxTelefono.TabIndex = 16;
            // 
            // labelFechaNac
            // 
            labelFechaNac.AutoSize = true;
            labelFechaNac.Location = new Point(356, 250);
            labelFechaNac.Name = "labelFechaNac";
            labelFechaNac.Size = new Size(119, 15);
            labelFechaNac.TabIndex = 17;
            labelFechaNac.Text = "Fecha de Nacimiento";
            // 
            // dateTimePickerFechaNacimiento
            // 
            dateTimePickerFechaNacimiento.Format = DateTimePickerFormat.Short;
            dateTimePickerFechaNacimiento.Location = new Point(504, 244);
            dateTimePickerFechaNacimiento.Name = "dateTimePickerFechaNacimiento";
            dateTimePickerFechaNacimiento.Size = new Size(183, 23);
            dateTimePickerFechaNacimiento.TabIndex = 18;
            // 
            // labelPlan
            // 
            labelPlan.AutoSize = true;
            labelPlan.Location = new Point(445, 88);
            labelPlan.Name = "labelPlan";
            labelPlan.Size = new Size(30, 15);
            labelPlan.TabIndex = 19;
            labelPlan.Text = "Plan";
            // 
            // comboBoxPlan
            // 
            comboBoxPlan.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPlan.Location = new Point(504, 85);
            comboBoxPlan.Name = "comboBoxPlan";
            comboBoxPlan.Size = new Size(183, 23);
            comboBoxPlan.TabIndex = 20;
            // 
            // comboBoxTipoUsuario
            // 
            comboBoxTipoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipoUsuario.FormattingEnabled = true;
            comboBoxTipoUsuario.Location = new Point(504, 125);
            comboBoxTipoUsuario.Name = "comboBoxTipoUsuario";
            comboBoxTipoUsuario.Size = new Size(183, 23);
            comboBoxTipoUsuario.TabIndex = 21;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(444, 133);
            label8.Name = "label8";
            label8.Size = new Size(31, 15);
            label8.TabIndex = 22;
            label8.Text = "Tipo";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 415);
            Controls.Add(label8);
            Controls.Add(comboBoxTipoUsuario);
            Controls.Add(comboBoxPlan);
            Controls.Add(labelPlan);
            Controls.Add(dateTimePickerFechaNacimiento);
            Controls.Add(labelFechaNac);
            Controls.Add(labelTelefono);
            Controls.Add(textBoxDireccion);
            Controls.Add(label7);
            Controls.Add(buttonRegister);
            Controls.Add(buttonBack);
            Controls.Add(label6);
            Controls.Add(textBoxClave);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxUsername);
            Controls.Add(textBoxApellido);
            Controls.Add(textBoxNombre);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(maskedTextBoxTelefono);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBoxNombre;
        private TextBox textBoxApellido;
        private TextBox textBoxUsername;
        private TextBox textBoxEmail;
        private TextBox textBoxClave;
        private Label label6;
        private Button buttonBack;
        private Button buttonRegister;
        private Label label7;
        private TextBox textBoxDireccion;
        private Label labelTelefono;
        private MaskedTextBox maskedTextBoxTelefono;
        private Label labelFechaNac;
        private DateTimePicker dateTimePickerFechaNacimiento;
        private Label labelPlan;
        private ComboBox comboBoxPlan;
        private ComboBox comboBoxTipoUsuario;
        private Label label8;
    }
}