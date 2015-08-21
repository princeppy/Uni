using CalculateDistanceWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace CalculateDistanceWebApp.Controllers
{
    [RoutePrefix("api/calculators")]
    public class CalculatorsController : ApiController
    {
        [HttpPost]
        [Route("distance")]
        public IHttpActionResult CalcMe([FromBody]List<Point> points)
        {
            if (points.Count != 2)
            {
                return BadRequest("The list count is different from two");
            }
            var p1 = points[0];
            var p2 = points[1];

            var deltaX = p1.X - p2.X;
            var deltaY = p1.Y - p2.Y;
            return Ok(Math.Sqrt(deltaX*deltaX + deltaY*deltaY));

        }

        //public double Get(double x1, double y1, double x2, double y2)
        //{
        //    var p1 = new Point(x1, y1);
        //    var p2 = new Point(x2, y2);

        //    var deltaX = p1.X - p2.X;
        //    var deltaY = p1.Y - p2.Y;
        //    return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

        //}


        //// POST api/values
        //public void Post([FromBody]Point value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]Point value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
