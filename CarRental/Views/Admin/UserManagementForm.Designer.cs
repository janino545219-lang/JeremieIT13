namespace CarRental
{
    partial class UserManagementForm
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
            panelTop = new Panel();
            lblTitle = new Label();
            panelForm = new Panel();
            btnClear = new Button();
            btnSave = new Button();
            cmbRole = new ComboBox();
            lblRole = new Label();
            txtConfirmPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            panelGrid = new Panel();
            dgvUsers = new DataGridView();
            panelGridTop = new Panel();
            txtSearch = new TextBox();
            lblSearch = new Label();
            btnRefresh = new Button();
            panelTop.SuspendLayout();
            panelForm.SuspendLayout();
            panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            panelGridTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1200, 80);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(251, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "User Management";
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Controls.Add(btnClear);
            panelForm.Controls.Add(btnSave);
            panelForm.Controls.Add(cmbRole);
            panelForm.Controls.Add(lblRole);
            panelForm.Controls.Add(txtConfirmPassword);
            panelForm.Controls.Add(lblConfirmPassword);
            panelForm.Controls.Add(txtPassword);
            panelForm.Controls.Add(lblPassword);
            panelForm.Controls.Add(txtUsername);
            panelForm.Controls.Add(lblUsername);
            panelForm.Controls.Add(txtEmail);
            panelForm.Controls.Add(lblEmail);
            panelForm.Controls.Add(txtFullName);
            panelForm.Controls.Add(lblFullName);
            panelForm.Location = new Point(30, 100);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(400, 600);
            panelForm.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(200, 200, 200);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(220, 530);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 45);
            btnClear.TabIndex = 13;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 122, 204);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(30, 530);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 45);
            btnSave.TabIndex = 12;
            btnSave.Text = "Create User";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Font = new Font("Segoe UI", 11F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Staff", "Super Admin", "Manager" });
            cmbRole.Location = new Point(30, 470);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(340, 33);
            cmbRole.TabIndex = 11;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(64, 64, 64);
            lblRole.Location = new Point(30, 440);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(47, 23);
            lblRole.TabIndex = 10;
            lblRole.Text = "Role";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 11F);
            txtConfirmPassword.Location = new Point(30, 390);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.Size = new Size(340, 32);
            txtConfirmPassword.TabIndex = 9;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblConfirmPassword.ForeColor = Color.FromArgb(64, 64, 64);
            lblConfirmPassword.Location = new Point(30, 360);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(162, 23);
            lblConfirmPassword.TabIndex = 8;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(30, 310);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(340, 32);
            txtPassword.TabIndex = 7;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(64, 64, 64);
            lblPassword.Location = new Point(30, 280);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(87, 23);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(30, 230);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(340, 32);
            txtUsername.TabIndex = 5;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(64, 64, 64);
            lblUsername.Location = new Point(30, 200);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(91, 23);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Username";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.Location = new Point(30, 150);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(340, 32);
            txtEmail.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(64, 64, 64);
            lblEmail.Location = new Point(30, 120);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(54, 23);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 11F);
            txtFullName.Location = new Point(30, 70);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(340, 32);
            txtFullName.TabIndex = 1;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(64, 64, 64);
            lblFullName.Location = new Point(30, 40);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(91, 23);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "Full Name";
            // 
            // panelGrid
            // 
            panelGrid.BackColor = Color.White;
            panelGrid.Controls.Add(dgvUsers);
            panelGrid.Controls.Add(panelGridTop);
            panelGrid.Location = new Point(450, 100);
            panelGrid.Name = "panelGrid";
            panelGrid.Size = new Size(720, 600);
            panelGrid.TabIndex = 2;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(0, 80);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.RowTemplate.Height = 29;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(720, 520);
            dgvUsers.TabIndex = 1;
            // 
            // panelGridTop
            // 
            panelGridTop.Controls.Add(txtSearch);
            panelGridTop.Controls.Add(lblSearch);
            panelGridTop.Controls.Add(btnRefresh);
            panelGridTop.Dock = DockStyle.Top;
            panelGridTop.Location = new Point(0, 0);
            panelGridTop.Name = "panelGridTop";
            panelGridTop.Size = new Size(720, 80);
            panelGridTop.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(120, 25);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by name, email, or username...";
            txtSearch.Size = new Size(400, 32);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(64, 64, 64);
            lblSearch.Location = new Point(30, 28);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(73, 25);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search:";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(0, 122, 204);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(560, 20);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(130, 40);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // UserManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1200, 720);
            Controls.Add(panelGrid);
            Controls.Add(panelForm);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserManagementForm";
            Text = "User Management";
            Load += UserManagementForm_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            panelGridTop.ResumeLayout(false);
            panelGridTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitle;
        private Panel panelForm;
        private TextBox txtFullName;
        private Label lblFullName;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtUsername;
        private Label lblUsername;
        private TextBox txtPassword;
        private Label lblPassword;
        private TextBox txtConfirmPassword;
        private Label lblConfirmPassword;
        private ComboBox cmbRole;
        private Label lblRole;
        private Button btnSave;
        private Button btnClear;
        private Panel panelGrid;
        private DataGridView dgvUsers;
        private Panel panelGridTop;
        private Button btnRefresh;
        private Label lblSearch;
        private TextBox txtSearch;
    }
}