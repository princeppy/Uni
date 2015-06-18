using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Shapes
{
    abstract class Shape:IShape
    {
        private double width;
        private double height;

        public double Height
        {
            get { return this.height; }
            set
            {
                if(value<=0)
                throw new ArgumentOutOfRangeException("The side must be positive number");
                this.height = value;
            }
        }

        public double Width
        {
            get { return this.width; }
            set
            {
                if(value<=0)
                throw new ArgumentOutOfRangeException("The side must be positive number");
                this.width = value;
            }
        }

        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
        

        public override string ToString()
        {
            return String.Format("{0} ({1};{2})", this.GetType().Name, this.Width, this.Height);
        }
    }
}
