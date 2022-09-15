// 1. Nu erstattes ToList() med OrderByDescending(). Bemærk at den først kan lave sortering
//      efter at have gennemløbet hele collectionen.
// 2. Udkommenter iterationen for at vise at den stadig har Deferred Execution. Køres ikke.
// 3. Rækkefølgen betyder meget når man har non-streaming operators indblandet.


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


            var query = movies.Filter(m => m.Year > 2000).OrderByDescending(m => m.Rating);

            var enumerator = query.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }
        }
    }
}

