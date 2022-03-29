using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;

namespace MovieLibrary
{
    class MovieLibrary
    {
        static void Main(string[] args)
        {
            Dependency dep = new Dependency();

            InputOutputService service = dep.GetInputOutputService();
            Manager manager = dep.GetManager();
            MediaFormatter formatter = dep.GetFormatter();
            Search mediaSearch = dep.getSearch();
            
            string option;
            
            do
            {
                option = service.Startup();

                switch (option)
                {
                    case "L":
                        string mediaOption = service.MediaOption();
                        switch (mediaOption)
                        {
                            case "M":
                                List<Movie> movies = formatter.FormatMovieToObject(manager.ReadMedia("movies"));
                                for (int i = 0; i < movies.Count; i++)
                                {
                                    Console.WriteLine(movies[i].Display());
                                }
                                break;
                            case "S":
                                List<Show> shows = formatter.FormatShowToObject(manager.ReadMedia("shows"));
                                for (int i = 0; i < shows.Count; i++)
                                {
                                    Console.WriteLine(shows[i].Display());
                                }
                                break;
                            case "V":
                                List<Video> videos = formatter.FormatVideoToObject((manager.ReadMedia("videos")));
                                for (int i = 0; i < videos.Count; i++)
                                {
                                    Console.WriteLine(videos[i].Display());
                                }
                                break;
                        }
                        break;
                    case "A":
                        string addOption = service.AddOption();
                        switch (addOption)
                        {
                            case "M":
                                List<string> movies = formatter.FormatMovieToString(service.AddMovie(formatter.FormatMovieToObject(manager.ReadMedia("movies"))));
                                manager.WriteMedia(movies, "movies");
                                break;
                            case "S":
                                List<string> shows = formatter.FormatShowToString(service.AddShow(formatter.FormatShowToObject(manager.ReadMedia("shows"))));
                                manager.WriteMedia(shows, "shows");
                                break;
                            case "V":
                                List<string> videos = formatter.FormatVideoToString(service.AddVideo(formatter.FormatVideoToObject(manager.ReadMedia("videos"))));
                                manager.WriteMedia(videos, "videos");
                                break;
                        }
                        break;
                    case "S":
                        string searchString = service.SearchOption().ToUpper();
                        Console.WriteLine();
                        
                        List<Movie> movies1 =
                            mediaSearch.SearchMovies(formatter.FormatMovieToObject(manager.ReadMedia("movies")),
                                searchString);
                        if (movies1.Count > 0)
                        {
                            Console.WriteLine($"Movies: ({movies1.Count} results found)");
                            for (int i = 0; i < movies1.Count; i++)
                            {
                                Console.WriteLine(movies1[i].Display());
                            }
                            Console.WriteLine();
                        }
                        
                        List<Show> shows1 =
                            mediaSearch.SearchShows(formatter.FormatShowToObject(manager.ReadMedia("movies")),
                                searchString);
                        if (shows1.Count > 0)
                        {
                            Console.WriteLine($"Shows: ({shows1.Count} results found)");
                            for (int i = 0; i < shows1.Count; i++)
                            {
                                Console.WriteLine(shows1[i].Display());
                            }
                            Console.WriteLine();
                        }
                        
                        List<Video> videos1 =
                            mediaSearch.SearchVideos(formatter.FormatVideoToObject((manager.ReadMedia("videos"))),
                                searchString);
                        if (videos1.Count > 0)
                        {
                            Console.WriteLine($"Videos: ({videos1.Count} results found)");
                            for (int i = 0; i < videos1.Count; i++)
                            {
                                Console.WriteLine(videos1[i].Display());
                            }
                            Console.WriteLine();
                        }

                        if (videos1.Count == 0 && movies1.Count == 0 && shows1.Count == 0)
                        {
                            Console.WriteLine("No results found");
                            Console.WriteLine();
                        }
                        break;
                }

            } while ( option != "X");

        }
    }
}