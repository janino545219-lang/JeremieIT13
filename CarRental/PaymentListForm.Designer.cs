namespace CarRental
{
    partial class PaymentListForm
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
            groupBoxDetails = new GroupBox();
            txtReferenceNumber = new TextBox();
            lblReferenceNumber = new Label();
            groupBoxAmount = new GroupBox();
            lblChangeAmount = new Label();
            lblChange = new Label();
            txtAmountPaid = new TextBox();
            lblAmountPaid = new Label();
            lblTotalAmountValue = new Label();
            lblTotalAmount = new Label();
            groupBoxPaymentMethod = new GroupBox();
            panelCard = new Panel();
            lblCard = new Label();
            panelGCash = new Panel();
            lblGCash = new Label();
            panelCash = new Panel();
            lblCash = new Label();
            lblSelectPayment = new Label();
            groupBoxRentalInfo = new GroupBox();
            lblPlateNumberValue = new Label();
            lblPlateNumber = new Label();
            lblCustomerValue = new Label();
            lblCustomer = new Label();
            lblRentalIDValue = new Label();
            lblRentalID = new Label();
            btnCancel = new Button();
            btnProcessPayment = new Button();
            panelTop.SuspendLayout();
            panelMain.SuspendLayout();
            groupBoxDetails.SuspendLayout();
            groupBoxAmount.SuspendLayout();
            groupBoxPaymentMethod.SuspendLayout();
            panelCard.SuspendLayout();
            panelGCash.SuspendLayout();
            panelCash.SuspendLayout();
            groupBoxRentalInfo.SuspendLayout();
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
            lblTitle.Size = new Size(113, 32);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Payment";
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
            panelMain.Controls.Add(groupBoxDetails);
            panelMain.Controls.Add(groupBoxAmount);
            panelMain.Controls.Add(groupBoxPaymentMethod);
            panelMain.Controls.Add(groupBoxRentalInfo);
            panelMain.Controls.Add(btnCancel);
            panelMain.Controls.Add(btnProcessPayment);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 60);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(20);
            panelMain.Size = new Size(900, 640);
            panelMain.TabIndex = 1;
            // 
            // groupBoxDetails
            // 
            groupBoxDetails.Controls.Add(txtReferenceNumber);
            groupBoxDetails.Controls.Add(lblReferenceNumber);
            groupBoxDetails.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxDetails.Location = new Point(457, 340);
            groupBoxDetails.Name = "groupBoxDetails";
            groupBoxDetails.Size = new Size(420, 180);
            groupBoxDetails.TabIndex = 3;
            groupBoxDetails.TabStop = false;
            groupBoxDetails.Text = "Payment Details";
            // 
            // txtReferenceNumber
            // 
            txtReferenceNumber.Enabled = false;
            txtReferenceNumber.Font = new Font("Segoe UI", 11F);
            txtReferenceNumber.Location = new Point(20, 80);
            txtReferenceNumber.Name = "txtReferenceNumber";
            txtReferenceNumber.PlaceholderText = "Enter reference number...";
            txtReferenceNumber.Size = new Size(380, 27);
            txtReferenceNumber.TabIndex = 1;
            // 
            // lblReferenceNumber
            // 
            lblReferenceNumber.AutoSize = true;
            lblReferenceNumber.Font = new Font("Segoe UI", 10F);
            lblReferenceNumber.Location = new Point(20, 50);
            lblReferenceNumber.Name = "lblReferenceNumber";
            lblReferenceNumber.Size = new Size(211, 19);
            lblReferenceNumber.TabIndex = 0;
            lblReferenceNumber.Text = "Reference Number (GCash/Card):";
            // 
            // groupBoxAmount
            // 
            groupBoxAmount.Controls.Add(lblChangeAmount);
            groupBoxAmount.Controls.Add(lblChange);
            groupBoxAmount.Controls.Add(txtAmountPaid);
            groupBoxAmount.Controls.Add(lblAmountPaid);
            groupBoxAmount.Controls.Add(lblTotalAmountValue);
            groupBoxAmount.Controls.Add(lblTotalAmount);
            groupBoxAmount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxAmount.Location = new Point(23, 340);
            groupBoxAmount.Name = "groupBoxAmount";
            groupBoxAmount.Size = new Size(420, 180);
            groupBoxAmount.TabIndex = 2;
            groupBoxAmount.TabStop = false;
            groupBoxAmount.Text = "Amount";
            // 
            // lblChangeAmount
            // 
            lblChangeAmount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblChangeAmount.ForeColor = Color.FromArgb(39, 174, 96);
            lblChangeAmount.Location = new Point(180, 130);
            lblChangeAmount.Name = "lblChangeAmount";
            lblChangeAmount.Size = new Size(220, 30);
            lblChangeAmount.TabIndex = 5;
            lblChangeAmount.Text = "$0.00";
            lblChangeAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblChange
            // 
            lblChange.AutoSize = true;
            lblChange.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChange.Location = new Point(20, 135);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(65, 20);
            lblChange.TabIndex = 4;
            lblChange.Text = "Change:";
            // 
            // txtAmountPaid
            // 
            txtAmountPaid.Font = new Font("Segoe UI", 12F);
            txtAmountPaid.Location = new Point(180, 80);
            txtAmountPaid.Name = "txtAmountPaid";
            txtAmountPaid.Size = new Size(220, 29);
            txtAmountPaid.TabIndex = 3;
            txtAmountPaid.Text = "0.00";
            txtAmountPaid.TextAlign = HorizontalAlignment.Right;
            txtAmountPaid.TextChanged += txtAmountPaid_TextChanged;
            // 
            // lblAmountPaid
            // 
            lblAmountPaid.AutoSize = true;
            lblAmountPaid.Font = new Font("Segoe UI", 11F);
            lblAmountPaid.Location = new Point(20, 85);
            lblAmountPaid.Name = "lblAmountPaid";
            lblAmountPaid.Size = new Size(97, 20);
            lblAmountPaid.TabIndex = 2;
            lblAmountPaid.Text = "Amount Paid:";
            // 
            // lblTotalAmountValue
            // 
            lblTotalAmountValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalAmountValue.ForeColor = Color.FromArgb(231, 76, 60);
            lblTotalAmountValue.Location = new Point(180, 30);
            lblTotalAmountValue.Name = "lblTotalAmountValue";
            lblTotalAmountValue.Size = new Size(220, 30);
            lblTotalAmountValue.TabIndex = 1;
            lblTotalAmountValue.Text = "$0.00";
            lblTotalAmountValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalAmount.Location = new Point(20, 35);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(118, 21);
            lblTotalAmount.TabIndex = 0;
            lblTotalAmount.Text = "Total Amount:";
            // 
            // groupBoxPaymentMethod
            // 
            groupBoxPaymentMethod.Controls.Add(panelCard);
            groupBoxPaymentMethod.Controls.Add(panelGCash);
            groupBoxPaymentMethod.Controls.Add(panelCash);
            groupBoxPaymentMethod.Controls.Add(lblSelectPayment);
            groupBoxPaymentMethod.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxPaymentMethod.Location = new Point(23, 140);
            groupBoxPaymentMethod.Name = "groupBoxPaymentMethod";
            groupBoxPaymentMethod.Size = new Size(854, 180);
            groupBoxPaymentMethod.TabIndex = 1;
            groupBoxPaymentMethod.TabStop = false;
            groupBoxPaymentMethod.Text = "Payment Method";
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.FromArgb(236, 240, 241);
            panelCard.BorderStyle = BorderStyle.FixedSingle;
            panelCard.Controls.Add(lblCard);
            panelCard.Cursor = Cursors.Hand;
            panelCard.Location = new Point(594, 70);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(240, 90);
            panelCard.TabIndex = 3;
            panelCard.Click += panelCard_Click;
            // 
            // lblCard
            // 
            lblCard.Dock = DockStyle.Fill;
            lblCard.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCard.ForeColor = Color.FromArgb(52, 73, 94);
            lblCard.Location = new Point(0, 0);
            lblCard.Name = "lblCard";
            lblCard.Size = new Size(238, 88);
            lblCard.TabIndex = 0;
            lblCard.Text = "💳 CARD";
            lblCard.TextAlign = ContentAlignment.MiddleCenter;
            lblCard.Click += panelCard_Click;
            // 
            // panelGCash
            // 
            panelGCash.BackColor = Color.FromArgb(236, 240, 241);
            panelGCash.BorderStyle = BorderStyle.FixedSingle;
            panelGCash.Controls.Add(lblGCash);
            panelGCash.Cursor = Cursors.Hand;
            panelGCash.Location = new Point(307, 70);
            panelGCash.Name = "panelGCash";
            panelGCash.Size = new Size(240, 90);
            panelGCash.TabIndex = 2;
            panelGCash.Click += panelGCash_Click;
            // 
            // lblGCash
            // 
            lblGCash.Dock = DockStyle.Fill;
            lblGCash.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblGCash.ForeColor = Color.FromArgb(0, 119, 200);
            lblGCash.Location = new Point(0, 0);
            lblGCash.Name = "lblGCash";
            lblGCash.Size = new Size(238, 88);
            lblGCash.TabIndex = 0;
            lblGCash.Text = "📱 GCash";
            lblGCash.TextAlign = ContentAlignment.MiddleCenter;
            lblGCash.Click += panelGCash_Click;
            // 
            // panelCash
            // 
            panelCash.BackColor = Color.FromArgb(236, 240, 241);
            panelCash.BorderStyle = BorderStyle.FixedSingle;
            panelCash.Controls.Add(lblCash);
            panelCash.Cursor = Cursors.Hand;
            panelCash.Location = new Point(20, 70);
            panelCash.Name = "panelCash";
            panelCash.Size = new Size(240, 90);
            panelCash.TabIndex = 1;
            panelCash.Click += panelCash_Click;
            // 
            // lblCash
            // 
            lblCash.Dock = DockStyle.Fill;
            lblCash.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCash.ForeColor = Color.FromArgb(39, 174, 96);
            lblCash.Location = new Point(0, 0);
            lblCash.Name = "lblCash";
            lblCash.Size = new Size(238, 88);
            lblCash.TabIndex = 0;
            lblCash.Text = "💵 CASH";
            lblCash.TextAlign = ContentAlignment.MiddleCenter;
            lblCash.Click += panelCash_Click;
            // 
            // lblSelectPayment
            // 
            lblSelectPayment.AutoSize = true;
            lblSelectPayment.Font = new Font("Segoe UI", 10F);
            lblSelectPayment.Location = new Point(20, 35);
            lblSelectPayment.Name = "lblSelectPayment";
            lblSelectPayment.Size = new Size(189, 19);
            lblSelectPayment.TabIndex = 0;
            lblSelectPayment.Text = "Select your payment method:";
            // 
            // groupBoxRentalInfo
            // 
            groupBoxRentalInfo.Controls.Add(lblPlateNumberValue);
            groupBoxRentalInfo.Controls.Add(lblPlateNumber);
            groupBoxRentalInfo.Controls.Add(lblCustomerValue);
            groupBoxRentalInfo.Controls.Add(lblCustomer);
            groupBoxRentalInfo.Controls.Add(lblRentalIDValue);
            groupBoxRentalInfo.Controls.Add(lblRentalID);
            groupBoxRentalInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxRentalInfo.Location = new Point(23, 23);
            groupBoxRentalInfo.Name = "groupBoxRentalInfo";
            groupBoxRentalInfo.Size = new Size(854, 100);
            groupBoxRentalInfo.TabIndex = 0;
            groupBoxRentalInfo.TabStop = false;
            groupBoxRentalInfo.Text = "Rental Information";
            // 
            // lblPlateNumberValue
            // 
            lblPlateNumberValue.AutoSize = true;
            lblPlateNumberValue.Font = new Font("Segoe UI", 11F);
            lblPlateNumberValue.Location = new Point(710, 35);
            lblPlateNumberValue.Name = "lblPlateNumberValue";
            lblPlateNumberValue.Size = new Size(67, 20);
            lblPlateNumberValue.TabIndex = 5;
            lblPlateNumberValue.Text = "ABC-123";
            // 
            // lblPlateNumber
            // 
            lblPlateNumber.AutoSize = true;
            lblPlateNumber.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPlateNumber.Location = new Point(580, 36);
            lblPlateNumber.Name = "lblPlateNumber";
            lblPlateNumber.Size = new Size(107, 19);
            lblPlateNumber.TabIndex = 4;
            lblPlateNumber.Text = "Plate Number:";
            // 
            // lblCustomerValue
            // 
            lblCustomerValue.AutoSize = true;
            lblCustomerValue.Font = new Font("Segoe UI", 11F);
            lblCustomerValue.Location = new Point(125, 60);
            lblCustomerValue.Name = "lblCustomerValue";
            lblCustomerValue.Size = new Size(71, 20);
            lblCustomerValue.TabIndex = 3;
            lblCustomerValue.Text = "John Doe";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCustomer.Location = new Point(20, 61);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(78, 19);
            lblCustomer.TabIndex = 2;
            lblCustomer.Text = "Customer:";
            // 
            // lblRentalIDValue
            // 
            lblRentalIDValue.AutoSize = true;
            lblRentalIDValue.Font = new Font("Segoe UI", 11F);
            lblRentalIDValue.Location = new Point(125, 35);
            lblRentalIDValue.Name = "lblRentalIDValue";
            lblRentalIDValue.Size = new Size(25, 20);
            lblRentalIDValue.TabIndex = 1;
            lblRentalIDValue.Text = "01";
            // 
            // lblRentalID
            // 
            lblRentalID.AutoSize = true;
            lblRentalID.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRentalID.Location = new Point(20, 36);
            lblRentalID.Name = "lblRentalID";
            lblRentalID.Size = new Size(73, 19);
            lblRentalID.TabIndex = 0;
            lblRentalID.Text = "Rental ID:";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(229, 540);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 50);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnProcessPayment
            // 
            btnProcessPayment.BackColor = Color.FromArgb(39, 174, 96);
            btnProcessPayment.FlatAppearance.BorderSize = 0;
            btnProcessPayment.FlatStyle = FlatStyle.Flat;
            btnProcessPayment.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnProcessPayment.ForeColor = Color.White;
            btnProcessPayment.Location = new Point(23, 540);
            btnProcessPayment.Name = "btnProcessPayment";
            btnProcessPayment.Size = new Size(200, 50);
            btnProcessPayment.TabIndex = 4;
            btnProcessPayment.Text = "PROCESS PAYMENT";
            btnProcessPayment.UseVisualStyleBackColor = false;
            btnProcessPayment.Click += btnProcessPayment_Click;
            // 
            // PaymentListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 700);
            Controls.Add(panelMain);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PaymentListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Payment";
            Load += PaymentForm_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMain.ResumeLayout(false);
            groupBoxDetails.ResumeLayout(false);
            groupBoxDetails.PerformLayout();
            groupBoxAmount.ResumeLayout(false);
            groupBoxAmount.PerformLayout();
            groupBoxPaymentMethod.ResumeLayout(false);
            groupBoxPaymentMethod.PerformLayout();
            panelCard.ResumeLayout(false);
            panelGCash.ResumeLayout(false);
            panelCash.ResumeLayout(false);
            groupBoxRentalInfo.ResumeLayout(false);
            groupBoxRentalInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBoxRentalInfo;
        private System.Windows.Forms.Label lblRentalID;
        private System.Windows.Forms.Label lblRentalIDValue;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblCustomerValue;
        private System.Windows.Forms.Label lblPlateNumber;
        private System.Windows.Forms.Label lblPlateNumberValue;
        private System.Windows.Forms.GroupBox groupBoxPaymentMethod;
        private System.Windows.Forms.Label lblSelectPayment;
        private System.Windows.Forms.Panel panelCash;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Panel panelGCash;
        private System.Windows.Forms.Label lblGCash;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label lblCard;
        private System.Windows.Forms.GroupBox groupBoxAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalAmountValue;
        private System.Windows.Forms.Label lblAmountPaid;
        private System.Windows.Forms.TextBox txtAmountPaid;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label lblChangeAmount;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.Label lblReferenceNumber;
        private System.Windows.Forms.TextBox txtReferenceNumber;
        private System.Windows.Forms.Button btnProcessPayment;
        private System.Windows.Forms.Button btnCancel;
    }
}