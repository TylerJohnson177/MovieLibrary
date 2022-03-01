using System.Collections.Generic;

namespace MovieLibrary
{
    public class Video : Media
    {
        public string format {get; set;}
        public int length {get; set;}
        public int[] regions {get; set;}

        public override string Display()
        {
            string video = $"ID {id} Title: {title} Format: {format} Length: {length} Regions: ";
            string region = "";
            
            for (int i = 0; i < regions.Length; i++)
            {
                region += regions[i] + ", ";
            }
            return video + region;
            
        }
        
    }
}