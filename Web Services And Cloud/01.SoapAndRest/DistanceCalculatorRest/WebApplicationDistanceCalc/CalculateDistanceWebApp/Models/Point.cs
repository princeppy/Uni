using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculateDistanceWebApp.Models
{
    public class Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }
    }
}