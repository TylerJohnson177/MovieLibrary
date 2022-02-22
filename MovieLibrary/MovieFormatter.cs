using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace MovieLibrary
{
    public class MovieFormatter
    {
        public List<string> FormatToString(List<Movie> movies)
        {
            List<string> moviesString = new List<string>();
            
            for (int i = 0; i < movies.Count; i++)
            {
                int id = movies[i].GetID();
                string movieTitle = movies[i].GetMovieTitle();
                string releaseDate = movies[i].GetReleaseDate();
                List<string> genres = movies[i].GetGenres();
                string line;
                string genre = "";

                if (movieTitle.Contains(","))
                {
                    line = $@"{id},""{movieTitle}"", ({releaseDate}),";
                }
                else
                {
                    line = $"{id},{movieTitle} ({releaseDate}),";
                }

                for (int j = 0; j < genres.Count; j++)
                {
                    if (genres.Count != j + 1)
                    {
                        genre += genres[j] + "|";
                    }
                    else
                    {
                        genre += genres[j];
                    }
                    
                }
                
                moviesString.Add($"{line}{genre}");
                
            }

            return moviesString;

        }
    }
}