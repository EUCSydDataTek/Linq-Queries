﻿// 1. Lav en LINQ query med Where og en tilhørende iteration
// 2. Lav egen LINQ operator kaldet Filter i en ny klasse kaldet MyLinq


using LinqQueries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie { Title = "The Dark Knight", Rating=8.9f, Year = 2008 },
                new Movie { Title = "Star Wars V", Rating = 8.7f, Year = 1980 },
                new Movie { Title = "Casablanca", Rating=8.5f, Year = 1942 },
                new Movie { Title = "The King's Speech", Rating = 8.0f, Year = 2010 }
            };

            //var query = movies.Where(m => m.Year > 2000);
            var query = movies.Filter(m => m.Year > 2000);

            foreach (Movie movie in query)
            {
                Console.WriteLine(movie.Title);
            }
        }
    }
}

