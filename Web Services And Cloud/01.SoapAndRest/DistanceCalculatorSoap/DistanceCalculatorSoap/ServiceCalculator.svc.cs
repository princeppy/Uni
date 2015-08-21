using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DistanceCalculatorSoap
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceCalculator" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceCalculator.svc or ServiceCalculator.svc.cs at the Solution Explorer and start debugging.
    public class ServiceCalculator : ICalculator
    {

        public double CalcDistanse(Point startPoint, Point endPoint)
        {
            double deltaX = startPoint.X - endPoint.X;
            double deltaY = startPoint.Y - endPoint.Y;

            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
}
