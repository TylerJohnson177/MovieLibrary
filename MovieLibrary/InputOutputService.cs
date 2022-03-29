using System;
using System.Collections.Generic;

namespace MovieLibrary
{
    public class InputOutputService
    {
        public string Startup()
        {
            Console.WriteLine("Welcome to the Media Library");
            Console.WriteLine("Options");
            Console.WriteLine("(L): List Media");
            Console.WriteLine("(A): Add Media to the library");
            Console.WriteLine("(S): Search Media");
            Console.WriteLine("(X): Exit Program");
            string option = Console.ReadLine().ToUpper();
            return option;
        }

        public string MediaOption()
        {
            Console.WriteLine("Select the Media Type to List");
            Console.WriteLine("(M): Movies");
            Console.WriteLine("(S): Shows");
            Console.WriteLine("(V): Videos");
            Console.WriteLine("(X): Exit List Menu");
            string option = Console.ReadLine().ToUpper();
            return option;

        }

        public string SearchOption()
        {
            Console.WriteLine("Enter a string to search");
            string searchString = Console.ReadLine();
            return searchString;
        }

        public string AddOption()
        {
            Console.WriteLine("Select the Media Type to Add");
            Console.WriteLine("(M): Movies");
            Console.WriteLine("(S): Shows");
            Console.WriteLine("(V): Videos");
            Console.WriteLine("(X): Exit Add Menu");
            string option = Console.ReadLine().ToUpper();
            return option;
        }

        public List<Movie> AddMovie(List<Movie> movieList)
        {
            string title = "";
            do
            {
                Console.WriteLine("Enter the Movie Title or (X) to Exit and Save");
                title = Console.ReadLine();
                if (title.ToUpper() == "X")
                {
                    break;
                }
                Console.WriteLine("Enter the Genres, type (X) to Exit");
                string genre = "";
                List<string> genres = new List<string>();
                do
                { 
                    genre = Console.ReadLine();
                    
                    if (genre.ToUpper() == "X")
                    {
                        break;
                    }
                    
                    genres.Add(genre);
                    
                } while (genre.ToUpper() != "X");

                Movie movie = new Movie();
                movie.id = movieList.Count + 1;
                movie.title = title;
                movie.genres = genres.ToArray();
                movieList.Add(movie);

            } while (title.ToUpper() != "X");

            return movieList;
        }
        
        public List<Show> AddShow(List<Show> showList)
        {
            string title = "";
            do
            {
                Console.WriteLine("Enter the Show Title or (X) to Exit and Save");
                title = Console.ReadLine();
                int season = 0;
                int episode = 0;
                
                if (title.ToUpper() == "X")
                {
                    break;
                }
                
                Console.WriteLine("Enter Season Number");
                try
                {
                    season = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                
                Console.WriteLine("Enter Episode Number");
                try
                {
                    episode = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine("Enter the Writers, type (X) to Exit");
                
                string writer = "";
                List<string> writers = new List<string>();
                do
                { 
                    writer = Console.ReadLine();
                    
                    if (writer.ToUpper() == "X")
                    {
                        break;
                    }
                    
                    writers.Add(writer);
                    
                } while (writer.ToUpper() != "X");

                Show show = new Show();
                show.id = showList.Count + 1;
                show.title = title;
                show.SeasonNum = season;
                show.EpisodeNum = episode;
                show.Writers = writers.ToArray();
                showList.Add(show);

            } while (title.ToUpper() != "X");

            return showList;
        }
        
        public List<Video> AddVideo(List<Video> videoList)
        {
            string title = "";
            int length = 0;
            do
            {
                Console.WriteLine("Enter the Video Title or (X) to Exit and Save");
                title = Console.ReadLine();

                if (title.ToUpper() == "X")
                {
                    break;
                }
                Console.WriteLine("Enter the Format");
                string format = Console.ReadLine();
                
                Console.WriteLine("Enter the Length");
                try
                {
                    length = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                
                Console.WriteLine("Enter the Regions, type (X) to Exit");
                string region = "";
                List<int> regions = new List<int>();
                do
                { 
                    region = Console.ReadLine();
                    
                    if (region.ToUpper() == "X")
                    {
                        break;
                    }
                    
                    try
                    {
                        regions.Add(int.Parse(region));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    
                } while (region.ToUpper() != "X");

                Video video = new Video();
                video.id = videoList.Count + 1;
                video.title = title;
                video.format = format;
                video.length = length;
                video.regions = regions.ToArray();
                videoList.Add(video);

            } while (title.ToUpper() != "X");

            return videoList;
        }
    }
}