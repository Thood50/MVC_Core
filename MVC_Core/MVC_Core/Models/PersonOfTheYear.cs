using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace MVC_Core.Models
{
    public class PersonOfTheYear
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        public List<PersonOfTheYear> GetPoTY (int start, int end)
        {
            List<PersonOfTheYear> peeps = new List<PersonOfTheYear>();
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"wwwroot\personOfTheYear.csv"));
            string[] allPoTY = File.ReadAllLines(path);

            for ( int i = 0; i < allPoTY.Length; i++)
            {
                peeps.Add(new PersonOfTheYear
                {
                    Year = Convert.ToInt32(allPoTY[0]),
                    Honor = allPoTY[1],
                    Name = allPoTY[2],
                    Country = allPoTY[3],
                    Birth_Year = Convert.ToInt32(allPoTY[4]),
                    DeathYear = (allPoTY[5] == "") ? 0 :Convert.ToInt32(allPoTY[5]),
                    Title = allPoTY[6],
                    Category = allPoTY[7],
                    Context = allPoTY[8],

                });
            }

            List<PersonOfTheYear> results = peeps.Where(p => (p.Year >= start) && (p.Year <= end)).ToList();

            return results;
        }
    }
}
