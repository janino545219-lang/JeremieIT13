namespace CarRental
{
    partial class SignUpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUpForm));
            panelLeft = new Panel();
            lblLogo = new Label();
            lblWelcome = new Label();
            lblFullNamePlaceholder = new Label();
            txtFullName = new TextBox();
            lblEmailPlaceholder = new Label();
            txtEmail = new TextBox();
            lblUsernamePlaceholder = new Label();
            txtUsername = new TextBox();
            lblPasswordPlaceholder = new Label();
            txtPassword = new TextBox();
            lblConfirmPasswordPlaceholder = new Label();
            txtConfirmPassword = new TextBox();
            btnSignUp = new Button();
            chkTerms = new CheckBox();
            lblAlreadyHaveAccount = new Label();
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
            panelLeft.Controls.Add(lblFullNamePlaceholder);
            panelLeft.Controls.Add(txtFullName);
            panelLeft.Controls.Add(lblEmailPlaceholder);
            panelLeft.Controls.Add(txtEmail);
            panelLeft.Controls.Add(lblUsernamePlaceholder);
            panelLeft.Controls.Add(txtUsername);
            panelLeft.Controls.Add(lblPasswordPlaceholder);
            panelLeft.Controls.Add(txtPassword);
            panelLeft.Controls.Add(lblConfirmPasswordPlaceholder);
            panelLeft.Controls.Add(txtConfirmPassword);
            panelLeft.Controls.Add(btnSignUp);
            panelLeft.Controls.Add(chkTerms);
            panelLeft.Controls.Add(lblAlreadyHaveAccount);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Margin = new Padding(3, 2, 3, 2);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(350, 550);
            panelLeft.TabIndex = 0;
            panelLeft.Paint += panelLeft_Paint;
            // 
            // lblLogo
            // 
            lblLogo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(30, 30, 30);
            lblLogo.Location = new Point(44, 20);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(262, 35);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "Car Rental System";
            lblLogo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblWelcome
            // 
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(30, 30, 30);
            lblWelcome.Location = new Point(44, 65);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(262, 30);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Create your account";
            lblWelcome.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFullNamePlaceholder
            // 
            lblFullNamePlaceholder.AutoSize = true;
            lblFullNamePlaceholder.Font = new Font("Segoe UI", 9F);
            lblFullNamePlaceholder.ForeColor = Color.FromArgb(100, 100, 100);
            lblFullNamePlaceholder.Location = new Point(44, 110);
            lblFullNamePlaceholder.Name = "lblFullNamePlaceholder";
            lblFullNamePlaceholder.Size = new Size(61, 15);
            lblFullNamePlaceholder.TabIndex = 2;
            lblFullNamePlaceholder.Text = "Full Name";
            // 
            // txtFullName
            // 
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.Location = new Point(44, 128);
            txtFullName.Margin = new Padding(3, 2, 3, 2);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(263, 25);
            txtFullName.TabIndex = 3;
            // 
            // lblEmailPlaceholder
            // 
            lblEmailPlaceholder.AutoSize = true;
            lblEmailPlaceholder.Font = new Font("Segoe UI", 9F);
            lblEmailPlaceholder.ForeColor = Color.FromArgb(100, 100, 100);
            lblEmailPlaceholder.Location = new Point(44, 160);
            lblEmailPlaceholder.Name = "lblEmailPlaceholder";
            lblEmailPlaceholder.Size = new Size(81, 15);
            lblEmailPlaceholder.TabIndex = 4;
            lblEmailPlaceholder.Text = "Email Address";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(44, 178);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(263, 25);
            txtEmail.TabIndex = 5;
            // 
            // lblUsernamePlaceholder
            // 
            lblUsernamePlaceholder.AutoSize = true;
            lblUsernamePlaceholder.Font = new Font("Segoe UI", 9F);
            lblUsernamePlaceholder.ForeColor = Color.FromArgb(100, 100, 100);
            lblUsernamePlaceholder.Location = new Point(44, 210);
            lblUsernamePlaceholder.Name = "lblUsernamePlaceholder";
            lblUsernamePlaceholder.Size = new Size(60, 15);
            lblUsernamePlaceholder.TabIndex = 6;
            lblUsernamePlaceholder.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(44, 228);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(263, 25);
            txtUsername.TabIndex = 7;
            // 
            // lblPasswordPlaceholder
            // 
            lblPasswordPlaceholder.AutoSize = true;
            lblPasswordPlaceholder.Font = new Font("Segoe UI", 9F);
            lblPasswordPlaceholder.ForeColor = Color.FromArgb(100, 100, 100);
            lblPasswordPlaceholder.Location = new Point(44, 260);
            lblPasswordPlaceholder.Name = "lblPasswordPlaceholder";
            lblPasswordPlaceholder.Size = new Size(57, 15);
            lblPasswordPlaceholder.TabIndex = 8;
            lblPasswordPlaceholder.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(44, 278);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(263, 25);
            txtPassword.TabIndex = 9;
            // 
            // lblConfirmPasswordPlaceholder
            // 
            lblConfirmPasswordPlaceholder.AutoSize = true;
            lblConfirmPasswordPlaceholder.Font = new Font("Segoe UI", 9F);
            lblConfirmPasswordPlaceholder.ForeColor = Color.FromArgb(100, 100, 100);
            lblConfirmPasswordPlaceholder.Location = new Point(44, 310);
            lblConfirmPasswordPlaceholder.Name = "lblConfirmPasswordPlaceholder";
            lblConfirmPasswordPlaceholder.Size = new Size(104, 15);
            lblConfirmPasswordPlaceholder.TabIndex = 10;
            lblConfirmPasswordPlaceholder.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Font = new Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new Point(44, 328);
            txtConfirmPassword.Margin = new Padding(3, 2, 3, 2);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.Size = new Size(263, 25);
            txtConfirmPassword.TabIndex = 11;
            // 
            // btnSignUp
            // 
            btnSignUp.BackColor = Color.FromArgb(30, 30, 30);
            btnSignUp.Cursor = Cursors.Hand;
            btnSignUp.FlatAppearance.BorderSize = 0;
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSignUp.ForeColor = Color.White;
            btnSignUp.Location = new Point(44, 400);
            btnSignUp.Margin = new Padding(3, 2, 3, 2);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(262, 30);
            btnSignUp.TabIndex = 12;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = false;
            // 
            // chkTerms
            // 
            chkTerms.Font = new Font("Segoe UI", 8F);
            chkTerms.ForeColor = Color.FromArgb(100, 100, 100);
            chkTerms.Location = new Point(44, 365);
            chkTerms.Margin = new Padding(3, 2, 3, 2);
            chkTerms.Name = "chkTerms";
            chkTerms.Size = new Size(263, 25);
            chkTerms.TabIndex = 13;
            chkTerms.Text = "I agree to the Terms of Service and Privacy Policy";
            chkTerms.UseVisualStyleBackColor = true;
            // 
            // lblAlreadyHaveAccount
            // 
            lblAlreadyHaveAccount.AutoSize = true;
            lblAlreadyHaveAccount.Cursor = Cursors.Hand;
            lblAlreadyHaveAccount.Font = new Font("Segoe UI", 9F);
            lblAlreadyHaveAccount.ForeColor = Color.FromArgb(100, 100, 100);
            lblAlreadyHaveAccount.Location = new Point(44, 445);
            lblAlreadyHaveAccount.Name = "lblAlreadyHaveAccount";
            lblAlreadyHaveAccount.Size = new Size(178, 15);
            lblAlreadyHaveAccount.TabIndex = 14;
            lblAlreadyHaveAccount.Text = "Already have an account? Log in";
            lblAlreadyHaveAccount.Click += lblAlreadyHaveAccount_Click;
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
            panelRight.Size = new Size(525, 550);
            panelRight.TabIndex = 1;
            // 
            // pictureBoxCar
            // 
            pictureBoxCar.Dock = DockStyle.Fill;
            pictureBoxCar.Image = (Image)resources.GetObject("pictureBoxCar.Image");
            pictureBoxCar.Location = new Point(0, 0);
            pictureBoxCar.Name = "pictureBoxCar";
            pictureBoxCar.Size = new Size(525, 520);
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
            panelSocial.Location = new Point(0, 520);
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
            // SignUpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 550);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "SignUpForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sign Up - Car Rental";
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxCar).EndInit();
            panelSocial.ResumeLayout(false);
            panelSocial.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLeft;
        private Panel panelRight;
        private Label lblLogo;
        private Label lblWelcome;
        private Label lblFullNamePlaceholder;
        private TextBox txtFullName;
        private Label lblEmailPlaceholder;
        private TextBox txtEmail;
        private Label lblUsernamePlaceholder;
        private TextBox txtUsername;
        private Label lblPasswordPlaceholder;
        private TextBox txtPassword;
        private Label lblConfirmPasswordPlaceholder;
        private TextBox txtConfirmPassword;
        private Button btnSignUp;
        private CheckBox chkTerms;
        private Label lblAlreadyHaveAccount;
        private PictureBox pictureBoxCar;
        private Panel panelSocial;
        private Label lblFacebook;
        private Label lblTwitter;
        private Label lblInstagram;
        private Label lblLinkedIn;
    }
}