using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CarRental.DAL;
using Microsoft.Data.SqlClient;

namespace CarRental
{
    public partial class CarMaintenanceForm : Form
    {
        private readonly CarMaintenanceDAL _dal;
        private readonly string _connectionString =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=CARRENTALDB;Integrated Security=True;TrustServerCertificate=True";

        private DataTable _fullData;

        public CarMaintenanceForm()
        {
            InitializeComponent();
            _dal = new CarMaintenanceDAL(_connectionString);
        }

        // ─────────────────────────────────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────────────────────────────────
        private void CarMaintenanceForm_Load(object sender, EventArgs e)
        {
            PositionBottomButtons();
            LoadMaintenanceData();
        }

        // ─────────────────────────────────────────────────────────────────────
        // RESIZE — reposition bottom buttons to stay right-aligned
        // ─────────────────────────────────────────────────────────────────────
        private void CarMaintenanceForm_Resize(object sender, EventArgs e)
        {
            PositionBottomButtons();
        }

        private void PositionBottomButtons()
        {
            int right = pnlBottom.Width - 20;
            int btnY = 12;

            btnStartMaintenance.Location = new Point(right - btnStartMaintenance.Width, btnY);
            right -= btnStartMaintenance.Width + 10;

            btnMarkComplete.Location = new Point(right - btnMarkComplete.Width, btnY);
            right -= btnMarkComplete.Width + 10;

            btnCancelRecord.Location = new Point(right - btnCancelRecord.Width, btnY);

            // Refresh stays on the left
            btnRefresh.Location = new Point(20, btnY);
        }

        // ─────────────────────────────────────────────────────────────────────
        // DATA
        // ─────────────────────────────────────────────────────────────────────
        private void LoadMaintenanceData()
        {
            try
            {
                _fullData = _dal.GetAllMaintenances();
                BindGrid(_fullData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindGrid(DataTable dt)
        {
            dgvMaintenance.DataSource = null;
            dgvMaintenance.DataSource = dt;
            StyleGridColumns();
            lblTotal.Text = $"Total Records: {dt.Rows.Count}";
            UpdateButtonStates();
        }

        private void StyleGridColumns()
        {
            if (dgvMaintenance.Columns.Count == 0) return;

            foreach (var col in new[] { "CarID", "CreatedDate", "ModifiedDate" })
                if (dgvMaintenance.Columns.Contains(col))
                    dgvMaintenance.Columns[col].Visible = false;

            var map = new System.Collections.Generic.Dictionary<string, string>
            {
                { "MaintenanceID",   "#"            },
                { "PlateNumber",     "Plate Number" },
                { "CarInfo",         "Car"          },
                { "MaintenanceType", "Type"         },
                { "Description",     "Description"  },
                { "Status",          "Status"       },
                { "ScheduledDate",   "Scheduled"    },
                { "CompletedDate",   "Completed"    },
                { "MechanicName",  "Mechanic"   },
                { "Cost",            "Cost (₱)"     },
                { "Notes",           "Notes"        },
            };
            foreach (var kv in map)
                if (dgvMaintenance.Columns.Contains(kv.Key))
                    dgvMaintenance.Columns[kv.Key].HeaderText = kv.Value;

            void W(string c, int fw)
            {
                if (dgvMaintenance.Columns.Contains(c))
                    dgvMaintenance.Columns[c].FillWeight = fw;
            }
            W("MaintenanceID", 18);
            W("PlateNumber", 65);
            W("CarInfo", 90);
            W("MaintenanceType", 100);
            W("Description", 85);
            W("Status", 65);
            W("ScheduledDate", 70);
            W("CompletedDate", 70);
            W("MechanicName", 80);
            W("Cost", 50);
            W("Notes", 80);
        }

        // ─────────────────────────────────────────────────────────────────────
        // SEARCH
        // ─────────────────────────────────────────────────────────────────────
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_fullData == null) return;
            string q = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(q))
            {
                BindGrid(_fullData);
                return;
            }

            var view = _fullData.DefaultView;
            view.RowFilter =
                $"(CONVERT(PlateNumber,    System.String) LIKE '%{q}%') OR " +
                $"(CONVERT(MaintenanceType,System.String) LIKE '%{q}%') OR " +
                $"(CONVERT(MechanicName, System.String) LIKE '%{q}%') OR " +
                $"(CONVERT(Status,         System.String) LIKE '%{q}%')";
            BindGrid(view.ToTable());
        }

        // ─────────────────────────────────────────────────────────────────────
        // GRID EVENTS
        // ─────────────────────────────────────────────────────────────────────
        private void dgvMaintenance_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void dgvMaintenance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMaintenance.Columns.Count == 0 || e.RowIndex < 0) return;
            if (!dgvMaintenance.Columns.Contains("Status")) return;
            if (e.ColumnIndex != dgvMaintenance.Columns["Status"].Index) return;

            string val = e.Value?.ToString();
            switch (val)
            {
                case "In Progress":
                    e.CellStyle.ForeColor = Color.FromArgb(160, 80, 0);
                    e.CellStyle.BackColor = Color.FromArgb(255, 243, 220);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                    break;
                case "Completed":
                    e.CellStyle.ForeColor = Color.FromArgb(20, 130, 60);
                    e.CellStyle.BackColor = Color.FromArgb(225, 250, 235);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                    break;
                default:
                    e.CellStyle.ForeColor = Color.DimGray;
                    e.CellStyle.Font = new Font("Segoe UI", 9f);
                    break;
            }
        }

        private void UpdateButtonStates()
        {
            bool rowSelected = dgvMaintenance.SelectedRows.Count > 0;
            bool isInProgress = rowSelected &&
                dgvMaintenance.SelectedRows[0].Cells["Status"].Value?.ToString() == "In Progress";

            btnMarkComplete.Enabled = isInProgress;
            btnCancelRecord.Enabled = isInProgress;
        }

        // ─────────────────────────────────────────────────────────────────────
        // BUTTON HANDLERS
        // ─────────────────────────────────────────────────────────────────────
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadMaintenanceData();
        }

        private void btnStartMaintenance_Click(object sender, EventArgs e)
        {
            using (var dlg = new AddMaintenanceDialog(_connectionString))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        int id = _dal.AddMaintenance(dlg.Result);
                        MessageBox.Show(
                            $"Maintenance #{id} started successfully.\nCar status is now 'Under Maintenance'.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMaintenanceData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnMarkComplete_Click(object sender, EventArgs e)
        {
            if (dgvMaintenance.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvMaintenance.SelectedRows[0].Cells["MaintenanceID"].Value);

            using (var dlg = new CompletionDialog())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        if (_dal.CompleteMaintenance(id, dlg.Notes, dlg.FinalCost))
                        {
                            MessageBox.Show("Maintenance completed.\nCar is now Available.",
                                "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadMaintenanceData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancelRecord_Click(object sender, EventArgs e)
        {
            if (dgvMaintenance.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvMaintenance.SelectedRows[0].Cells["MaintenanceID"].Value);
            string plate = dgvMaintenance.SelectedRows[0].Cells["PlateNumber"].Value?.ToString();
            string type = dgvMaintenance.SelectedRows[0].Cells["MaintenanceType"].Value?.ToString();

            if (MessageBox.Show(
                    $"Cancel maintenance for {plate} ({type})?\n\nIf no other active maintenance exists, the car will return to Available.",
                    "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _dal.CancelMaintenance(id);
                    LoadMaintenanceData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    // =========================================================================
    // ADD MAINTENANCE DIALOG  — tall enough, no cut-off
    // =========================================================================
    public class AddMaintenanceDialog : Form
    {
        public CarMaintenance Result { get; private set; }

        private readonly string _cs;
        private ComboBox cmbCar, cmbType;
        private TextBox txtDesc, txtTech, txtCost, txtNotes;
        private DateTimePicker dtp;
        private Label lblStatus, lblActiveTypes;

        public AddMaintenanceDialog(string connectionString)
        {
            _cs = connectionString;
            BuildUI();
            LoadCars();
        }

        private void BuildUI()
        {
            this.Text = "New Maintenance Record";
            this.Size = new Size(500, 620);    // tall enough
            this.MinimumSize = new Size(500, 620);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9.5f);

            // Header bar
            var pnlH = new Panel { Dock = DockStyle.Top, Height = 48, BackColor = Color.FromArgb(0, 102, 204) };
            pnlH.Controls.Add(new Label
            {
                Text = "  ➕  New Maintenance Record",
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11.5f, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            });
            this.Controls.Add(pnlH);

            // Scrollable body
            var body = new Panel
            {
                Location = new Point(0, 48),
                Size = new Size(500, 510),
                AutoScroll = true,
                BackColor = Color.White
            };
            this.Controls.Add(body);

            int y = 18;
            int lx = 20;
            int cx = 160;
            int fw = 295;

            // Helper: add label + control row
            void Row(string label, Control ctrl, int h = 28)
            {
                body.Controls.Add(new Label
                {
                    Text = label,
                    Left = lx,
                    Top = y + 3,
                    Width = 135,
                    Height = 22,
                    Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(55, 65, 80)
                });
                ctrl.Left = cx;
                ctrl.Top = y;
                ctrl.Width = fw;
                if (ctrl.Height < h) ctrl.Height = h;
                body.Controls.Add(ctrl);
                y += ctrl.Height + 10;
            }

            // Car
            cmbCar = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            cmbCar.SelectedIndexChanged += CmbCar_Changed;
            Row("Select Car:", cmbCar);

            // Info box
            var infoBox = new Panel
            {
                Left = cx,
                Top = y,
                Width = fw,
                Height = 44,
                BackColor = Color.FromArgb(245, 249, 255)
            };
            infoBox.Paint += (s, e) =>
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(200, 215, 235)), 0, 0, infoBox.Width - 1, infoBox.Height - 1);
            lblStatus = new Label
            {
                Left = 8,
                Top = 4,
                Width = fw - 16,
                Height = 17,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                ForeColor = Color.DimGray,
                Text = "Status: —"
            };
            lblActiveTypes = new Label
            {
                Left = 8,
                Top = 23,
                Width = fw - 16,
                Height = 16,
                Font = new Font("Segoe UI", 8f),
                ForeColor = Color.DimGray,
                Text = "Active maintenance: None"
            };
            infoBox.Controls.AddRange(new Control[] { lblStatus, lblActiveTypes });
            body.Controls.Add(new Label
            {
                Text = "Car Info:",
                Left = lx,
                Top = y + 10,
                Width = 135,
                Height = 22,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(55, 65, 80)
            });
            body.Controls.Add(infoBox);
            y += 54;

            // Separator
            body.Controls.Add(new Panel { Left = lx, Top = y, Width = cx + fw - lx, Height = 1, BackColor = Color.FromArgb(220, 228, 240) });
            y += 12;

            // Maintenance Type
            cmbType = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            cmbType.Items.AddRange(CarMaintenanceDAL.MaintenanceTypes);
            cmbType.SelectedIndex = 0;
            Row("Maintenance Type:", cmbType);

            // Description
            txtDesc = new TextBox { Multiline = true, ScrollBars = ScrollBars.Vertical, BorderStyle = BorderStyle.FixedSingle };
            Row("Description:", txtDesc, 55);

            // Scheduled Date
            dtp = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = DateTime.Today };
            Row("Scheduled Date:", dtp);

            // Mechanic
            txtTech = new TextBox { BorderStyle = BorderStyle.FixedSingle };
            Row("Mechanic:", txtTech);

            // Cost
            txtCost = new TextBox { Text = "0", BorderStyle = BorderStyle.FixedSingle };
            Row("Est. Cost (₱):", txtCost);

            // Notes
            txtNotes = new TextBox { Multiline = true, ScrollBars = ScrollBars.Vertical, BorderStyle = BorderStyle.FixedSingle };
            Row("Notes:", txtNotes, 55);

            y += 6;

            // Start button
            var btnOk = new Button
            {
                Text = "➕  Start Maintenance",
                Left = cx,
                Top = y,
                Width = fw,
                Height = 40,
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.OK
            };
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.Click += BtnOk_Click;
            body.Controls.Add(btnOk);
            y += 48;

            // Cancel button
            var btnCancel = new Button
            {
                Text = "Cancel",
                Left = cx,
                Top = y,
                Width = fw,
                Height = 32,
                BackColor = Color.FromArgb(225, 228, 235),
                ForeColor = Color.FromArgb(60, 70, 90),
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.Cancel
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            body.Controls.Add(btnCancel);

            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }

        private void LoadCars()
        {
            try
            {
                using (var conn = new SqlConnection(_cs))
                using (var adapter = new SqlDataAdapter(
                    "SELECT CarID, PlateNumber + '  —  ' + CarMaker + ' ' + CarModel + ' (' + CAST(CarYear AS NVARCHAR) + ')' AS CarDisplay, Status " +
                    "FROM Cars WHERE IsArchived = 0 OR IsArchived IS NULL ORDER BY CarMaker, CarModel", conn))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    cmbCar.DataSource = dt;
                    cmbCar.DisplayMember = "CarDisplay";
                    cmbCar.ValueMember = "CarID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cars: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbCar_Changed(object sender, EventArgs e)
        {
            if (cmbCar.SelectedValue == null) return;
            if (!int.TryParse(cmbCar.SelectedValue.ToString(), out int carID)) return;
            try
            {
                var dt = (DataTable)cmbCar.DataSource;
                var row = dt.Select($"CarID = {carID}");
                if (row.Length > 0)
                {
                    string st = row[0]["Status"].ToString();
                    lblStatus.Text = "Status:  " + st;
                    lblStatus.ForeColor = st == "Under Maintenance" ? Color.FromArgb(180, 50, 50) :
                                          st == "Available" ? Color.FromArgb(20, 140, 60) : Color.DimGray;
                }

                using (var conn = new SqlConnection(_cs))
                using (var cmd = new SqlCommand(
                    "SELECT MaintenanceType FROM CarMaintenance WHERE CarID=@id AND Status='In Progress'", conn))
                {
                    cmd.Parameters.AddWithValue("@id", carID);
                    conn.Open();
                    var types = new System.Collections.Generic.List<string>();
                    using (var r = cmd.ExecuteReader())
                        while (r.Read()) types.Add(r.GetString(0));
                    lblActiveTypes.Text = types.Count > 0 ? "Active: " + string.Join(", ", types) : "Active maintenance: None";
                    lblActiveTypes.ForeColor = types.Count > 0 ? Color.FromArgb(180, 80, 0) : Color.DimGray;
                }
            }
            catch { }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (cmbCar.SelectedValue == null)
            {
                MessageBox.Show("Please select a car.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
            if (!int.TryParse(cmbCar.SelectedValue.ToString(), out int carID))
            { this.DialogResult = DialogResult.None; return; }

            decimal.TryParse(txtCost.Text, out decimal cost);

            Result = new CarMaintenance
            {
                CarID = carID,
                MaintenanceType = cmbType.SelectedItem?.ToString(),
                Description = txtDesc.Text.Trim(),
                ScheduledDate = dtp.Value,
                MechanicName = txtTech.Text.Trim(),
                Cost = cost,
                Notes = txtNotes.Text.Trim()
            };
        }
    }

    // =========================================================================
    // COMPLETION DIALOG
    // =========================================================================
    public class CompletionDialog : Form
    {
        public string Notes { get; private set; }
        public decimal FinalCost { get; private set; }

        public CompletionDialog()
        {
            this.Text = "Complete Maintenance";
            this.Size = new Size(440, 280);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9.5f);

            // Header
            var pnlH = new Panel { Dock = DockStyle.Top, Height = 48, BackColor = Color.FromArgb(39, 174, 96) };
            pnlH.Controls.Add(new Label
            {
                Text = "  ✔  Complete Maintenance Record",
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            });
            this.Controls.Add(pnlH);

            int y = 62;
            int lx = 20;
            int cx = 160;
            int fw = 250;

            this.Controls.Add(new Label { Text = "Completion Notes:", Left = lx, Top = y + 2, Width = 135, Height = 22, Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(55, 65, 80) });
            var txtN = new TextBox { Left = cx, Top = y, Width = fw, Height = 58, Multiline = true, BorderStyle = BorderStyle.FixedSingle };
            this.Controls.Add(txtN);
            y += 68;

            this.Controls.Add(new Label { Text = "Final Cost (₱):", Left = lx, Top = y + 2, Width = 135, Height = 22, Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(55, 65, 80) });
            var txtC = new TextBox { Left = cx, Top = y, Width = 120, Text = "0", BorderStyle = BorderStyle.FixedSingle };
            this.Controls.Add(txtC);
            y += 40;

            var btnOk = new Button
            {
                Text = "✔  Mark Complete",
                Left = cx,
                Top = y,
                Width = 150,
                Height = 36,
                BackColor = Color.FromArgb(39, 174, 96),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                DialogResult = DialogResult.OK
            };
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.Click += (s, e) =>
            {
                Notes = txtN.Text.Trim();
                decimal.TryParse(txtC.Text, out decimal c);
                FinalCost = c;
            };

            var btnCx = new Button
            {
                Text = "Cancel",
                Left = cx + 158,
                Top = y,
                Width = 92,
                Height = 36,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(225, 228, 235),
                DialogResult = DialogResult.Cancel
            };
            btnCx.FlatAppearance.BorderSize = 0;

            this.Controls.AddRange(new Control[] { btnOk, btnCx });
            this.AcceptButton = btnOk;
            this.CancelButton = btnCx;
        }
    }
}