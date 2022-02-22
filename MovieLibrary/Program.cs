using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Transactions;
using Microsoft.VisualBasic.CompilerServices;

namespace MovieLibrary
{
    class MovieLibrary
    {
        static void Main(string[] args)
        {
            
            string option = "";
            FileManager manager = new FileManager();
            MovieFormatter formatter = new MovieFormatter();
            List<string> movieList = manager.Read();
            
            do
            {
                Console.WriteLine("Welcome to the Movie Library");
                Console.WriteLine("Options");
                Console.WriteLine("(L): List Movies");
                Console.WriteLine("(A): Add more Movies to the library");
                Console.WriteLine("(X): Exit");

                try
                {
                    option = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                
                switch (option.ToUpper())
                {
                    case "L":
                        string listOptions = "N";
                        int page = 0;
                        
                        do
                        {

                            Console.WriteLine($"Displaying movies {page + 1} Through {(page + 50)}");
                            Console.WriteLine("Options");
                            Console.WriteLine("(X) Exit List");
                            Console.WriteLine("(N) Next Page");
                            
                            if (listOptions.ToUpper() == "N")
                            {
                                for (int i = 0; i < movieList.Count; i++)
                                {
                                    if (i <= page + 49 && i >= page)
                                    {
                                        if (movieList[i].Contains(@""""))
                                        {
                                            List<string> movie = movieList[i].Split(@"""").ToList();
                                            Console.WriteLine($"ID: {movie[0]} Title: {movie[1]} Genres: {movie[2]}");
                                        }
                                        else
                                        {
                                            List<string> movie = movieList[i].Split(",").ToList();
                                            Console.WriteLine($"ID: {movie[0]} Title: {movie[1]} Genres: {movie[2]}");
                                        }
                                        
                                    }
                                }
                            }
                            
                            page += 50;
                            
                            try
                            {
                                listOptions = Console.ReadLine();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                            
                        } while (listOptions.ToUpper()!= "X");
                        break;
                       
                    case "A":

                        List<Movie> newMovies = new List<Movie>();
                        string title = "";
                        string releaseDate;

                        do
                        {
                            List<string> Genres = new List<string>();
                            
                            Console.WriteLine("Enter the Movie Title or (X) to Exit");
                            try
                            {
                                title = Console.ReadLine();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                            
                            if (title.ToUpper() == "X")
                            {
                                break;
                            }

                            Console.WriteLine("Enter the Release Date");
                            try
                            {
                                 releaseDate = Console.ReadLine();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }

                            Console.WriteLine("Enter the Genres (X) to Exit");

                            string genre = "";

                            do
                            {
                                try
                                {
                                    genre = Console.ReadLine();

                                    if (genre.ToUpper() == "X")
                                    {
                                        break;
                                    }
                                    Genres.Add(genre);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                    throw;
                                }
                            } while (genre.ToUpper() != "X");
                            
                            newMovies.Add(new Movie(title, releaseDate, Genres, int.Parse((movieList[movieList.Count - 1]).Split(",")[0]) + 1 + newMovies.Count));
                            
                        } while (title.ToUpper() != "X");

                        List<string> AddedMovies = formatter.FormatToString(newMovies);

                        bool isFound = false;
                        
                        for (int i = 0; i < AddedMovies.Count; i++)
                        {
                            if (manager.GetFileAsString().Contains(AddedMovies[i].Split(",")[1]))
                            {
                                Console.WriteLine($"The Movie: {AddedMovies[i].Split(",")[1]} Already Exists in the library");
                            }
                            else
                            {
                                movieList.Add(AddedMovies[i]);
                            }
                        }
                        manager.Write(movieList);
                        break;
                        
                }   
                
            } while (option.ToUpper() != "X");
            
        }
    }
}