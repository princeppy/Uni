using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Restaurants.Data;
using Restaurants.Data.Data;

namespace Restaurants.Services.Controllers
{
    public class BaseApiController : ApiController
    {
        private IRestaurantsData data;

        public BaseApiController()
            : this(new RestaurantsData(new RestaurantsContext()))
        {
        }

        public BaseApiController(IRestaurantsData data)
        {
            this.Data = data;
        }

        public IRestaurantsData Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
    }
}
