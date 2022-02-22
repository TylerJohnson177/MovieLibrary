using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace MovieLibrary
{
    public class Movie
    {
        private string movieTitle;
        private string releaseDate;
        private List<string> genres;
        private int id;

        public Movie(string movieTitle, string releaseDate, List<string> genres, int id)
        {
            this.movieTitle = movieTitle;
            this.releaseDate = releaseDate;
            this.genres = genres;
            this.id = id;
        }

        public string GetMovieTitle()
        {
            return movieTitle;
        }

        public void SetMovieTitle(string movieTitle)
        {
            this.movieTitle = movieTitle;
        }

        public string GetReleaseDate()
        {
            return releaseDate;
        }

        public void SetReleaseDate(string releaseDate)
        {
            this.releaseDate = releaseDate;
        }

        public List<string> GetGenres()
        {
            return genres;
        }

        public void SetGenres(List<string> genres)
        {
            this.genres = genres;
        }

        public int GetID()
        {
            return id;
        }

        public void SetID(int id)
        {
            this.id = id;
        }
    }
}