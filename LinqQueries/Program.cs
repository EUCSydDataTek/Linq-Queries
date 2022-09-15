// 1. En Exception kastes i Movie-klassen.
// 2. En query exekveres med ToLIst() i en Try-block og det fungerer fint.
// 3. Nu fjernes ToList() og ingen Exception bliver håndteret. Fordi det kun
//      kun er querien, der er inde i Try-blokken - og det er ikke noget værd.
//      Man skal placere den linje hvor querien eksekveres i en Try-blok!


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

            var query = Enumerable.Empty<Movie>();

            try
            {
                query = movies.Filter(m => m.Year > 2000);//.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(query.Count());

            var enumerator = query.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }
        }
    }
}

