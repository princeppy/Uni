using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BookShop.Data;
using BookShop.Services.Models;
using BookShop.Services.Models.BindingModel;
using BookShop.Services.ViewModels;
using ForumSystem.Models;
using Newtonsoft.Json;

namespace BookShop.Services.Controllers
{
    [RoutePrefix("api/authors")]
    public class AuthorsController : BaseApiController
    {
        public AuthorsController()
            : base(new BookShopData(new BookShopContext()))
        {
        }

        public AuthorsController(IBookShopData data)
            : base(data)
        {
            this.Data = Data;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IQueryable<AuthorViewModel>))]
        public IHttpActionResult GetAllAuthors()
        {
            var authors = this.Data.Authors.All()
                .Select(asAuthorViewModel)
                .AsQueryable();

            return Ok(authors);

        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetAuthorbyId(int id)
        {
            var author = this.Data.Authors.Find(id);

            if (author == null)
            {
                return BadRequest("No author with such id");
            }

            return this.Ok(asAuthorViewModel);
        }

        [HttpGet]
        [Route("{id}/books")]
        [ResponseType(typeof(IQueryable<BookViewModel>))]
        public IHttpActionResult GetBooksByAuthor(int id)
        {
            var existingAuthor = this.Data.Authors.All().FirstOrDefault(a => a.AuthorID == id);

            if (existingAuthor == null)
            {
                return BadRequest("No author with such id");
            }

            var books = this.Data.Books.All()
                .Where(b => b.Author.AuthorID == id)
                .Select(asBookViewModel)
                .AsQueryable();

            return this.Ok(books);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateAuthor(AuthorBindingModel author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorEntity = new Author()
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            if (this.Data.Authors.All()
                                 .FirstOrDefault(a => a.FirstName == author.FirstName && a.LastName == author.LastName) == null)
            {
                this.Data.Authors.Add(authorEntity);
                this.Data.SaveChanges();
                return this.Ok();
            }

            return BadRequest("There is already an author with these first and last name");
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteAuthor(int id)
        {
            var author = this.Data.Authors.Find(id);

            if (author == null)
            {
                return this.BadRequest("No author with such id");
            }

            this.Data.Authors.Delete(id);
            this.Data.SaveChanges();

            return this.Ok(author);
        }
    }
}
