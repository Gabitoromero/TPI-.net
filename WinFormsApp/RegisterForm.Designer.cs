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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(98, 128);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Apellido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 168);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre de Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(98, 88);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 2;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(113, 209);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(82, 252);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 4;
            label5.Text = "Contraseña";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(165, 85);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(183, 23);
            textBoxNombre.TabIndex = 5;
            // 
            // textBoxApellido
            // 
            textBoxApellido.Location = new Point(165, 125);
            textBoxApellido.Name = "textBoxApellido";
            textBoxApellido.Size = new Size(183, 23);
            textBoxApellido.TabIndex = 6;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(165, 165);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(183, 23);
            textBoxUsername.TabIndex = 7;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(165, 206);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(183, 23);
            textBoxEmail.TabIndex = 8;
            // 
            // textBoxClave
            // 
            textBoxClave.Location = new Point(165, 249);
            textBoxClave.Name = "textBoxClave";
            textBoxClave.PasswordChar = '*';
            textBoxClave.Size = new Size(183, 23);
            textBoxClave.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16F);
            label6.Location = new Point(49, 27);
            label6.Name = "label6";
            label6.Size = new Size(177, 30);
            label6.TabIndex = 10;
            label6.Text = "Registrar Usuario";
            // 
            // buttonBack
            // 
            buttonBack.Location = new Point(98, 298);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(116, 32);
            buttonBack.TabIndex = 11;
            buttonBack.Text = "Volver";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += buttonBack_Click;
            // 
            // buttonRegister
            // 
            buttonRegister.Location = new Point(232, 298);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(116, 32);
            buttonRegister.TabIndex = 12;
            buttonRegister.Text = "Registrar";
            buttonRegister.UseVisualStyleBackColor = true;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 350);
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
    }
}