using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary
{
    public class Search
    {
        public List<Movie> SearchMovies(List<Movie> movies, string searchString)
        {
            return movies.Where(m => m.title.ToUpper().Contains(searchString)).ToList();
        }
        
        public List<Show> SearchShows(List<Show> shows, string searchString)
        {
            return shows.Where(s => s.title.ToUpper().Contains(searchString)).ToList();
        }
        
        public List<Video> SearchVideos(List<Video> videos, string searchString)
        {
           return videos.Where(v => v.title.ToUpper().Contains(searchString)).ToList();
        }
        
        
    }
}