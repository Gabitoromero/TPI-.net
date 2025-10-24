namespace WinFormsApp
{
    partial class LoginForm
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
            UsuarioLabel = new Label();
            textBoxUsername = new TextBox();
            textBoxClave = new TextBox();
            label2 = new Label();
            buttonLogin = new Button();
            label3 = new Label();
            linkLabelRegistrar = new LinkLabel();
            label4 = new Label();
            buttonVolver = new Button();
            SuspendLayout();
            // 
            // UsuarioLabel
            // 
            UsuarioLabel.AutoSize = true;
            UsuarioLabel.Location = new Point(47, 107);
            UsuarioLabel.Name = "UsuarioLabel";
            UsuarioLabel.Size = new Size(47, 15);
            UsuarioLabel.TabIndex = 0;
            UsuarioLabel.Text = "Usuario";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(121, 99);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(196, 23);
            textBoxUsername.TabIndex = 1;
            // 
            // textBoxClave
            // 
            textBoxClave.Location = new Point(121, 150);
            textBoxClave.Name = "textBoxClave";
            textBoxClave.PasswordChar = '*';
            textBoxClave.Size = new Size(196, 23);
            textBoxClave.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 158);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 3;
            label2.Text = "Contraseña";
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = SystemColors.ActiveCaption;
            buttonLogin.FlatAppearance.BorderColor = Color.Cyan;
            buttonLogin.Location = new Point(188, 204);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(129, 23);
            buttonLogin.TabIndex = 4;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(78, 257);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 5;
            label3.Text = "¿No tenés usuario?";
            // 
            // linkLabelRegistrar
            // 
            linkLabelRegistrar.AutoSize = true;
            linkLabelRegistrar.Location = new Point(216, 257);
            linkLabelRegistrar.Name = "linkLabelRegistrar";
            linkLabelRegistrar.Size = new Size(80, 15);
            linkLabelRegistrar.TabIndex = 6;
            linkLabelRegistrar.TabStop = true;
            linkLabelRegistrar.Text = "Registrate acá";
            linkLabelRegistrar.LinkClicked += linkLabelRegistrar_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F);
            label4.Location = new Point(36, 36);
            label4.Name = "label4";
            label4.Size = new Size(139, 30);
            label4.TabIndex = 7;
            label4.Text = "Iniciar Sesión";
            // 
            // buttonVolver
            // 
            buttonVolver.Location = new Point(47, 204);
            buttonVolver.Name = "buttonVolver";
            buttonVolver.Size = new Size(129, 23);
            buttonVolver.TabIndex = 8;
            buttonVolver.Text = "Volver";
            buttonVolver.UseVisualStyleBackColor = true;
            buttonVolver.Click += buttonVolver_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 296);
            Controls.Add(buttonVolver);
            Controls.Add(label4);
            Controls.Add(linkLabelRegistrar);
            Controls.Add(label3);
            Controls.Add(buttonLogin);
            Controls.Add(label2);
            Controls.Add(textBoxClave);
            Controls.Add(textBoxUsername);
            Controls.Add(UsuarioLabel);
            Name = "LoginForm";
            Text = "Login";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UsuarioLabel;
        private TextBox textBoxUsername;
        private TextBox textBoxClave;
        private Label label2;
        private Button buttonLogin;
        private Label label3;
        private LinkLabel linkLabelRegistrar;
        private Label label4;
        private Button buttonVolver;
    }
}