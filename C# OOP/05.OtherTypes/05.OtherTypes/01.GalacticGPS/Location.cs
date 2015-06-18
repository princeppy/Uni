using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GalacticGPS
{
    public struct Location
    {
        private double latitude;
        private double longitude;

        public Location(double latitude, double longitude, Planet planet)
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public Planet Planet { get; set; }
        public double Latitude
        {
            get { return latitude; }
            set
            {
                if (value < -90 || value > 90)
                {
                    throw new ArgumentOutOfRangeException("The range of the latitude is [-90;90]");
                }
                this.latitude = value;
            }
        }

        public double Longitude
        {
            get { return this.longitude; }
            set
            {
                if (value < -180 || value > 180)
                {
                    throw new ArgumentOutOfRangeException("The range of the longitude is [-180;180]");
                }
                this.longitude = value;
            }
        }


        public override string ToString()
        {
            return String.Format("{0}, {1} - {2}", this.Latitude, this.Longitude, this.Planet);
        }
    }
}
