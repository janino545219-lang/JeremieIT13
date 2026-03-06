namespace CarRental.Views.Shared
{
    partial class TermsConditionsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            chkAgree = new System.Windows.Forms.CheckBox();
            btnAgree = new System.Windows.Forms.Button();
            btnDecline = new System.Windows.Forms.Button();
            lblTitle = new System.Windows.Forms.Label();
            panelTop = new System.Windows.Forms.Panel();
            panelBottom = new System.Windows.Forms.Panel();
            panelTop.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();

            // panelTop
            panelTop.BackColor = System.Drawing.Color.FromArgb(41, 44, 51);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Size = new System.Drawing.Size(800, 60);

            // lblTitle
            lblTitle.AutoSize = false;
            lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Text = "📋  Terms and Conditions";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // richTextBox1
            richTextBox1.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            richTextBox1.Font = new System.Drawing.Font("Courier New", 9.5F);
            richTextBox1.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            richTextBox1.Padding = new System.Windows.Forms.Padding(10);
            richTextBox1.TabStop = false;

            // panelBottom
            panelBottom.BackColor = System.Drawing.Color.FromArgb(41, 44, 51);
            panelBottom.Controls.Add(btnDecline);
            panelBottom.Controls.Add(btnAgree);
            panelBottom.Controls.Add(chkAgree);
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Size = new System.Drawing.Size(800, 65);
            panelBottom.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);

            // chkAgree
            chkAgree.AutoSize = true;
            chkAgree.Font = new System.Drawing.Font("Segoe UI", 10F);
            chkAgree.ForeColor = System.Drawing.Color.White;
            chkAgree.Location = new System.Drawing.Point(20, 20);
            chkAgree.Text = "I have read and agree to all Terms and Conditions";
            chkAgree.CheckedChanged += chkAgree_CheckedChanged;

            // btnAgree
            btnAgree.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            btnAgree.Enabled = false;
            btnAgree.FlatAppearance.BorderSize = 0;
            btnAgree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAgree.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnAgree.ForeColor = System.Drawing.Color.White;
            btnAgree.Size = new System.Drawing.Size(130, 38);
            btnAgree.Location = new System.Drawing.Point(530, 13);
            btnAgree.Text = "✔  I Agree";
            btnAgree.Click += btnAgree_Click;

            // btnDecline
            btnDecline.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            btnDecline.FlatAppearance.BorderSize = 0;
            btnDecline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDecline.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnDecline.ForeColor = System.Drawing.Color.White;
            btnDecline.Size = new System.Drawing.Size(130, 38);
            btnDecline.Location = new System.Drawing.Point(670, 13);
            btnDecline.Text = "✘  Decline";
            btnDecline.Click += btnDecline_Click;

            // TermsConditionsForm
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 600);
            Controls.Add(richTextBox1);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            MinimumSize = new System.Drawing.Size(800, 600);
            Name = "TermsConditionsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Terms and Conditions - Car Rental System";
            BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            panelTop.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox chkAgree;
        private System.Windows.Forms.Button btnAgree;
        private System.Windows.Forms.Button btnDecline;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
    }
}