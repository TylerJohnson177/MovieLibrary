using System.Collections.Generic;

namespace MovieLibrary
{
    public abstract class Media
    {
        public int id {get; set;}
        public string title {get; set;}


        public abstract string Display();

    }
}