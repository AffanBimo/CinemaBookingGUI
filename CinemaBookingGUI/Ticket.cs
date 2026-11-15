using System;

namespace CinemaBookingGUI
{
    public class Ticket
    {
        public string TicketID { get; set; }
        public double Price { get; private set; }
        public Showtime Showtime { get; set; }
        public Seat Seat { get; set; }

        public Ticket(string ticketId, Showtime showtime, Seat seat, double basePrice = 20.0)
        {
            TicketID = ticketId;
            Showtime = showtime;
            Seat = seat;
            CalculatePrice(basePrice);
        }

        public void CalculatePrice(double basePrice = 20.0)
        {
            if (Showtime.StartTime.DayOfWeek == DayOfWeek.Saturday ||
                Showtime.StartTime.DayOfWeek == DayOfWeek.Sunday)
            {
                Price = basePrice + 5.0;
            }
            else
            {
                Price = basePrice;
            }
        }

        public void DisplayTicketDetails()
        {
            Console.WriteLine($"Ticket [{TicketID}] | Movie: {Showtime.Movie.Title} | Seat: {Seat.SeatNumber} | Price: RM {Price:F2}");
        }
    }
}