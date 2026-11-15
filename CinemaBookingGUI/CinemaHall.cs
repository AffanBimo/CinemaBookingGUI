using System;
using System.Collections.Generic;

namespace CinemaBookingGUI
{
    public class CinemaHall
    {
        public string HallID { get; set; }
        public string HallName { get; set; }
        public int Capacity { get; set; }
        public List<Seat> Seats { get; set; } = new List<Seat>();

        public CinemaHall(string hallId, string hallName, int capacity)
        {
            HallID = hallId;
            HallName = hallName;
            Capacity = capacity;
        }

        public void DisplayHallDetails()
        {
            Console.WriteLine($"Hall [{HallID}]: {HallName} (Capacity: {Capacity} seats)");
        }
    }
}