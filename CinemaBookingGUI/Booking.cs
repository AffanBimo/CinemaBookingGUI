using System;
using System.Collections.Generic;

namespace CinemaBookingGUI
{
    public class Booking
    {
        public string BookingID { get; set; }
        public Customer Customer { get; set; }
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
        public double TotalAmount { get; private set; }
        public bool IsConfirmed { get; private set; }

        public Booking(string bookingId, Customer customer)
        {
            BookingID = bookingId;
            Customer = customer;
            IsConfirmed = false;
        }

        public void AddTicket(Ticket ticket)
        {
            if (ticket.Seat.BookSeat())
            {
                Tickets.Add(ticket);
                CalculateTotal();
            }
        }

        public void CalculateTotal()
        {
            TotalAmount = 0;
            foreach (var ticket in Tickets)
            {
                TotalAmount += ticket.Price;
            }
        }

        public void ConfirmBooking()
        {
            if (Tickets.Count == 0) return;
            CalculateTotal();
            IsConfirmed = true;
        }
    }
}