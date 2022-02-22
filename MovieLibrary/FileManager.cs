using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;

namespace MovieLibrary
{
    public class FileManager
    {
        public List<string> Read()
        {
            var file = new List<string>();
            
            if (File.Exists("movies.csv"))
            {
                StreamReader fileReader = new StreamReader("movies.csv");
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

        public void Write(List<string> movies)
        {
            StreamWriter writer = new StreamWriter("movies.csv");
            
            for (int i = 0; i < movies.Count; i++)
            {
                writer.WriteLine(movies[i]);
            }
            writer.Close();
        }

        public string GetFileAsString()
        {
            StreamReader fileReader = new StreamReader("movies.csv");
            string file = fileReader.ReadToEnd();
            fileReader.Close();
            return file;
        }
        
    }
}