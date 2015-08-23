using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookShop.Data;
using BookShop.Service.Models.BindingModels;
using BookShop.Services.Controllers;

namespace BookShop.Service.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/users/{username}/roles")]
    public class UsersController : BaseApiController
    {
        public UsersController()
            : base(new BookShopData(new BookShopContext()))
        {
        }

        public UsersController(IBookShopData data)
            : base(data)
        {
        }

        [HttpPut]
        public IHttpActionResult AddRole(AddRoleBindingModel roleModel)
        {

            if (!this.Data.Roles.All().Any(r => r.Name == roleModel.Name))
            {
                return this.BadRequest("There is no such role in the database");
            }



            return this.Ok();

        }
    }
}
