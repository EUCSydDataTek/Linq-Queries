// 1. Foreach erstattes med en mere explicit udgave med en enumerator
// 2. Der laves en debug, som tydeligt viser princippet i Deferred Execution.
//      Bemærk at det er først ved MoveNext() at filter-metoden rammes!
// 3. Querien udvides med Take(1). Bemærk hvor lidt arbejde der udføres.
// 4. Querien kan sammenkædes fra flere lag eller forskellige tidspunkter.
//      Dette er vist ved at bryde query op i to linjer.


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

            // later
            query = query.Take(1);

            var enumerator = query.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }
        }
    }
}

