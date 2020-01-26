using System;
using System.Collections.Generic;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie { Title="The Dark Knight",   Rating=8.9f, Year=2008},
                new Movie { Title="The King's speech", Rating=8.0f, Year=2010},
                new Movie { Title="Casablanca",        Rating=8.5f, Year=1942 },
                new Movie { Title="Star Wars V",       Rating=8.7f, Year=1980}
            };
        }
    }
}
