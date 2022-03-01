
using System.Collections.Generic;
using System.Data.Common;

namespace MovieLibrary
{
    public class Movie : Media
    {
        public string[] genres {get; set;}

        public override string Display()
        {
            string movie = $"ID:{id} Title: {title} Genres: ";
            string genre = "";

            for (int i = 0; i < genres.Length; i++)
            {
                genre += genres[i] + ", ";
            }
            return movie + genre;
        }
        
    }
}