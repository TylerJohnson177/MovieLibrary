using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MovieLibrary
{
    public class JsonManager : Manager
    {
        public List<string> ReadMedia(string name)
        {
            string fileName = name + ".json";
            
            var file = new List<string>();
            file.Add("");

            if (File.Exists(fileName))
            {
                StreamReader fileReader = new StreamReader(fileName);
                MediaFormatter formatter = new MediaFormatter();
                string json;

                if (fileName == "movies.json")
                {
                    List<Movie> movies = new List<Movie>();
                    do
                    {
                        json = fileReader.ReadLine();
                    
                        if (json != null)
                        {
                            movies.Add(JsonConvert.DeserializeObject<Movie>(json));
                        }
                    
                    } while (json != null);

                    file = formatter.FormatMovieToString(movies);

                }
                else if (fileName == "shows.json")
                {
                    List<Show> shows = new List<Show>();
                    do
                    {
                        json = fileReader.ReadLine();
                    
                        if (json != null)
                        {
                            shows.Add(JsonConvert.DeserializeObject<Show>(json));
                        }
                    
                    } while (json != null);

                    file = formatter.FormatShowToString(shows);

                }
                else if(fileName == "videos.json")
                {
                    List<Video> videos = new List<Video>();
                    
                    do
                    {
                        json = fileReader.ReadLine();
                    
                        if (json != null)
                        {
                            videos.Add(JsonConvert.DeserializeObject<Video>(json));
                        }
                    
                    } while (json != null);

                    file = formatter.FormatVideoToString(videos);
                }

                fileReader.Close();
            }
            
            return file;
        }

        
        public void WriteMedia(List<string> media, string name)
        {
            string fileName = name + ".json";
            StreamWriter writer = new StreamWriter(fileName);
            MediaFormatter formatter = new MediaFormatter();
            
            if (fileName == "movies.json")
            {
                List<Movie> movies = formatter.FormatMovieToObject(media);
                
                for (int i = 0; i < movies.Count; i++)
                {
                    writer.WriteLine(JsonConvert.SerializeObject(movies[i]));
                }
            }
            else if (fileName == "shows.json")
            {
                List<Show> shows = formatter.FormatShowToObject(media);

                for (int i = 0; i < shows.Count; i++)
                {
                    writer.WriteLine(JsonConvert.SerializeObject(shows[i]));
                }
            }
            else if(fileName == "videos.json")
            {
                List<Video> videos = formatter.FormatVideoToObject(media);

                for (int i = 0; i < videos.Count; i++)
                {
                    writer.WriteLine(JsonConvert.SerializeObject(videos[i]));
                }
            }

            writer.Close();
        }
    }
}