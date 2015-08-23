using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Battleships.WebServices.Models.ViewModels
{
    public class ResponseResultViewModel
    {
        public string Message { get; set; }
        public HttpError ModelState { get; set; }
    }
}