namespace CarRental
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelLeft = new Panel();
            lblLogo = new Label();
            lblWelcome = new Label();
            lblUsernamePlaceholder = new Label();
            txtUsername = new TextBox();
            lblPasswordPlaceholder = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            chkRememberMe = new CheckBox();
            lblForgotPassword = new Label();
            lblCreateAccount = new Label();
            lblTerms = new Label();
            panelRight = new Panel();
            pictureBoxCar = new PictureBox();
            panelSocial = new Panel();
            lblFacebook = new Label();
            lblTwitter = new Label();
            lblInstagram = new Label();
            lblLinkedIn = new Label();
            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCar).BeginInit();
            panelSocial.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.White;
            panelLeft.Controls.Add(lblLogo);
            panelLeft.Controls.Add(lblWelcome);
            panelLeft.Controls.Add(lblUsernamePlaceholder);
            panelLeft.Controls.Add(txtUsername);
            panelLeft.Controls.Add(lblPasswordPlaceholder);
            panelLeft.Controls.Add(txtPassword);
            panelLeft.Controls.Add(btnLogin);
            panelLeft.Controls.Add(chkRememberMe);
            panelLeft.Controls.Add(lblForgotPassword);
            panelLeft.Controls.Add(lblCreateAccount);
            panelLeft.Controls.Add(lblTerms);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Margin = new Padding(3, 2, 3, 2);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(350, 450);
            panelLeft.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(30, 30, 30);
            lblLogo.Location = new Point(44, 30);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(262, 38);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "Car Rental System";
            lblLogo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblWelcome
            // 
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(30, 30, 30);
            lblWelcome.Location = new Point(44, 90);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(262, 30);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome!";
            lblWelcome.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUsernamePlaceholder
            // 
            lblUsernamePlaceholder.AutoSize = true;
            lblUsernamePlaceholder.Font = new Font("Segoe UI", 9F);
            lblUsernamePlaceholder.ForeColor = Color.FromArgb(100, 100, 100);
            lblUsernamePlaceholder.Location = new Point(44, 135);
            lblUsernamePlaceholder.Name = "lblUsernamePlaceholder";
            lblUsernamePlaceholder.Size = new Size(151, 15);
            lblUsernamePlaceholder.TabIndex = 2;
            lblUsernamePlaceholder.Text = "Username or Email Address";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(44, 154);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(262, 25);
            txtUsername.TabIndex = 3;
            // 
            // lblPasswordPlaceholder
            // 
            lblPasswordPlaceholder.AutoSize = true;
            lblPasswordPlaceholder.Font = new Font("Segoe UI", 9F);
            lblPasswordPlaceholder.ForeColor = Color.FromArgb(100, 100, 100);
            lblPasswordPlaceholder.Location = new Point(44, 188);
            lblPasswordPlaceholder.Name = "lblPasswordPlaceholder";
            lblPasswordPlaceholder.Size = new Size(57, 15);
            lblPasswordPlaceholder.TabIndex = 4;
            lblPasswordPlaceholder.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(44, 206);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(262, 25);
            txtPassword.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(30, 30, 30);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(44, 270);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(262, 30);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // chkRememberMe
            // 
            chkRememberMe.Font = new Font("Segoe UI", 9F);
            chkRememberMe.ForeColor = Color.FromArgb(100, 100, 100);
            chkRememberMe.Location = new Point(44, 235);
            chkRememberMe.Margin = new Padding(3, 2, 3, 2);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.Size = new Size(104, 24);
            chkRememberMe.TabIndex = 7;
            chkRememberMe.Text = "Remember me";
            chkRememberMe.UseVisualStyleBackColor = true;
            // 
            // lblForgotPassword
            // 
            lblForgotPassword.Cursor = Cursors.Hand;
            lblForgotPassword.Font = new Font("Segoe UI", 9F);
            lblForgotPassword.ForeColor = Color.FromArgb(100, 100, 100);
            lblForgotPassword.Location = new Point(210, 239);
            lblForgotPassword.Name = "lblForgotPassword";
            lblForgotPassword.Size = new Size(109, 24);
            lblForgotPassword.TabIndex = 8;
            lblForgotPassword.Text = "Forgot password?";
            lblForgotPassword.Click += lblForgotPassword_Click;
            // 
            // lblCreateAccount
            // 
            lblCreateAccount.AutoSize = true;
            lblCreateAccount.Cursor = Cursors.Hand;
            lblCreateAccount.Font = new Font("Segoe UI", 9F);
            lblCreateAccount.ForeColor = Color.FromArgb(100, 100, 100);
            lblCreateAccount.Location = new Point(44, 315);
            lblCreateAccount.Name = "lblCreateAccount";
            lblCreateAccount.Size = new Size(174, 15);
            lblCreateAccount.TabIndex = 9;
            lblCreateAccount.Text = "Don't have an account? Sign up";
            lblCreateAccount.Click += lblCreateAccount_Click;
            // 
            // lblTerms
            // 
            lblTerms.Font = new Font("Segoe UI", 8F);
            lblTerms.ForeColor = Color.FromArgb(150, 150, 150);
            lblTerms.Location = new Point(44, 405);
            lblTerms.Name = "lblTerms";
            lblTerms.Size = new Size(262, 30);
            lblTerms.TabIndex = 10;
            lblTerms.Text = "By continuing, you agree to our Terms of Service and Privacy Policy";
            lblTerms.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.FromArgb(240, 240, 240);
            panelRight.Controls.Add(pictureBoxCar);
            panelRight.Controls.Add(panelSocial);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(350, 0);
            panelRight.Margin = new Padding(3, 2, 3, 2);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(525, 450);
            panelRight.TabIndex = 1;
            // 
            // pictureBoxCar
            // 
            pictureBoxCar.Dock = DockStyle.Fill;
            pictureBoxCar.Image = (Image)resources.GetObject("pictureBoxCar.Image");
            pictureBoxCar.Location = new Point(0, 0);
            pictureBoxCar.Name = "pictureBoxCar";
            pictureBoxCar.Size = new Size(525, 420);
            pictureBoxCar.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCar.TabIndex = 0;
            pictureBoxCar.TabStop = false;
            pictureBoxCar.Click += pictureBoxCar_Click;
            // 
            // panelSocial
            // 
            panelSocial.Controls.Add(lblFacebook);
            panelSocial.Controls.Add(lblTwitter);
            panelSocial.Controls.Add(lblInstagram);
            panelSocial.Controls.Add(lblLinkedIn);
            panelSocial.Dock = DockStyle.Bottom;
            panelSocial.Location = new Point(0, 420);
            panelSocial.Margin = new Padding(3, 2, 3, 2);
            panelSocial.Name = "panelSocial";
            panelSocial.Size = new Size(525, 30);
            panelSocial.TabIndex = 1;
            // 
            // lblFacebook
            // 
            lblFacebook.AutoSize = true;
            lblFacebook.Cursor = Cursors.Hand;
            lblFacebook.Font = new Font("Segoe UI", 10F);
            lblFacebook.ForeColor = Color.FromArgb(100, 100, 100);
            lblFacebook.Location = new Point(420, 8);
            lblFacebook.Name = "lblFacebook";
            lblFacebook.Size = new Size(13, 19);
            lblFacebook.TabIndex = 0;
            lblFacebook.Text = "f";
            // 
            // lblTwitter
            // 
            lblTwitter.AutoSize = true;
            lblTwitter.Cursor = Cursors.Hand;
            lblTwitter.Font = new Font("Segoe UI", 10F);
            lblTwitter.ForeColor = Color.FromArgb(100, 100, 100);
            lblTwitter.Location = new Point(446, 8);
            lblTwitter.Name = "lblTwitter";
            lblTwitter.Size = new Size(19, 19);
            lblTwitter.TabIndex = 1;
            lblTwitter.Text = "𝕏";
            // 
            // lblInstagram
            // 
            lblInstagram.AutoSize = true;
            lblInstagram.Cursor = Cursors.Hand;
            lblInstagram.Font = new Font("Segoe UI", 10F);
            lblInstagram.ForeColor = Color.FromArgb(100, 100, 100);
            lblInstagram.Location = new Point(472, 8);
            lblInstagram.Name = "lblInstagram";
            lblInstagram.Size = new Size(21, 19);
            lblInstagram.TabIndex = 2;
            lblInstagram.Text = "◉";
            // 
            // lblLinkedIn
            // 
            lblLinkedIn.AutoSize = true;
            lblLinkedIn.Cursor = Cursors.Hand;
            lblLinkedIn.Font = new Font("Segoe UI", 10F);
            lblLinkedIn.ForeColor = Color.FromArgb(100, 100, 100);
            lblLinkedIn.Location = new Point(499, 8);
            lblLinkedIn.Name = "lblLinkedIn";
            lblLinkedIn.Size = new Size(20, 19);
            lblLinkedIn.TabIndex = 3;
            lblLinkedIn.Text = "in";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 450);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Car rental - System";
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxCar).EndInit();
            panelSocial.ResumeLayout(false);
            panelSocial.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblUsernamePlaceholder;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPasswordPlaceholder;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox chkRememberMe;
        private System.Windows.Forms.Label lblForgotPassword;
        private System.Windows.Forms.Label lblCreateAccount;
        private System.Windows.Forms.Label lblTerms;
        private System.Windows.Forms.PictureBox pictureBoxCar;
        private System.Windows.Forms.Panel panelSocial;
        private System.Windows.Forms.Label lblFacebook;
        private System.Windows.Forms.Label lblTwitter;
        private System.Windows.Forms.Label lblInstagram;
        private System.Windows.Forms.Label lblLinkedIn;
    }
}
