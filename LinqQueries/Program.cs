// 1. Nu erstattes Extension syntax med Query syntax. Giver ingen ændring.
// 2. Vis: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/classification-of-standard-query-operators-by-manner-of-execution
// 3. Udvid MyLinq klassen med metoden Random, der streamer tilfældige tal
// 4. tilføj en query, der henter 10 tilfældige tal, som er større end 0.5


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

            var numbers = MyLinq.Random().Where(n => n > 0.5).Take(10).OrderBy(n => n);
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            var movies = new List<Movie>
            {
                new Movie { Title = "The Dark Knight", Rating=8.9f, Year = 2008 },
                new Movie { Title = "Star Wars V", Rating = 8.7f, Year = 1980 },
                new Movie { Title = "Casablanca", Rating=8.5f, Year = 1942 },
                new Movie { Title = "The King's Speech", Rating = 8.0f, Year = 2010 }
            };


            var query = from movie in movies
                        where movie.Year > 2000
                        orderby movie.Rating descending
                        select movie;

            var enumerator = query.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current.Title);
            //}
        }
    }
}

