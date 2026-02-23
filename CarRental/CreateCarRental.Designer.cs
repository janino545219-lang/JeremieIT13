namespace CarRental
{
    partial class CreateCarRentalForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelTop = new Panel();
            lblTitle = new Label();
            btnClose = new Button();
            panelMain = new Panel();
            lblCarInfo = new Label();
            groupBoxServices = new GroupBox();
            chkExtraDriver = new CheckBox();
            chkExtendedMileage = new CheckBox();
            chkWifiHotspot = new CheckBox();
            chkRoadsideAssistance = new CheckBox();
            chkAdditionalInsurance = new CheckBox();
            groupBoxPricing = new GroupBox();
            lblTotalAmount = new Label();
            lblTotalCost = new Label();
            lblServiceCostAmount = new Label();
            lblServiceCost = new Label();
            lblDailyRateAmount = new Label();
            lblDailyRate = new Label();
            btnCalculate = new Button();
            btnSaveRental = new Button();
            btnClear = new Button();
            lblRentalDays = new Label();
            txtRentalDays = new TextBox();
            lblEndDate = new Label();
            dtpEndDate = new DateTimePicker();
            lblStartDate = new Label();
            dtpStartDate = new DateTimePicker();
            lblCustomerName = new Label();
            cmbCustomer = new ComboBox();
            lblPlateNumber = new Label();
            cmbPlateNumber = new ComboBox();
            panelTop.SuspendLayout();
            panelMain.SuspendLayout();
            groupBoxServices.SuspendLayout();
            groupBoxPricing.SuspendLayout();
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
            panelTop.Size = new Size(900, 60);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(211, 32);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Create Car Rental";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(231, 76, 60);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(840, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(48, 36);
            btnClose.TabIndex = 0;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(lblCarInfo);
            panelMain.Controls.Add(groupBoxServices);
            panelMain.Controls.Add(groupBoxPricing);
            panelMain.Controls.Add(btnCalculate);
            panelMain.Controls.Add(btnSaveRental);
            panelMain.Controls.Add(btnClear);
            panelMain.Controls.Add(lblRentalDays);
            panelMain.Controls.Add(txtRentalDays);
            panelMain.Controls.Add(lblEndDate);
            panelMain.Controls.Add(dtpEndDate);
            panelMain.Controls.Add(lblStartDate);
            panelMain.Controls.Add(dtpStartDate);
            panelMain.Controls.Add(lblCustomerName);
            panelMain.Controls.Add(cmbCustomer);
            panelMain.Controls.Add(lblPlateNumber);
            panelMain.Controls.Add(cmbPlateNumber);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 60);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(20);
            panelMain.Size = new Size(900, 640);
            panelMain.TabIndex = 1;
            // 
            // lblCarInfo
            // 
            lblCarInfo.BackColor = Color.FromArgb(236, 240, 241);
            lblCarInfo.Font = new Font("Segoe UI", 10F);
            lblCarInfo.Location = new Point(23, 100);
            lblCarInfo.Name = "lblCarInfo";
            lblCarInfo.Padding = new Padding(10);
            lblCarInfo.Size = new Size(854, 50);
            lblCarInfo.TabIndex = 20;
            lblCarInfo.Text = "Select a car to see details...";
            // 
            // groupBoxServices
            // 
            groupBoxServices.Controls.Add(chkExtraDriver);
            groupBoxServices.Controls.Add(chkExtendedMileage);
            groupBoxServices.Controls.Add(chkWifiHotspot);
            groupBoxServices.Controls.Add(chkRoadsideAssistance);
            groupBoxServices.Controls.Add(chkAdditionalInsurance);
            groupBoxServices.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxServices.Location = new Point(23, 310);
            groupBoxServices.Name = "groupBoxServices";
            groupBoxServices.Size = new Size(420, 180);
            groupBoxServices.TabIndex = 15;
            groupBoxServices.TabStop = false;
            groupBoxServices.Text = "Additional Services";
            // 
            // chkExtraDriver
            // 
            chkExtraDriver.AutoSize = true;
            chkExtraDriver.Font = new Font("Segoe UI", 10F);
            chkExtraDriver.Location = new Point(20, 145);
            chkExtraDriver.Name = "chkExtraDriver";
            chkExtraDriver.Size = new Size(172, 23);
            chkExtraDriver.TabIndex = 4;
            chkExtraDriver.Text = "Extra Driver (+$10/day)";
            chkExtraDriver.UseVisualStyleBackColor = true;
            // 
            // chkExtendedMileage
            // 
            chkExtendedMileage.AutoSize = true;
            chkExtendedMileage.Font = new Font("Segoe UI", 10F);
            chkExtendedMileage.Location = new Point(20, 115);
            chkExtendedMileage.Name = "chkExtendedMileage";
            chkExtendedMileage.Size = new Size(209, 23);
            chkExtendedMileage.TabIndex = 3;
            chkExtendedMileage.Text = "Extended Mileage (+$15/day)";
            chkExtendedMileage.UseVisualStyleBackColor = true;
            // 
            // chkWifiHotspot
            // 
            chkWifiHotspot.AutoSize = true;
            chkWifiHotspot.Font = new Font("Segoe UI", 10F);
            chkWifiHotspot.Location = new Point(20, 85);
            chkWifiHotspot.Name = "chkWifiHotspot";
            chkWifiHotspot.Size = new Size(173, 23);
            chkWifiHotspot.TabIndex = 2;
            chkWifiHotspot.Text = "WiFi Hotspot (+$8/day)";
            chkWifiHotspot.UseVisualStyleBackColor = true;
            // 
            // chkRoadsideAssistance
            // 
            chkRoadsideAssistance.AutoSize = true;
            chkRoadsideAssistance.Font = new Font("Segoe UI", 10F);
            chkRoadsideAssistance.Location = new Point(20, 55);
            chkRoadsideAssistance.Name = "chkRoadsideAssistance";
            chkRoadsideAssistance.Size = new Size(223, 23);
            chkRoadsideAssistance.TabIndex = 1;
            chkRoadsideAssistance.Text = "Roadside Assistance (+$12/day)";
            chkRoadsideAssistance.UseVisualStyleBackColor = true;
            // 
            // chkAdditionalInsurance
            // 
            chkAdditionalInsurance.AutoSize = true;
            chkAdditionalInsurance.Font = new Font("Segoe UI", 10F);
            chkAdditionalInsurance.Location = new Point(20, 25);
            chkAdditionalInsurance.Name = "chkAdditionalInsurance";
            chkAdditionalInsurance.Size = new Size(226, 23);
            chkAdditionalInsurance.TabIndex = 0;
            chkAdditionalInsurance.Text = "Additional Insurance (+$20/day)";
            chkAdditionalInsurance.UseVisualStyleBackColor = true;
            // 
            // groupBoxPricing
            // 
            groupBoxPricing.Controls.Add(lblTotalAmount);
            groupBoxPricing.Controls.Add(lblTotalCost);
            groupBoxPricing.Controls.Add(lblServiceCostAmount);
            groupBoxPricing.Controls.Add(lblServiceCost);
            groupBoxPricing.Controls.Add(lblDailyRateAmount);
            groupBoxPricing.Controls.Add(lblDailyRate);
            groupBoxPricing.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxPricing.Location = new Point(457, 310);
            groupBoxPricing.Name = "groupBoxPricing";
            groupBoxPricing.Size = new Size(420, 180);
            groupBoxPricing.TabIndex = 16;
            groupBoxPricing.TabStop = false;
            groupBoxPricing.Text = "Pricing Summary";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(39, 174, 96);
            lblTotalAmount.Location = new Point(200, 125);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(200, 30);
            lblTotalAmount.TabIndex = 5;
            lblTotalAmount.Text = "$0.00";
            lblTotalAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalCost
            // 
            lblTotalCost.AutoSize = true;
            lblTotalCost.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalCost.Location = new Point(20, 130);
            lblTotalCost.Name = "lblTotalCost";
            lblTotalCost.Size = new Size(89, 21);
            lblTotalCost.TabIndex = 4;
            lblTotalCost.Text = "Total Cost:";
            // 
            // lblServiceCostAmount
            // 
            lblServiceCostAmount.Font = new Font("Segoe UI", 11F);
            lblServiceCostAmount.Location = new Point(200, 80);
            lblServiceCostAmount.Name = "lblServiceCostAmount";
            lblServiceCostAmount.Size = new Size(200, 23);
            lblServiceCostAmount.TabIndex = 3;
            lblServiceCostAmount.Text = "$0.00";
            lblServiceCostAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblServiceCost
            // 
            lblServiceCost.AutoSize = true;
            lblServiceCost.Font = new Font("Segoe UI", 10F);
            lblServiceCost.Location = new Point(20, 80);
            lblServiceCost.Name = "lblServiceCost";
            lblServiceCost.Size = new Size(158, 19);
            lblServiceCost.TabIndex = 2;
            lblServiceCost.Text = "Additional Services Cost:";
            // 
            // lblDailyRateAmount
            // 
            lblDailyRateAmount.Font = new Font("Segoe UI", 11F);
            lblDailyRateAmount.Location = new Point(200, 40);
            lblDailyRateAmount.Name = "lblDailyRateAmount";
            lblDailyRateAmount.Size = new Size(200, 23);
            lblDailyRateAmount.TabIndex = 1;
            lblDailyRateAmount.Text = "$0.00";
            lblDailyRateAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDailyRate
            // 
            lblDailyRate.AutoSize = true;
            lblDailyRate.Font = new Font("Segoe UI", 10F);
            lblDailyRate.Location = new Point(20, 40);
            lblDailyRate.Name = "lblDailyRate";
            lblDailyRate.Size = new Size(159, 19);
            lblDailyRate.TabIndex = 0;
            lblDailyRate.Text = "Daily Rate x Rental Days:";
            // 
            // btnCalculate
            // 
            btnCalculate.BackColor = Color.FromArgb(52, 152, 219);
            btnCalculate.FlatAppearance.BorderSize = 0;
            btnCalculate.FlatStyle = FlatStyle.Flat;
            btnCalculate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCalculate.ForeColor = Color.White;
            btnCalculate.Location = new Point(23, 510);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(130, 45);
            btnCalculate.TabIndex = 17;
            btnCalculate.Text = "CALCULATE";
            btnCalculate.UseVisualStyleBackColor = false;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnSaveRental
            // 
            btnSaveRental.BackColor = Color.FromArgb(39, 174, 96);
            btnSaveRental.FlatAppearance.BorderSize = 0;
            btnSaveRental.FlatStyle = FlatStyle.Flat;
            btnSaveRental.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSaveRental.ForeColor = Color.White;
            btnSaveRental.Location = new Point(159, 510);
            btnSaveRental.Name = "btnSaveRental";
            btnSaveRental.Size = new Size(150, 45);
            btnSaveRental.TabIndex = 18;
            btnSaveRental.Text = "SAVE RENTAL";
            btnSaveRental.UseVisualStyleBackColor = false;
            btnSaveRental.Click += btnSaveRental_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(149, 165, 166);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(315, 510);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 45);
            btnClear.TabIndex = 19;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // lblRentalDays
            // 
            lblRentalDays.AutoSize = true;
            lblRentalDays.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRentalDays.Location = new Point(457, 239);
            lblRentalDays.Name = "lblRentalDays";
            lblRentalDays.Size = new Size(96, 20);
            lblRentalDays.TabIndex = 13;
            lblRentalDays.Text = "Rental Days:";
            // 
            // txtRentalDays
            // 
            txtRentalDays.BackColor = Color.FromArgb(236, 240, 241);
            txtRentalDays.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtRentalDays.Location = new Point(457, 262);
            txtRentalDays.Name = "txtRentalDays";
            txtRentalDays.ReadOnly = true;
            txtRentalDays.Size = new Size(200, 29);
            txtRentalDays.TabIndex = 14;
            txtRentalDays.Text = "0";
            txtRentalDays.TextAlign = HorizontalAlignment.Center;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEndDate.Location = new Point(457, 172);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(184, 20);
            lblEndDate.TabIndex = 11;
            lblEndDate.Text = "End Date (dd/mm/yyyy):";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Font = new Font("Segoe UI", 11F);
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(457, 195);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(420, 27);
            dtpEndDate.TabIndex = 12;
            dtpEndDate.ValueChanged += dtpEndDate_ValueChanged;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStartDate.Location = new Point(23, 172);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(192, 20);
            lblStartDate.TabIndex = 9;
            lblStartDate.Text = "Start Date (dd/mm/yyyy):";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Font = new Font("Segoe UI", 11F);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(23, 195);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(420, 27);
            dtpStartDate.TabIndex = 10;
            dtpStartDate.ValueChanged += dtpStartDate_ValueChanged;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCustomerName.Location = new Point(457, 35);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(156, 20);
            lblCustomerName.TabIndex = 7;
            lblCustomerName.Text = "Customer Full Name:";
            // 
            // cmbCustomer
            // 
            cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomer.Font = new Font("Segoe UI", 11F);
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(457, 58);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(420, 28);
            cmbCustomer.TabIndex = 8;
            // 
            // lblPlateNumber
            // 
            lblPlateNumber.AutoSize = true;
            lblPlateNumber.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPlateNumber.Location = new Point(23, 35);
            lblPlateNumber.Name = "lblPlateNumber";
            lblPlateNumber.Size = new Size(138, 20);
            lblPlateNumber.TabIndex = 5;
            lblPlateNumber.Text = "Car Plate Number:";
            // 
            // cmbPlateNumber
            // 
            cmbPlateNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlateNumber.Font = new Font("Segoe UI", 11F);
            cmbPlateNumber.FormattingEnabled = true;
            cmbPlateNumber.Location = new Point(23, 58);
            cmbPlateNumber.Name = "cmbPlateNumber";
            cmbPlateNumber.Size = new Size(420, 28);
            cmbPlateNumber.TabIndex = 6;
            cmbPlateNumber.SelectedIndexChanged += cmbPlateNumber_SelectedIndexChanged;
            // 
            // CreateCarRentalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 700);
            Controls.Add(panelMain);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CreateCarRentalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Car Rental";
            Load += CreateCarRentalForm_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            groupBoxServices.ResumeLayout(false);
            groupBoxServices.PerformLayout();
            groupBoxPricing.ResumeLayout(false);
            groupBoxPricing.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblPlateNumber;
        private System.Windows.Forms.ComboBox cmbPlateNumber;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblRentalDays;
        private System.Windows.Forms.TextBox txtRentalDays;
        private System.Windows.Forms.GroupBox groupBoxServices;
        private System.Windows.Forms.CheckBox chkAdditionalInsurance;
        private System.Windows.Forms.CheckBox chkRoadsideAssistance;
        private System.Windows.Forms.CheckBox chkWifiHotspot;
        private System.Windows.Forms.CheckBox chkExtendedMileage;
        private System.Windows.Forms.CheckBox chkExtraDriver;
        private System.Windows.Forms.GroupBox groupBoxPricing;
        private System.Windows.Forms.Label lblDailyRate;
        private System.Windows.Forms.Label lblDailyRateAmount;
        private System.Windows.Forms.Label lblServiceCost;
        private System.Windows.Forms.Label lblServiceCostAmount;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnSaveRental;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblCarInfo;
    }
}