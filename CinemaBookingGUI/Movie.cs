using System;

namespace CinemaBookingGUI
{
    public class Movie
    {
        public string MovieID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }

        public Movie(string movieId, string title, string genre, int duration)
        {
            MovieID = movieId;
            Title = title;
            Genre = genre;
            Duration = duration;
        }

        public void DisplayMovieDetails()
        {
            Console.WriteLine($"Movie [{MovieID}]: {Title} | Genre: {Genre} | Duration: {Duration} mins");
        }
    }
}