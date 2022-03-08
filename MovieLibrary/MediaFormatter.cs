using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MovieLibrary
{
    public class MediaFormatter
    {
        public List<string> FormatMovieToString(List<Movie> media)
        {
            List<string> mediaList = new List<string>();
            
                    for (int i = 0; i < media.Count; i++)
                    {
                        int id = media[i].id;
                        string title = media[i].title;
                        List<string> genres = media[i].genres.ToList();
                        string line;
                        string genre = "";

                        if (title.Contains(","))
                        {
                            line = $@"{id},""{title}""";
                        }
                        else
                        {
                            line = $"{id},{title}";
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
                        mediaList.Add($"{line},{genre}");
                    }

                    return mediaList;
        }

        public List<string> FormatShowToString(List<Show> media)
        {
            List<string> mediaList = new List<string>();
            
            for (int i = 0; i < media.Count; i++)
            {
                int id = media[i].id;
                string title = media[i].title;
                int seasonNum = media[i].SeasonNum;
                int episodeNum = media[i].EpisodeNum;
                List<string> writers = media[i].Writers.ToList();
                string line;
                string writer = "";

                if (title.Contains(","))
                {
                    line = $@"{id},""{title}"", {seasonNum}, {episodeNum}";
                }
                else
                {
                    line = $"{id},{title}, {seasonNum}, {episodeNum}";
                }

                for (int j = 0; j < writers.Count; j++)
                {
                    if (writers.Count != j + 1)
                    {
                        writer += writers[j] + "|";
                    }
                    else
                    {
                        writer += writers[j];
                    }
                }
                mediaList.Add($"{line},{writer}");
            }
            return mediaList;
        }
        
        public List<string> FormatVideoToString(List<Video> media)
        {
            List<string> mediaList = new List<string>();
            
            for (int i = 0; i < media.Count; i++)
            {
                int id = media[i].id;
                string title = media[i].title;
                string format = media[i].format;
                int length = media[i].length;
                List<int> regions = media[i].regions.ToList();
                string line;
                string region = "";

                if (title.Contains(","))
                {
                    line = $@"{id},""{title}"", {format}, {length},";
                }
                else
                {
                    line = $"{id},{title}, {format}, {length}";
                }

                for (int j = 0; j < regions.Count; j++)
                {
                    if (regions.Count != j + 1)
                    {
                        region += regions[j] + "|";
                    }
                    else
                    {
                        region += regions[j];
                    }
                }
                mediaList.Add($"{line},{region}");
            }
            return mediaList;
        }
        public List<Movie> FormatMovieToObject(List<string> file)
        {
            List <Movie> movies = new List<Movie>();

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Contains(@""""))
                {
                    string[] line = file[i].Split(@"""");
                    Movie movie = new Movie();
                    try
                    {
                        movie.id = int.Parse(line[0].Split(",")[0]);
                        movie.title = line[1];
                        movie.genres = line[2].Split("|");
                        movies.Add(movie);
                    }
                    catch(Exception)
                    {
                        
                    }
                   
                }
                else
                {
                    string[] line = file[i].Split(",");
                    Movie movie = new Movie();
                    try
                    {
                        movie.id = int.Parse(line[0]);
                        movie.title = line[1];
                        movie.genres = line[2].Split("|");
                        movies.Add(movie);
                    }
                    catch(Exception)
                    {
                       
                    }
                }
            }

            return movies;
        }
        
        public List<Show> FormatShowToObject(List<string> file)
        {
            List <Show> shows = new List<Show>();

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Contains(@""""))
                {
                    string[] line = file[i].Split(@"""");
                    Show show = new Show();
                    try
                    {
                        show.id = int.Parse(line[0].Split(",")[0]);
                        show.title = line[1];
                        show.SeasonNum = int.Parse(line[2]);
                        show.EpisodeNum = int.Parse(line[3]);
                        show.Writers = line[4].Split("|");
                        shows.Add(show);
                    }
                    catch (Exception)
                    {
                        
                    }
                    
                    
                }
                else
                {
                    string[] line = file[i].Split(",");
                    Show show = new Show();
                    try
                    {
                        show.id = int.Parse(line[0]);
                        show.SeasonNum = int.Parse(line[2]);
                        show.EpisodeNum = int.Parse(line[3]);
                        show.Writers = line[4].Split("|");
                        show.title = line[1];
                        shows.Add(show);
                    }
                    catch (Exception)
                    {

                    }
                    
                    
                }
                
            }
            return shows;
        }
        
        public List<Video> FormatVideoToObject(List<string> file)
        {
            List <Video> videos = new List<Video>();
            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Contains(@""""))
                {
                    List<int> region = new List<int>();
                    string[] line = file[i].Split(@"""");
                    Video video = new Video();
                    try
                    {
                        video.id = int.Parse(line[0].Split(",")[0]);
                        video.title = line[1];
                        video.format = line[2];
                    }
                    catch (Exception)
                    {
                        
                    }
                    

                    try
                    {
                        for (int j = 0; j < line[4].Split("|").Length; j++)
                        {
                            region.Add(int.Parse(line[4].Split("|")[j]));
                        }

                        video.length = int.Parse(line[3]);
                        video.regions = region.ToArray();
                        videos.Add(video);
                    }
                    catch (Exception)
                    {
                        
                    }
                    
                    
                }
                else
                {
                    string[] line = file[i].Split(",");
                    Video video = new Video();
                    List<int> region = new List<int>();

                    try
                    {
                        for (int j = 0; j < line[4].Split("|").Length; j++)
                        {
                            region.Add(int.Parse(line[4].Split("|")[j]));
                        }

                        video.id = int.Parse(line[0]);
                        video.length = int.Parse(line[3]);
                        video.title = line[1];
                        video.format = line[2];
                        video.regions = region.ToArray();
                        videos.Add(video);
                    }
                    catch (Exception)
                    {
                        
                    }
                    
                    
                }
            }
            return videos;
        }
    }
}