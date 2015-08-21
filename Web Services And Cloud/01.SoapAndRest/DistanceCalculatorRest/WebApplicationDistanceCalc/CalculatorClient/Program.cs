using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CalculateDistanceWebApp.Models;
using RestSharp;
using RestSharp.Serializers;

namespace CalculatorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Change the local host with the one from your IIS
            var client = new RestClient("http://localhost:64520");
            var request = new RestRequest("api/calculators/distance", Method.POST);

            request.RequestFormat = DataFormat.Json;

            var pointsList = new List<Point>()
            {
                new Point(1, 1),
                new Point(2, 2)
            };

            request.AddBody(pointsList);

            var response = client.Execute(request);
            Console.WriteLine(string.Format("The distance between the points is: {0:F3}",double.Parse(response.Content)));
        }
    }
}
