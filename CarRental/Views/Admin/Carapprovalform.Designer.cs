namespace CarRental
{
    partial class CarApprovalForm
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
            panelHeader = new Panel();
            lblTitle = new Label();
            panelMain = new Panel();
            dgvCars = new DataGridView();
            panelActions = new Panel();
            btnRefresh = new Button();
            btnDelete = new Button();
            btnApprove = new Button();
            panelFilters = new Panel();
            cmbStatusFilter = new ComboBox();
            lblStatusFilter = new Label();
            txtSearch = new TextBox();
            lblSearch = new Label();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCars).BeginInit();
            panelActions.SuspendLayout();
            panelFilters.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 44, 51);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1000, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(333, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Car Approval && Deletion";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(dgvCars);
            panelMain.Controls.Add(panelActions);
            panelMain.Controls.Add(panelFilters);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 80);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(20);
            panelMain.Size = new Size(1000, 620);
            panelMain.TabIndex = 1;
            // 
            // dgvCars
            // 
            dgvCars.AllowUserToAddRows = false;
            dgvCars.AllowUserToDeleteRows = false;
            dgvCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCars.BackgroundColor = Color.White;
            dgvCars.BorderStyle = BorderStyle.None;
            dgvCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCars.Dock = DockStyle.Fill;
            dgvCars.Location = new Point(20, 90);
            dgvCars.MultiSelect = false;
            dgvCars.Name = "dgvCars";
            dgvCars.ReadOnly = true;
            dgvCars.RowHeadersWidth = 51;
            dgvCars.RowTemplate.Height = 29;
            dgvCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCars.Size = new Size(960, 440);
            dgvCars.TabIndex = 2;
            dgvCars.SelectionChanged += dgvCars_SelectionChanged;
            // 
            // panelActions
            // 
            panelActions.Controls.Add(btnRefresh);
            panelActions.Controls.Add(btnDelete);
            panelActions.Controls.Add(btnApprove);
            panelActions.Dock = DockStyle.Bottom;
            panelActions.Location = new Point(20, 530);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(960, 70);
            panelActions.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(108, 117, 125);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(20, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(150, 45);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.Enabled = false;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(790, 15);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 45);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Archive";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnApprove
            // 
            btnApprove.BackColor = Color.FromArgb(40, 167, 69);
            btnApprove.Enabled = false;
            btnApprove.FlatAppearance.BorderSize = 0;
            btnApprove.FlatStyle = FlatStyle.Flat;
            btnApprove.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnApprove.ForeColor = Color.White;
            btnApprove.Location = new Point(620, 15);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(150, 45);
            btnApprove.TabIndex = 0;
            btnApprove.Text = "✅ Approve Car";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // panelFilters
            // 
            panelFilters.Controls.Add(cmbStatusFilter);
            panelFilters.Controls.Add(lblStatusFilter);
            panelFilters.Controls.Add(txtSearch);
            panelFilters.Controls.Add(lblSearch);
            panelFilters.Dock = DockStyle.Top;
            panelFilters.Location = new Point(20, 20);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(960, 70);
            panelFilters.TabIndex = 0;
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.Font = new Font("Segoe UI", 11F);
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Items.AddRange(new object[] { "All", "Approved", "Pending", "Rented", "Maintenance" });
            cmbStatusFilter.Location = new Point(450, 30);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(200, 28);
            cmbStatusFilter.TabIndex = 3;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            // 
            // lblStatusFilter
            // 
            lblStatusFilter.AutoSize = true;
            lblStatusFilter.Font = new Font("Segoe UI", 11F);
            lblStatusFilter.Location = new Point(450, 5);
            lblStatusFilter.Name = "lblStatusFilter";
            lblStatusFilter.Size = new Size(89, 20);
            lblStatusFilter.TabIndex = 2;
            lblStatusFilter.Text = "Filter Status:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(20, 30);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by plate number, maker, or model...";
            txtSearch.Size = new Size(400, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 11F);
            lblSearch.Location = new Point(20, 5);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(56, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search:";
            // 
            // CarApprovalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 700);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CarApprovalForm";
            Text = "Car Approval & Deletion";
            Load += CarApprovalForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCars).EndInit();
            panelActions.ResumeLayout(false);
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dgvCars;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.Button btnRefresh;
    }
}