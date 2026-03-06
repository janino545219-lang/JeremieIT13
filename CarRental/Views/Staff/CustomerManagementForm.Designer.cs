namespace CarRental
{
    partial class CustomerManagementForm : System.Windows.Forms.Form
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
            btnClose = new Button();
            panelForm = new Panel();
            txtAddress = new TextBox();
            lblAddress = new Label();
            txtUserLicense = new TextBox();
            lblUserLicense = new Label();
            txtPhoneNumber = new TextBox();
            lblPhoneNumber = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtLastName = new TextBox();
            lblLastName = new Label();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
            txtCustomerID = new TextBox();
            lblCustomerID = new Label();
            panelButtons = new Panel();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            panelSearch = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            btnRefresh = new Button();
            dgvCustomers = new DataGridView();
            panelTop.SuspendLayout();
            panelForm.SuspendLayout();
            panelButtons.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(41, 44, 51);
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(btnClose);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1200, 60);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(282, 32);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Customer Management";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(231, 76, 60);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1140, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(48, 36);
            btnClose.TabIndex = 0;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.BorderStyle = BorderStyle.FixedSingle;
            panelForm.Controls.Add(txtAddress);
            panelForm.Controls.Add(lblAddress);
            panelForm.Controls.Add(txtUserLicense);
            panelForm.Controls.Add(lblUserLicense);
            panelForm.Controls.Add(txtPhoneNumber);
            panelForm.Controls.Add(lblPhoneNumber);
            panelForm.Controls.Add(txtEmail);
            panelForm.Controls.Add(lblEmail);
            panelForm.Controls.Add(txtLastName);
            panelForm.Controls.Add(lblLastName);
            panelForm.Controls.Add(txtFirstName);
            panelForm.Controls.Add(lblFirstName);
            panelForm.Controls.Add(txtCustomerID);
            panelForm.Controls.Add(lblCustomerID);
            panelForm.Location = new Point(12, 76);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(350, 380);
            panelForm.TabIndex = 1;
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(15, 315);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(320, 50);
            txtAddress.TabIndex = 13;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAddress.Location = new Point(15, 292);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(63, 19);
            lblAddress.TabIndex = 12;
            lblAddress.Text = "Address";
            // 
            // txtUserLicense
            // 
            txtUserLicense.Font = new Font("Segoe UI", 10F);
            txtUserLicense.Location = new Point(15, 262);
            txtUserLicense.Name = "txtUserLicense";
            txtUserLicense.Size = new Size(320, 25);
            txtUserLicense.TabIndex = 11;
            // 
            // lblUserLicense
            // 
            lblUserLicense.AutoSize = true;
            lblUserLicense.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUserLicense.Location = new Point(15, 239);
            lblUserLicense.Name = "lblUserLicense";
            lblUserLicense.Size = new Size(131, 19);
            lblUserLicense.TabIndex = 10;
            lblUserLicense.Text = "Driver License No.";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Font = new Font("Segoe UI", 10F);
            txtPhoneNumber.Location = new Point(15, 209);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(320, 25);
            txtPhoneNumber.TabIndex = 9;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPhoneNumber.Location = new Point(15, 186);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(110, 19);
            lblPhoneNumber.TabIndex = 8;
            lblPhoneNumber.Text = "Phone Number";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(15, 156);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(320, 25);
            txtEmail.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.Location = new Point(15, 133);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(45, 19);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(15, 103);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(320, 25);
            txtLastName.TabIndex = 5;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLastName.Location = new Point(15, 80);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(79, 19);
            lblLastName.TabIndex = 4;
            lblLastName.Text = "Last Name";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(15, 50);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(320, 25);
            txtFirstName.TabIndex = 3;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFirstName.Location = new Point(15, 27);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(81, 19);
            lblFirstName.TabIndex = 2;
            lblFirstName.Text = "First Name";
            // 
            // txtCustomerID
            // 
            txtCustomerID.Enabled = false;
            txtCustomerID.Font = new Font("Segoe UI", 10F);
            txtCustomerID.Location = new Point(305, 0);
            txtCustomerID.Name = "txtCustomerID";
            txtCustomerID.Size = new Size(80, 25);
            txtCustomerID.TabIndex = 1;
            txtCustomerID.Visible = false;
            // 
            // lblCustomerID
            // 
            lblCustomerID.AutoSize = true;
            lblCustomerID.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCustomerID.Location = new Point(205, 3);
            lblCustomerID.Name = "lblCustomerID";
            lblCustomerID.Size = new Size(91, 19);
            lblCustomerID.TabIndex = 0;
            lblCustomerID.Text = "Customer ID";
            lblCustomerID.Visible = false;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.BorderStyle = BorderStyle.FixedSingle;
            panelButtons.Controls.Add(btnClear);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Controls.Add(btnUpdate);
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Location = new Point(12, 462);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(350, 60);
            panelButtons.TabIndex = 2;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(149, 165, 166);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(261, 10);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(80, 40);
            btnClear.TabIndex = 3;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(177, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(243, 156, 18);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(93, 10);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(80, 40);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(39, 174, 96);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(9, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(80, 40);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // panelSearch
            // 
            panelSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelSearch.BackColor = Color.White;
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(lblSearch);
            panelSearch.Controls.Add(btnRefresh);
            panelSearch.Location = new Point(368, 76);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(820, 60);
            panelSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.FromArgb(41, 44, 51);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(620, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 40);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(95, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by name, email, phone, or license...";
            txtSearch.Size = new Size(500, 29);
            txtSearch.TabIndex = 2;
            txtSearch.KeyPress += txtSearch_KeyPress;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSearch.Location = new Point(15, 18);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(65, 21);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search:";
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(720, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 40);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "REFRESH";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(368, 142);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(820, 380);
            dgvCustomers.TabIndex = 4;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
            // 
            // CustomerManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1200, 534);
            Controls.Add(dgvCustomers);
            Controls.Add(panelSearch);
            Controls.Add(panelButtons);
            Controls.Add(panelForm);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomerManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customer Management";
            Load += CustomerManagementForm_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtUserLicense;
        private System.Windows.Forms.Label lblUserLicense;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvCustomers;
    }
}