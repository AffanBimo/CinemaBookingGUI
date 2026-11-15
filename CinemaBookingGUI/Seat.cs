using System;

namespace CinemaBookingGUI
{
    public class Seat
    {
        public string SeatID { get; set; }
        public string SeatNumber { get; set; }
        public bool IsBooked { get; private set; }

        public Seat(string seatId, string seatNumber)
        {
            SeatID = seatId;
            SeatNumber = seatNumber;
            IsBooked = false;
        }

        public bool CheckAvailability()
        {
            return !IsBooked;
        }

        public bool BookSeat()
        {
            if (IsBooked) return false;
            IsBooked = true;
            return true;
        }
    }
}