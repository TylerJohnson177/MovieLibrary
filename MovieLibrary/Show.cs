using System.Collections.Generic;

namespace MovieLibrary
{
    public class Show : Media
    {
        public int EpisodeNum {get; set;}
        public int SeasonNum {get; set;}
        public string[] Writers {get; set;}

        public override string Display()
        {
            string show = $"ID: {id} Title: {title} Episode: {EpisodeNum} Season: {SeasonNum} Writers: ";
            string writer = "";
            
            for (int i = 0; i < Writers.Length; i++)
            {
                writer += Writers[i] + ", ";
            }
            return show + writer;
        }
    }
}