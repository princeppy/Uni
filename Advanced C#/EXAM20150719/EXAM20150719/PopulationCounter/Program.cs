using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PopulationCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<Dictionary<string, int>, Dictionary<string, Dictionary<string, int>>> dict = new Dictionary<Dictionary<string, int>, Dictionary<string, Dictionary<string, int>>>();


            Dictionary<string, Dictionary<string, BigInteger>> countries = new Dictionary<string, Dictionary<string, BigInteger>>();

            Dictionary<string, BigInteger> cities = new Dictionary<string, BigInteger>();

            var line = Console.ReadLine();
            while (line != "report")
            {
                var arr = line.Split('|');

                var city = arr[0];
                var country = arr[1];
                BigInteger population = new BigInteger(int.Parse(arr[2]));


                if (cities.ContainsKey(city))
                {
                    cities[city] += population;

                }
                else
                {
                    cities.Add(city, population);
                }


                if (!countries.ContainsKey(country))
                {
                    countries.Add(country, new Dictionary<string, BigInteger>() { { city, population } });
                }

                else
                {
                    countries[country].Add(city, population);
                }


                line = Console.ReadLine();
            }

            var countries1 = countries
                .OrderByDescending(x => x.Value.Values.Aggregate((a,b)=>a+b));

            

            foreach (var country in countries1)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("{0} (total population: ",country.Key));
                BigInteger countryPopulation = 0;
                var countryCities = country.Value.OrderByDescending(x=>x.Value);
                foreach (var item in countryCities)
                {
                    countryPopulation += item.Value;
                }

                sb.AppendLine(countryPopulation + ")");
                //Console.WriteLine(sb);

                foreach (var item in countryCities)
                {
                    sb.AppendLine(string.Format("=>{0}: {1}", item.Key, item.Value));
                }

                Console.WriteLine(sb.ToString().Trim());

            }

        }
    }
}
