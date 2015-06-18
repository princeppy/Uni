using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return 2*(this.Height + this.Width);
        }
    }
}
