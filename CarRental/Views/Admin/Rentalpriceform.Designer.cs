namespace CarRental
{
    partial class RentalPriceForm
    {
        private System.ComponentModel.IContainer components = null;

        // Controls
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvCars;
        private System.Windows.Forms.GroupBox grpEditPrice;
        private System.Windows.Forms.Label lblPlate;
        private System.Windows.Forms.TextBox txtPlateNumber;
        private System.Windows.Forms.Label lblMaker;
        private System.Windows.Forms.TextBox txtMaker;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblNewPrice;
        private System.Windows.Forms.TextBox txtNewPrice;
        private System.Windows.Forms.Button btnSavePrice;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblHint;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvCars = new System.Windows.Forms.DataGridView();
            this.grpEditPrice = new System.Windows.Forms.GroupBox();
            this.lblPlate = new System.Windows.Forms.Label();
            this.txtPlateNumber = new System.Windows.Forms.TextBox();
            this.lblMaker = new System.Windows.Forms.Label();
            this.txtMaker = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblNewPrice = new System.Windows.Forms.Label();
            this.txtNewPrice = new System.Windows.Forms.TextBox();
            this.btnSavePrice = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).BeginInit();
            this.grpEditPrice.SuspendLayout();
            this.SuspendLayout();

            // ── Form ────────────────────────────────────────────────────────────
            this.Text = "Rental Price Management";
            this.Size = new System.Drawing.Size(900, 620);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Load += new System.EventHandler(this.RentalPriceForm_Load);

            // ── Title ───────────────────────────────────────────────────────────
            this.lblTitle.Text = "Rental Price Management";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 80);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(400, 35);

            // ── Search label ────────────────────────────────────────────────────
            this.lblSearch.Text = "Search:";
            this.lblSearch.Location = new System.Drawing.Point(20, 65);
            this.lblSearch.Size = new System.Drawing.Size(55, 22);

            // ── Search textbox ──────────────────────────────────────────────────
            this.txtSearch.Location = new System.Drawing.Point(80, 62);
            this.txtSearch.Size = new System.Drawing.Size(300, 22);
            this.txtSearch.PlaceholderText = "Search by plate, maker, or model...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // ── Refresh button ──────────────────────────────────────────────────
            this.btnRefresh.Text = "⟳  Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(400, 59);
            this.btnRefresh.Size = new System.Drawing.Size(100, 28);
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── Hint label ──────────────────────────────────────────────────────
            this.lblHint.Text = "💡 Tip: Click a row to edit its price, or double-click the Daily Price cell to edit inline.";
            this.lblHint.ForeColor = System.Drawing.Color.Gray;
            this.lblHint.Location = new System.Drawing.Point(20, 95);
            this.lblHint.Size = new System.Drawing.Size(650, 18);

            // ── DataGridView ────────────────────────────────────────────────────
            this.dgvCars.Location = new System.Drawing.Point(20, 120);
            this.dgvCars.Size = new System.Drawing.Size(620, 420);
            this.dgvCars.AllowUserToAddRows = false;
            this.dgvCars.AllowUserToDeleteRows = false;
            this.dgvCars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCars.MultiSelect = false;
            this.dgvCars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvCars.RowHeadersVisible = false;
            this.dgvCars.BackgroundColor = System.Drawing.Color.White;
            this.dgvCars.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCars.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 100, 200);
            this.dgvCars.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCars.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvCars.EnableHeadersVisualStyles = false;
            this.dgvCars.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvCars.SelectionChanged += new System.EventHandler(this.dgvCars_SelectionChanged);
            this.dgvCars.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCars_CellEndEdit);

            // ── GroupBox: Edit Price Panel ──────────────────────────────────────
            this.grpEditPrice.Text = "Edit Daily Price";
            this.grpEditPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpEditPrice.Location = new System.Drawing.Point(660, 120);
            this.grpEditPrice.Size = new System.Drawing.Size(210, 300);
            this.grpEditPrice.BackColor = System.Drawing.Color.White;

            int lx = 10, tx = 10, ty = 28, gap = 50;

            // Plate Number
            this.lblPlate.Text = "Plate Number:";
            this.lblPlate.Location = new System.Drawing.Point(lx, ty);
            this.lblPlate.Size = new System.Drawing.Size(190, 16);
            ty += 18;
            this.txtPlateNumber.Location = new System.Drawing.Point(tx, ty);
            this.txtPlateNumber.Size = new System.Drawing.Size(190, 22);
            this.txtPlateNumber.ReadOnly = true;
            this.txtPlateNumber.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            ty += gap - 4;

            // Maker
            this.lblMaker.Text = "Maker:";
            this.lblMaker.Location = new System.Drawing.Point(lx, ty);
            this.lblMaker.Size = new System.Drawing.Size(190, 16);
            ty += 18;
            this.txtMaker.Location = new System.Drawing.Point(tx, ty);
            this.txtMaker.Size = new System.Drawing.Size(190, 22);
            this.txtMaker.ReadOnly = true;
            this.txtMaker.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            ty += gap - 4;

            // Model
            this.lblModel.Text = "Model:";
            this.lblModel.Location = new System.Drawing.Point(lx, ty);
            this.lblModel.Size = new System.Drawing.Size(190, 16);
            ty += 18;
            this.txtModel.Location = new System.Drawing.Point(tx, ty);
            this.txtModel.Size = new System.Drawing.Size(190, 22);
            this.txtModel.ReadOnly = true;
            this.txtModel.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            ty += gap - 4;

            // Year
            this.lblYear.Text = "Year:";
            this.lblYear.Location = new System.Drawing.Point(lx, ty);
            this.lblYear.Size = new System.Drawing.Size(190, 16);
            ty += 18;
            this.txtYear.Location = new System.Drawing.Point(tx, ty);
            this.txtYear.Size = new System.Drawing.Size(190, 22);
            this.txtYear.ReadOnly = true;
            this.txtYear.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            ty += gap - 4;

            // New Price
            this.lblNewPrice.Text = "New Daily Price ($):";
            this.lblNewPrice.ForeColor = System.Drawing.Color.FromArgb(30, 100, 200);
            this.lblNewPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNewPrice.Location = new System.Drawing.Point(lx, ty);
            this.lblNewPrice.Size = new System.Drawing.Size(190, 16);
            ty += 18;
            this.txtNewPrice.Location = new System.Drawing.Point(tx, ty);
            this.txtNewPrice.Size = new System.Drawing.Size(190, 22);
            this.txtNewPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.grpEditPrice.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblPlate, txtPlateNumber,
                lblMaker, txtMaker,
                lblModel, txtModel,
                lblYear,  txtYear,
                lblNewPrice, txtNewPrice
            });

            // ── Save Price Button ───────────────────────────────────────────────
            this.btnSavePrice.Text = "💾  Save Price";
            this.btnSavePrice.Location = new System.Drawing.Point(660, 435);
            this.btnSavePrice.Size = new System.Drawing.Size(210, 40);
            this.btnSavePrice.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
            this.btnSavePrice.ForeColor = System.Drawing.Color.White;
            this.btnSavePrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSavePrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePrice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSavePrice.Click += new System.EventHandler(this.btnSavePrice_Click);

            // ── Add all to Form ─────────────────────────────────────────────────
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblTitle, lblSearch, txtSearch, btnRefresh, lblHint,
                dgvCars, grpEditPrice, btnSavePrice
            });

            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).EndInit();
            this.grpEditPrice.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}