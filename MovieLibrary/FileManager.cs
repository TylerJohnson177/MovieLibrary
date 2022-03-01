
using System.Collections.Generic;
using System.IO;

namespace MovieLibrary
{
    public class FileManager
    {
        public List<string> ReadMedia(string fileName)
        {
            var file = new List<string>();
            
            if (File.Exists(fileName))
            {
                StreamReader fileReader = new StreamReader(fileName);
                string? line = "";

                do
                {
                    line = fileReader.ReadLine();
                    
                    if (line != null)
                    {
                        file.Add(line);
                    }
                    
                } while (line != null);
                fileReader.Close();
                
            }
            return file;
        }

        public void WriteMedia(List<string> media, string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);

            if (fileName == "movies.csv")
            {
                writer.WriteLine("id,title,genres");
            }
            else if(fileName == "shows.csv")
            {
                writer.WriteLine("id,title,season,episode,writers");
            }
            else
            {
                writer.WriteLine("id,title,format,length,regions");
            }
            
            for (int i = 0; i < media.Count; i++)
            {
                writer.WriteLine(media[i]);
            }
            writer.Close();
        }

        public string GetFileAsString(string fileName)
        {
            StreamReader fileReader = new StreamReader(fileName);
            string file = fileReader.ReadToEnd();
            fileReader.Close();
            return file;
        }
        
    }
}