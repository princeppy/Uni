using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Tests.Models
{
    public class LoggedUser
    {
        public string access_token { get; set; }

        public string username { get; set; }

        public string token_type { get; set; }
    }
}
