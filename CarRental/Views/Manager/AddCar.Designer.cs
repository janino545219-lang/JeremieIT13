namespace CarRental
{
    partial class AddCarForm
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
            btnClear = new Button();
            btnSave = new Button();
            txtDailyPrice = new TextBox();
            lblDailyPrice = new Label();
            cmbTransmission = new ComboBox();
            lblTransmission = new Label();
            numSeats = new NumericUpDown();
            lblSeats = new Label();
            cmbFuelType = new ComboBox();
            lblFuelType = new Label();
            numCarYear = new NumericUpDown();
            lblCarYear = new Label();
            txtCarModel = new TextBox();
            lblCarModel = new Label();
            txtCarMaker = new TextBox();
            lblCarMaker = new Label();
            txtPlateNumber = new TextBox();
            lblPlateNumber = new Label();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSeats).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCarYear).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 44, 51);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(185, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New Car";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(btnClear);
            panelMain.Controls.Add(btnSave);
            panelMain.Controls.Add(txtDailyPrice);
            panelMain.Controls.Add(lblDailyPrice);
            panelMain.Controls.Add(cmbTransmission);
            panelMain.Controls.Add(lblTransmission);
            panelMain.Controls.Add(numSeats);
            panelMain.Controls.Add(lblSeats);
            panelMain.Controls.Add(cmbFuelType);
            panelMain.Controls.Add(lblFuelType);
            panelMain.Controls.Add(numCarYear);
            panelMain.Controls.Add(lblCarYear);
            panelMain.Controls.Add(txtCarModel);
            panelMain.Controls.Add(lblCarModel);
            panelMain.Controls.Add(txtCarMaker);
            panelMain.Controls.Add(lblCarMaker);
            panelMain.Controls.Add(txtPlateNumber);
            panelMain.Controls.Add(lblPlateNumber);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 80);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(40, 30, 40, 30);
            panelMain.Size = new Size(800, 520);
            panelMain.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(108, 117, 125);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(440, 440);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(140, 45);
            btnClear.TabIndex = 17;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 122, 204);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(600, 440);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 45);
            btnSave.TabIndex = 16;
            btnSave.Text = "Save Car";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtDailyPrice
            // 
            txtDailyPrice.Font = new Font("Segoe UI", 11F);
            txtDailyPrice.Location = new Point(440, 330);
            txtDailyPrice.Name = "txtDailyPrice";
            txtDailyPrice.PlaceholderText = "0.00";
            txtDailyPrice.Size = new Size(300, 27);
            txtDailyPrice.TabIndex = 15;
            // 
            // lblDailyPrice
            // 
            lblDailyPrice.AutoSize = true;
            lblDailyPrice.Font = new Font("Segoe UI", 11F);
            lblDailyPrice.Location = new Point(440, 300);
            lblDailyPrice.Name = "lblDailyPrice";
            lblDailyPrice.Size = new Size(147, 20);
            lblDailyPrice.TabIndex = 14;
            lblDailyPrice.Text = "Daily Rental Price ($)";
            // 
            // cmbTransmission
            // 
            cmbTransmission.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTransmission.Font = new Font("Segoe UI", 11F);
            cmbTransmission.FormattingEnabled = true;
            cmbTransmission.Items.AddRange(new object[] { "Automatic", "Manual", "CVT", "Semi-Automatic" });
            cmbTransmission.Location = new Point(60, 330);
            cmbTransmission.Name = "cmbTransmission";
            cmbTransmission.Size = new Size(300, 28);
            cmbTransmission.TabIndex = 13;
            // 
            // lblTransmission
            // 
            lblTransmission.AutoSize = true;
            lblTransmission.Font = new Font("Segoe UI", 11F);
            lblTransmission.Location = new Point(60, 300);
            lblTransmission.Name = "lblTransmission";
            lblTransmission.Size = new Size(93, 20);
            lblTransmission.TabIndex = 12;
            lblTransmission.Text = "Transmission";
            // 
            // numSeats
            // 
            numSeats.Font = new Font("Segoe UI", 11F);
            numSeats.Location = new Point(440, 240);
            numSeats.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numSeats.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numSeats.Name = "numSeats";
            numSeats.Size = new Size(300, 27);
            numSeats.TabIndex = 11;
            numSeats.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblSeats
            // 
            lblSeats.AutoSize = true;
            lblSeats.Font = new Font("Segoe UI", 11F);
            lblSeats.Location = new Point(440, 210);
            lblSeats.Name = "lblSeats";
            lblSeats.Size = new Size(70, 20);
            lblSeats.TabIndex = 10;
            lblSeats.Text = "Car Seats";
            // 
            // cmbFuelType
            // 
            cmbFuelType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFuelType.Font = new Font("Segoe UI", 11F);
            cmbFuelType.FormattingEnabled = true;
            cmbFuelType.Items.AddRange(new object[] { "Gasoline", "Diesel", "Electric", "Hybrid", "Plug-in Hybrid" });
            cmbFuelType.Location = new Point(60, 240);
            cmbFuelType.Name = "cmbFuelType";
            cmbFuelType.Size = new Size(300, 28);
            cmbFuelType.TabIndex = 9;
            // 
            // lblFuelType
            // 
            lblFuelType.AutoSize = true;
            lblFuelType.Font = new Font("Segoe UI", 11F);
            lblFuelType.Location = new Point(60, 210);
            lblFuelType.Name = "lblFuelType";
            lblFuelType.Size = new Size(71, 20);
            lblFuelType.TabIndex = 8;
            lblFuelType.Text = "Fuel Type";
            // 
            // numCarYear
            // 
            numCarYear.Font = new Font("Segoe UI", 11F);
            numCarYear.Location = new Point(440, 150);
            numCarYear.Maximum = new decimal(new int[] { 2030, 0, 0, 0 });
            numCarYear.Minimum = new decimal(new int[] { 1980, 0, 0, 0 });
            numCarYear.Name = "numCarYear";
            numCarYear.Size = new Size(300, 27);
            numCarYear.TabIndex = 7;
            numCarYear.Value = new decimal(new int[] { 2024, 0, 0, 0 });
            // 
            // lblCarYear
            // 
            lblCarYear.AutoSize = true;
            lblCarYear.Font = new Font("Segoe UI", 11F);
            lblCarYear.Location = new Point(440, 120);
            lblCarYear.Name = "lblCarYear";
            lblCarYear.Size = new Size(63, 20);
            lblCarYear.TabIndex = 6;
            lblCarYear.Text = "Car Year";
            // 
            // txtCarModel
            // 
            txtCarModel.Font = new Font("Segoe UI", 11F);
            txtCarModel.Location = new Point(440, 60);
            txtCarModel.Name = "txtCarModel";
            txtCarModel.PlaceholderText = "e.g., Civic, Camry, Model 3";
            txtCarModel.Size = new Size(300, 27);
            txtCarModel.TabIndex = 5;
            // 
            // lblCarModel
            // 
            lblCarModel.AutoSize = true;
            lblCarModel.Font = new Font("Segoe UI", 11F);
            lblCarModel.Location = new Point(440, 30);
            lblCarModel.Name = "lblCarModel";
            lblCarModel.Size = new Size(78, 20);
            lblCarModel.TabIndex = 4;
            lblCarModel.Text = "Car Model";
            // 
            // txtCarMaker
            // 
            txtCarMaker.Font = new Font("Segoe UI", 11F);
            txtCarMaker.Location = new Point(60, 150);
            txtCarMaker.Name = "txtCarMaker";
            txtCarMaker.PlaceholderText = "e.g., Toyota, Honda, Tesla";
            txtCarMaker.Size = new Size(300, 27);
            txtCarMaker.TabIndex = 3;
            // 
            // lblCarMaker
            // 
            lblCarMaker.AutoSize = true;
            lblCarMaker.Font = new Font("Segoe UI", 11F);
            lblCarMaker.Location = new Point(60, 120);
            lblCarMaker.Name = "lblCarMaker";
            lblCarMaker.Size = new Size(76, 20);
            lblCarMaker.TabIndex = 2;
            lblCarMaker.Text = "Car Maker";
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.CharacterCasing = CharacterCasing.Upper;
            txtPlateNumber.Font = new Font("Segoe UI", 11F);
            txtPlateNumber.Location = new Point(60, 60);
            txtPlateNumber.MaxLength = 20;
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.PlaceholderText = "e.g., ABC-1234";
            txtPlateNumber.Size = new Size(300, 27);
            txtPlateNumber.TabIndex = 1;
            // 
            // lblPlateNumber
            // 
            lblPlateNumber.AutoSize = true;
            lblPlateNumber.Font = new Font("Segoe UI", 11F);
            lblPlateNumber.Location = new Point(60, 30);
            lblPlateNumber.Name = "lblPlateNumber";
            lblPlateNumber.Size = new Size(100, 20);
            lblPlateNumber.TabIndex = 0;
            lblPlateNumber.Text = "Plate Number";
            // 
            // AddCarForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddCarForm";
            Text = "Add Car";
            Load += AddCarForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSeats).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCarYear).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TextBox txtPlateNumber;
        private System.Windows.Forms.Label lblPlateNumber;
        private System.Windows.Forms.TextBox txtCarMaker;
        private System.Windows.Forms.Label lblCarMaker;
        private System.Windows.Forms.TextBox txtCarModel;
        private System.Windows.Forms.Label lblCarModel;
        private System.Windows.Forms.NumericUpDown numCarYear;
        private System.Windows.Forms.Label lblCarYear;
        private System.Windows.Forms.ComboBox cmbFuelType;
        private System.Windows.Forms.Label lblFuelType;
        private System.Windows.Forms.NumericUpDown numSeats;
        private System.Windows.Forms.Label lblSeats;
        private System.Windows.Forms.ComboBox cmbTransmission;
        private System.Windows.Forms.Label lblTransmission;
        private System.Windows.Forms.TextBox txtDailyPrice;
        private System.Windows.Forms.Label lblDailyPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
    }
}