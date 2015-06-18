using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Triangle : Shape
    {
        private double sideC;
        public Triangle(double sideA, double sideB, double sideC)
        {
            this.Width = sideA;
            this.Height = sideB;
            this.SideC = sideC;
        }

        public double SideC
        {
            get { return sideC; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The side must be positive number");
                }
                sideC = value;
            }
        }


        public override double CalculateArea()
        {
            double p = (this.Width + this.Height + this.SideC)/2;
            double area = Math.Sqrt(p*(p - this.Width)*(p - this.Height)*(p - this.SideC));
            return area;
        }

        public override double CalculatePerimeter()
        {
            return this.Width + this.Height + this.SideC;
        }

        public override string ToString()
        {
            return String.Format("{0} ({1};{2};{3})", this.GetType().Name, this.Width, this.Height, this.SideC);
        }
    }
}
