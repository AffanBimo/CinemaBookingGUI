using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CinemaBookingGUI
{
    public partial class Form1 : Form
    {
        private List<Movie> movies = new List<Movie>();
        private List<CinemaHall> halls = new List<CinemaHall>();
        private List<Showtime> showtimes = new List<Showtime>();
        private List<Booking> bookings = new List<Booking>();
        private List<Seat> selectedSeats = new List<Seat>();

        public Form1()
        {
            InitializeComponent();
            SeedInitialData();
            LoadShowtimesToComboBox();
        }

        private void SeedInitialData()
        {
            // 1. Setup 7 Movies
            Movie m1 = new Movie("M01", "Interstellar", "Sci-Fi", 169);
            Movie m2 = new Movie("M02", "Dune: Part Two", "Action/Sci-Fi", 166);
            Movie m3 = new Movie("M03", "Oppenheimer", "Biography/Drama", 180);
            Movie m4 = new Movie("M04", "Spider-Man: Across the Spider-Verse", "Animation/Action", 140);
            Movie m5 = new Movie("M05", "The Batman", "Action/Crime", 176);
            Movie m6 = new Movie("M06", "Inception", "Sci-Fi/Thriller", 148);
            Movie m7 = new Movie("M07", "Avengers: Endgame", "Action/Sci-Fi", 181);

            movies.AddRange(new[] { m1, m2, m3, m4, m5, m6, m7 });

            // 2. Setup Halls & Generate Seats 
            CinemaHall h1 = new CinemaHall("H01", "IMAX Hall 1", 10);
            CinemaHall h2 = new CinemaHall("H02", "Regular Hall 2", 10);
            CinemaHall h3 = new CinemaHall("H03", "Dolby Atmos Hall 3", 10);
            CinemaHall h4 = new CinemaHall("H04", "Hall 4", 10);

            GenerateSeatsForHall(h1, "S1");
            GenerateSeatsForHall(h2, "S2");
            GenerateSeatsForHall(h3, "S3");
            GenerateSeatsForHall(h4, "S4");

            halls.AddRange(new[] { h1, h2, h3, h4 });

            // 3. Setup Showtimes 
            showtimes.Add(new Showtime("ST01", new DateTime(2026, 11, 20, 19, 30, 0), m1, h1)); // Weekday (RM 20)
            showtimes.Add(new Showtime("ST02", new DateTime(2026, 11, 21, 21, 00, 0), m2, h2)); // Weekend (RM 25)
            showtimes.Add(new Showtime("ST03", new DateTime(2026, 11, 22, 16, 15, 0), m3, h3)); // Weekend (RM 25)
            showtimes.Add(new Showtime("ST04", new DateTime(2026, 11, 23, 14, 00, 0), m4, h4)); // Weekday (RM 20)
            showtimes.Add(new Showtime("ST05", new DateTime(2026, 11, 24, 20, 45, 0), m5, h1)); // Weekday (RM 20)
            showtimes.Add(new Showtime("ST06", new DateTime(2026, 11, 25, 18, 30, 0), m6, h2)); // Weekday (RM 20)
            showtimes.Add(new Showtime("ST07", new DateTime(2026, 11, 28, 21, 30, 0), m7, h3)); // Weekend (RM 25)
        }

        private void GenerateSeatsForHall(CinemaHall hall, string prefix)
        {
            string[] rows = { "A", "B" };
            int count = 1;
            foreach (string row in rows)
            {
                for (int col = 1; col <= 5; col++)
                {
                    hall.Seats.Add(new Seat($"{prefix}-{count:D2}", $"{row}{col}"));
                    count++;
                }
            }
        }

        private void LoadShowtimesToComboBox()
        {
            cmbShowtime.Items.Clear();
            foreach (var st in showtimes)
            {
                cmbShowtime.Items.Add($"{st.ShowtimeID} - {st.Movie.Title} ({st.StartTime:dd MMM HH:mm}) - {st.Hall.HallName}");
            }
            if (cmbShowtime.Items.Count > 0)
                cmbShowtime.SelectedIndex = 0;
        }

        private void cmbShowtime_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSeats.Clear();
            RenderSeatMap();
        }

        private void RenderSeatMap()
        {
            pnlSeatMap.Controls.Clear();
            if (cmbShowtime.SelectedIndex < 0) return;

            Showtime currentShowtime = showtimes[cmbShowtime.SelectedIndex];

            foreach (Seat seat in currentShowtime.Hall.Seats)
            {
                Button btnSeat = new Button
                {
                    Text = seat.SeatNumber,
                    Width = 65,
                    Height = 45,
                    Margin = new Padding(5),
                    Tag = seat
                };

                if (!seat.CheckAvailability())
                {
                    btnSeat.BackColor = Color.IndianRed;
                    btnSeat.Enabled = false;
                }
                else if (selectedSeats.Contains(seat))
                {
                    btnSeat.BackColor = Color.Gold;
                }
                else
                {
                    btnSeat.BackColor = Color.LightGreen;
                }

                btnSeat.Click += BtnSeat_Click;
                pnlSeatMap.Controls.Add(btnSeat);
            }
        }

        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button clickedBtn = sender as Button;
            Seat seat = clickedBtn.Tag as Seat;

            if (selectedSeats.Contains(seat))
            {
                selectedSeats.Remove(seat);
                clickedBtn.BackColor = Color.LightGreen;
            }
            else
            {
                selectedSeats.Add(seat);
                clickedBtn.BackColor = Color.Gold;
            }
        }

        private void btnConfirmBooking_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) || string.IsNullOrWhiteSpace(txtCustomerEmail.Text))
            {
                MessageBox.Show("Please enter both Customer Name and Email.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Please select at least one seat.", "No Seat Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Showtime chosenShowtime = showtimes[cmbShowtime.SelectedIndex];
            string custId = $"C{bookings.Count + 1:D2}";
            Customer customer = new Customer(custId, txtCustomerName.Text.Trim(), txtCustomerEmail.Text.Trim());

            string bookingId = $"B{bookings.Count + 1:D2}";
            Booking newBooking = new Booking(bookingId, customer);

            foreach (Seat seat in selectedSeats)
            {
                string ticketId = $"T{bookings.Count + 1}-{newBooking.Tickets.Count + 1}";
                Ticket ticket = new Ticket(ticketId, chosenShowtime, seat);
                newBooking.AddTicket(ticket);
            }

            newBooking.ConfirmBooking();
            bookings.Add(newBooking);

            lstBookingHistory.Items.Add($"[{bookingId}] {customer.Name} | {chosenShowtime.Movie.Title} | Seats: {selectedSeats.Count} | Total: RM {newBooking.TotalAmount:F2}");

            MessageBox.Show($"Booking {bookingId} Confirmed!\nTotal Amount: RM {newBooking.TotalAmount:F2}", "Booking Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            selectedSeats.Clear();
            txtCustomerName.Clear();
            txtCustomerEmail.Clear();
            RenderSeatMap();
        }
    }
}