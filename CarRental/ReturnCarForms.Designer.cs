namespace CarRental
{
    partial class ReturnCarForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            panelMain = new Panel();

            // Top info labels & fields
            label2 = new Label();
            cmbRentalID = new ComboBox();
            label3 = new Label();
            txtCustomerName = new TextBox();
            label4 = new Label();
            txtPlateNumber = new TextBox();
            label5 = new Label();
            txtCarRented = new TextBox();
            label6 = new Label();
            dtpReturnDate = new DateTimePicker();
            label7 = new Label();
            txtOverdueDays = new TextBox();

            // GroupBoxes
            groupBoxDamages = new GroupBox();
            groupBoxCharges = new GroupBox();
            groupBoxNotes = new GroupBox();

            // Damage checkboxes
            chkScratch = new CheckBox();
            chkDentedBumper = new CheckBox();
            chkBrokenMirror = new CheckBox();
            chkFlatTire = new CheckBox();
            chkWindshieldCrack = new CheckBox();
            chkBrokenHeadlight = new CheckBox();
            chkBrokenTaillight = new CheckBox();
            chkStainedUpholstery = new CheckBox();

            // Damage price labels
            lblPriceScratch = new Label();
            lblPriceDentedBumper = new Label();
            lblPriceBrokenMirror = new Label();
            lblPriceFlatTire = new Label();
            lblPriceWindshieldCrack = new Label();
            lblPriceBrokenHeadlight = new Label();
            lblPriceBrokenTaillight = new Label();
            lblPriceStainedUpholstery = new Label();

            // Charges
            label8 = new Label();
            txtOverdueCharges = new TextBox();
            label9 = new Label();
            txtDamageCost = new TextBox();
            label10 = new Label();
            txtTotalPrice = new TextBox();

            // Notes
            txtNotes = new TextBox();

            // Buttons
            btnReturn = new Button();
            btnClear = new Button();

            panelMain.SuspendLayout();
            groupBoxDamages.SuspendLayout();
            groupBoxCharges.SuspendLayout();
            groupBoxNotes.SuspendLayout();
            SuspendLayout();

            // ── lblTitle ───────────────────────────────────────────────────────────
            lblTitle.BackColor = Color.FromArgb(41, 44, 51);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1100, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "RETURN CAR";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // ── panelMain ──────────────────────────────────────────────────────────
            panelMain.AutoScroll = true;
            panelMain.BackColor = Color.White;
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 60);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(25, 18, 25, 18);
            panelMain.TabIndex = 1;

            // ── ROW 1: Select Rental ID (full width) ───────────────────────────────
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(25, 20);
            label2.Name = "label2";
            label2.Text = "Select Rental ID:";

            cmbRentalID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRentalID.Font = new Font("Segoe UI", 10F);
            cmbRentalID.Location = new Point(180, 16);
            cmbRentalID.Name = "cmbRentalID";
            cmbRentalID.Size = new Size(870, 26);
            cmbRentalID.TabIndex = 1;
            cmbRentalID.SelectedIndexChanged += cmbRentalID_SelectedIndexChanged;

            // ── ROW 2: Customer Name ───────────────────────────────────────────────
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(25, 58);
            label3.Name = "label3";
            label3.Text = "Customer Name:";

            txtCustomerName.Font = new Font("Segoe UI", 10F);
            txtCustomerName.Location = new Point(180, 55);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.ReadOnly = true;
            txtCustomerName.Size = new Size(400, 26);
            txtCustomerName.TabIndex = 2;

            // ── ROW 2 right: Return Date ───────────────────────────────────────────
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(620, 58);
            label6.Name = "label6";
            label6.Text = "Return Date:";

            dtpReturnDate.Font = new Font("Segoe UI", 10F);
            dtpReturnDate.Format = DateTimePickerFormat.Short;
            dtpReturnDate.Location = new Point(730, 55);
            dtpReturnDate.Name = "dtpReturnDate";
            dtpReturnDate.Size = new Size(160, 26);
            dtpReturnDate.TabIndex = 3;
            dtpReturnDate.ValueChanged += dtpReturnDate_ValueChanged;

            // ── ROW 3: Plate Number + Overdue Days ────────────────────────────────
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(25, 96);
            label4.Name = "label4";
            label4.Text = "Plate Number:";

            txtPlateNumber.Font = new Font("Segoe UI", 10F);
            txtPlateNumber.Location = new Point(180, 93);
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.ReadOnly = true;
            txtPlateNumber.Size = new Size(400, 26);
            txtPlateNumber.TabIndex = 4;

            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.Location = new Point(620, 96);
            label7.Name = "label7";
            label7.Text = "Overdue Days:";

            txtOverdueDays.Font = new Font("Segoe UI", 10F);
            txtOverdueDays.Location = new Point(730, 93);
            txtOverdueDays.Name = "txtOverdueDays";
            txtOverdueDays.ReadOnly = true;
            txtOverdueDays.Size = new Size(160, 26);
            txtOverdueDays.TabIndex = 5;
            txtOverdueDays.Text = "0";

            // ── ROW 4: Car Rented ─────────────────────────────────────────────────
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(25, 134);
            label5.Name = "label5";
            label5.Text = "Car Rented:";

            txtCarRented.Font = new Font("Segoe UI", 10F);
            txtCarRented.Location = new Point(180, 131);
            txtCarRented.Name = "txtCarRented";
            txtCarRented.ReadOnly = true;
            txtCarRented.Size = new Size(870, 26);
            txtCarRented.TabIndex = 6;

            // ── groupBoxDamages ────────────────────────────────────────────────────
            // Layout: 4 columns × 2 rows inside the group box
            // Col A: x=20  Col B(price): x=175  Col C: x=260  Col D(price): x=415
            // Col E: x=500 Col F(price): x=655  Col G: x=740  Col H(price): x=900
            groupBoxDamages.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxDamages.Location = new Point(25, 172);
            groupBoxDamages.Name = "groupBoxDamages";
            groupBoxDamages.Size = new Size(1050, 175);
            groupBoxDamages.TabIndex = 10;
            groupBoxDamages.TabStop = false;
            groupBoxDamages.Text = "VEHICLE DAMAGES (Check if applicable)";

            int rowA = 35, rowB = 80, rowC = 125;
            int c1 = 20, c1p = 175, c2 = 265, c2p = 420, c3 = 515, c3p = 670, c4 = 760, c4p = 910;

            // Row 1: Scratch | Dented Bumper | Flat Tire | Windshield Crack
            SetupCheck(chkScratch, "Scratch", c1, rowA, 0);
            SetupPriceLabel(lblPriceScratch, "₱ 500.00", c1p, rowA + 3);

            SetupCheck(chkDentedBumper, "Dented Bumper", c2, rowA, 1);
            SetupPriceLabel(lblPriceDentedBumper, "₱ 1,500.00", c2p, rowA + 3);

            SetupCheck(chkFlatTire, "Flat Tire", c3, rowA, 3);
            SetupPriceLabel(lblPriceFlatTire, "₱ 600.00", c3p, rowA + 3);

            SetupCheck(chkWindshieldCrack, "Windshield Crack", c4, rowA, 4);
            SetupPriceLabel(lblPriceWindshieldCrack, "₱ 2,000.00", c4p, rowA + 3);

            // Row 2: Broken Mirror | Broken Headlight | Broken Taillight | Stained Upholstery
            SetupCheck(chkBrokenMirror, "Broken Mirror", c1, rowB, 2);
            SetupPriceLabel(lblPriceBrokenMirror, "₱ 800.00", c1p, rowB + 3);

            SetupCheck(chkBrokenHeadlight, "Broken Headlight", c2, rowB, 6);
            SetupPriceLabel(lblPriceBrokenHeadlight, "₱ 700.00", c2p, rowB + 3);

            SetupCheck(chkBrokenTaillight, "Broken Taillight", c3, rowB, 6);
            SetupPriceLabel(lblPriceBrokenTaillight, "₱ 600.00", c3p, rowB + 3);

            SetupCheck(chkStainedUpholstery, "Stained Upholstery", c4, rowB, 7);
            SetupPriceLabel(lblPriceStainedUpholstery, "₱ 1,000.00", c4p, rowB + 3);

            groupBoxDamages.Controls.AddRange(new Control[]
            {
                chkScratch, lblPriceScratch,
                chkDentedBumper, lblPriceDentedBumper,
                chkFlatTire, lblPriceFlatTire,
                chkWindshieldCrack, lblPriceWindshieldCrack,
                chkBrokenMirror, lblPriceBrokenMirror,
                chkBrokenHeadlight, lblPriceBrokenHeadlight,
                chkBrokenTaillight, lblPriceBrokenTaillight,
                chkStainedUpholstery, lblPriceStainedUpholstery
            });

            // ── groupBoxCharges ────────────────────────────────────────────────────
            groupBoxCharges.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxCharges.Location = new Point(25, 360);
            groupBoxCharges.Name = "groupBoxCharges";
            groupBoxCharges.Size = new Size(1050, 130);
            groupBoxCharges.TabIndex = 11;
            groupBoxCharges.TabStop = false;
            groupBoxCharges.Text = "CHARGES SUMMARY";

            // Overdue Charges
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(20, 38);
            label8.Name = "label8";
            label8.Text = "Overdue Charges:";

            txtOverdueCharges.Font = new Font("Segoe UI", 10F);
            txtOverdueCharges.Location = new Point(155, 35);
            txtOverdueCharges.Name = "txtOverdueCharges";
            txtOverdueCharges.ReadOnly = true;
            txtOverdueCharges.Size = new Size(160, 26);
            txtOverdueCharges.TabIndex = 0;
            txtOverdueCharges.Text = "0.00";
            txtOverdueCharges.TextAlign = HorizontalAlignment.Right;

            // Damage Costs
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.Location = new Point(360, 38);
            label9.Name = "label9";
            label9.Text = "Damage Costs:";

            txtDamageCost.Font = new Font("Segoe UI", 10F);
            txtDamageCost.Location = new Point(480, 35);
            txtDamageCost.Name = "txtDamageCost";
            txtDamageCost.ReadOnly = true;
            txtDamageCost.Size = new Size(160, 26);
            txtDamageCost.TabIndex = 1;
            txtDamageCost.Text = "0.00";
            txtDamageCost.TextAlign = HorizontalAlignment.Right;

            // Total Charges
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label10.Location = new Point(690, 38);
            label10.Name = "label10";
            label10.Text = "TOTAL CHARGES:";

            txtTotalPrice.BackColor = Color.FromArgb(255, 255, 192);
            txtTotalPrice.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            txtTotalPrice.Location = new Point(840, 32);
            txtTotalPrice.Name = "txtTotalPrice";
            txtTotalPrice.ReadOnly = true;
            txtTotalPrice.Size = new Size(185, 32);
            txtTotalPrice.TabIndex = 2;
            txtTotalPrice.Text = "0.00";
            txtTotalPrice.TextAlign = HorizontalAlignment.Right;

            groupBoxCharges.Controls.AddRange(new Control[]
            {
                label8, txtOverdueCharges,
                label9, txtDamageCost,
                label10, txtTotalPrice
            });

            // ── groupBoxNotes ──────────────────────────────────────────────────────
            groupBoxNotes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxNotes.Location = new Point(25, 502);
            groupBoxNotes.Name = "groupBoxNotes";
            groupBoxNotes.Size = new Size(1050, 110);
            groupBoxNotes.TabIndex = 12;
            groupBoxNotes.TabStop = false;
            groupBoxNotes.Text = "NOTES / COMMENTS";

            txtNotes.Font = new Font("Segoe UI", 10F);
            txtNotes.Location = new Point(12, 28);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(1020, 68);
            txtNotes.TabIndex = 0;

            groupBoxNotes.Controls.Add(txtNotes);

            // ── Buttons ────────────────────────────────────────────────────────────
            btnReturn.BackColor = Color.FromArgb(40, 167, 69);
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReturn.ForeColor = Color.White;
            btnReturn.Location = new Point(25, 626);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(200, 50);
            btnReturn.TabIndex = 13;
            btnReturn.Text = "RETURN CAR";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;

            btnClear.BackColor = Color.FromArgb(108, 117, 125);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(240, 626);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(160, 50);
            btnClear.TabIndex = 14;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;

            // ── Add all controls to panelMain ──────────────────────────────────────
            panelMain.Controls.AddRange(new Control[]
            {
                label2, cmbRentalID,
                label3, txtCustomerName,
                label6, dtpReturnDate,
                label4, txtPlateNumber,
                label7, txtOverdueDays,
                label5, txtCarRented,
                groupBoxDamages,
                groupBoxCharges,
                groupBoxNotes,
                btnReturn, btnClear
            });

            // ── Form ───────────────────────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(panelMain);
            Controls.Add(lblTitle);
            Name = "ReturnCarForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Return Car";
            Load += ReturnCarForm_Load;

            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            groupBoxDamages.ResumeLayout(false);
            groupBoxDamages.PerformLayout();
            groupBoxCharges.ResumeLayout(false);
            groupBoxCharges.PerformLayout();
            groupBoxNotes.ResumeLayout(false);
            groupBoxNotes.PerformLayout();
            ResumeLayout(false);
        }

        // Helper to set up checkboxes cleanly
        private void SetupCheck(CheckBox chk, string text, int x, int y, int tabIndex)
        {
            chk.AutoSize = true;
            chk.Font = new Font("Segoe UI", 10F);
            chk.Location = new Point(x, y);
            chk.Text = text;
            chk.TabIndex = tabIndex;
            chk.UseVisualStyleBackColor = true;
        }

        private void SetupPriceLabel(Label lbl, string text, int x, int y)
        {
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 9F);
            lbl.ForeColor = Color.Red;
            lbl.Location = new Point(x, y);
            lbl.Text = text;
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRentalID;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlateNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCarRented;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOverdueDays;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBoxNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.GroupBox groupBoxDamages;
        private System.Windows.Forms.CheckBox chkScratch;
        private System.Windows.Forms.CheckBox chkStainedUpholstery;
        private System.Windows.Forms.CheckBox chkBrokenTaillight;
        private System.Windows.Forms.CheckBox chkBrokenHeadlight;
        private System.Windows.Forms.CheckBox chkWindshieldCrack;
        private System.Windows.Forms.CheckBox chkFlatTire;
        private System.Windows.Forms.CheckBox chkBrokenMirror;
        private System.Windows.Forms.CheckBox chkDentedBumper;
        private System.Windows.Forms.GroupBox groupBoxCharges;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDamageCost;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtOverdueCharges;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPriceScratch;
        private System.Windows.Forms.Label lblPriceStainedUpholstery;
        private System.Windows.Forms.Label lblPriceBrokenTaillight;
        private System.Windows.Forms.Label lblPriceBrokenHeadlight;
        private System.Windows.Forms.Label lblPriceWindshieldCrack;
        private System.Windows.Forms.Label lblPriceFlatTire;
        private System.Windows.Forms.Label lblPriceBrokenMirror;
        private System.Windows.Forms.Label lblPriceDentedBumper;
    }
}