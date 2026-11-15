using System;

namespace CinemaBookingGUI
{
    public class Showtime
    {
        public string ShowtimeID { get; set; }
        public DateTime StartTime { get; set; }
        public Movie Movie { get; set; }
        public CinemaHall Hall { get; set; }

        public Showtime(string showtimeId, DateTime startTime, Movie movie, CinemaHall hall)
            => (ShowtimeID, StartTime, Movie, Hall) = (showtimeId, startTime, movie, hall);

        public void DisplayShowtimeDetails()
        {
            Console.WriteLine($"Showtime [{ShowtimeID}]: {Movie.Title} | {StartTime:dd MMM yyyy HH:mm} | {Hall.HallName}");
        }
    }
}