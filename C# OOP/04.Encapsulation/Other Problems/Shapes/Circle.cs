using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle:IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }       
        public double Radius
        {
            get { return radius; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Radius must be a positive number");
                }
                radius = value;
            }
        }

        public double CalculateArea()
        {
            return Math.PI*this.Radius*this.Radius;
        }

        public double CalculatePerimeter()
        {
            return 2*Math.PI*this.Radius;
        }

        public override string ToString()
        {
            return String.Format("{0} ({1})", this.GetType().Name, this.Radius);
        }
    }
}
