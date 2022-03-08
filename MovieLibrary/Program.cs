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
            IServiceCollection serviceCollection = new ServiceCollection();
            var serviceProvider = serviceCollection.AddLogging(x => x.AddConsole()).BuildServiceProvider();
            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Logger>();
            
            InputOutputService service = new InputOutputService();
            Manager manager = new JsonManager();
            MediaFormatter formatter = new MediaFormatter();
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
                }

            } while ( option != "X");

        }
    }
}