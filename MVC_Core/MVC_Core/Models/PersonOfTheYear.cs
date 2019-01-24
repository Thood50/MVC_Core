using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace MVC_Core.Models
{
    public class PersonOfTheYear
    {
        
        // All the properties needed to get from csv file              
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }


        /// <summary>
        /// Takes in two years, extracts data from a file and then filters it based on the two years entered by the user
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>List of PoTY between inputed years</returns>
        public List<PersonOfTheYear> GetPoTY (int start, int end)
        {
            List<PersonOfTheYear> peeps = new List<PersonOfTheYear>();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../wwwroot/personOfTheYear.csv");
            string[] data = File.ReadAllLines(path);

            for ( int i = 1; i < data.Length; i++)
            {
                string[] allPoTY = data[i].Split(',');

                peeps.Add(new PersonOfTheYear
                {
                    Year = Convert.ToInt32(allPoTY[0]),
                    Honor = allPoTY[1],
                    Name = allPoTY[2],
                    Country = allPoTY[3],
                    Birth_Year = (allPoTY[4] == "") ? 0 : Convert.ToInt32(allPoTY[4]),
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
