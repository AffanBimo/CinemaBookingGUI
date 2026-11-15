namespace CinemaBookingGUI
{
    partial class Form1
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
            lblTitle = new Label();
            lblShowtime = new Label();
            cmbShowtime = new ComboBox();
            lblName = new Label();
            txtCustomerName = new TextBox();
            lblEmail = new Label();
            txtCustomerEmail = new TextBox();
            lblScreen = new Label();
            pnlSeatMap = new FlowLayoutPanel();
            btnConfirmBooking = new Button();
            lblHistory = new Label();
            lstBookingHistory = new ListBox();
            SuspendLayout();

            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(25, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(275, 25);
            lblTitle.Text = "CINEMA BOOKING SYSTEM";

            lblShowtime.AutoSize = true;
            lblShowtime.Location = new Point(25, 60);
            lblShowtime.Name = "lblShowtime";
            lblShowtime.Size = new Size(105, 15);
            lblShowtime.Text = "Select Showtime:";

            cmbShowtime.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbShowtime.FormattingEnabled = true;
            cmbShowtime.Location = new Point(25, 80);
            cmbShowtime.Name = "cmbShowtime";
            cmbShowtime.Size = new Size(380, 23);
            cmbShowtime.TabIndex = 0;
            cmbShowtime.SelectedIndexChanged += cmbShowtime_SelectedIndexChanged;

            lblName.AutoSize = true;
            lblName.Location = new Point(25, 118);
            lblName.Name = "lblName";
            lblName.Size = new Size(96, 15);
            lblName.Text = "Customer Name:";

            txtCustomerName.Location = new Point(25, 138);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(180, 23);
            txtCustomerName.TabIndex = 1;

            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(225, 118);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(94, 15);
            lblEmail.Text = "Customer Email:";

            txtCustomerEmail.Location = new Point(225, 138);
            txtCustomerEmail.Name = "txtCustomerEmail";
            txtCustomerEmail.Size = new Size(180, 23);
            txtCustomerEmail.TabIndex = 2;

            lblScreen.BackColor = Color.DimGray;
            lblScreen.ForeColor = Color.White;
            lblScreen.Location = new Point(25, 180);
            lblScreen.Name = "lblScreen";
            lblScreen.Size = new Size(380, 24);
            lblScreen.Text = "[ CINEMA SCREEN ]";
            lblScreen.TextAlign = ContentAlignment.MiddleCenter;

            pnlSeatMap.BorderStyle = BorderStyle.FixedSingle;
            pnlSeatMap.Location = new Point(25, 210);
            pnlSeatMap.Name = "pnlSeatMap";
            pnlSeatMap.Padding = new Padding(5);
            pnlSeatMap.Size = new Size(380, 125);
            pnlSeatMap.TabIndex = 3;

            btnConfirmBooking.BackColor = Color.SteelBlue;
            btnConfirmBooking.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            btnConfirmBooking.ForeColor = Color.White;
            btnConfirmBooking.Location = new Point(25, 348);
            btnConfirmBooking.Name = "btnConfirmBooking";
            btnConfirmBooking.Size = new Size(380, 38);
            btnConfirmBooking.TabIndex = 4;
            btnConfirmBooking.Text = "Confirm Booking";
            btnConfirmBooking.UseVisualStyleBackColor = false;
            btnConfirmBooking.Click += btnConfirmBooking_Click;

            lblHistory.AutoSize = true;
            lblHistory.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            lblHistory.Location = new Point(430, 60);
            lblHistory.Name = "lblHistory";
            lblHistory.Size = new Size(118, 19);
            lblHistory.Text = "Booking History:";

            lstBookingHistory.FormattingEnabled = true;
            lstBookingHistory.ItemHeight = 15;
            lstBookingHistory.Location = new Point(430, 82);
            lstBookingHistory.Name = "lstBookingHistory";
            lstBookingHistory.Size = new Size(410, 304);
            lstBookingHistory.TabIndex = 5;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 410);
            Controls.Add(lstBookingHistory);
            Controls.Add(lblHistory);
            Controls.Add(btnConfirmBooking);
            Controls.Add(pnlSeatMap);
            Controls.Add(lblScreen);
            Controls.Add(txtCustomerEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtCustomerName);
            Controls.Add(lblName);
            Controls.Add(cmbShowtime);
            Controls.Add(lblShowtime);
            Controls.Add(lblTitle);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cinema Booking System - OOP Project";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblShowtime;
        private ComboBox cmbShowtime;
        private Label lblName;
        private TextBox txtCustomerName;
        private Label lblEmail;
        private TextBox txtCustomerEmail;
        private Label lblScreen;
        private FlowLayoutPanel pnlSeatMap;
        private Button btnConfirmBooking;
        private Label lblHistory;
        private ListBox lstBookingHistory;
    }
}