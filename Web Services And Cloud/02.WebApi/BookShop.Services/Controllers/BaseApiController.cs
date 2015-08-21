using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookShop.Data;
using BookShop.Services.Models.ViewModels;
using BookShop.Services.ViewModels;
using ForumSystem.Models;

namespace BookShop.Services.Controllers
{
    public class BaseApiController : ApiController
    {
        private IBookShopData data;

        protected readonly Expression<Func<Book, BookSimpleViewModel>> asBookSimpleModel =

              b => new BookSimpleViewModel()
              {
                  BookId = b.BookID,
                  Title = b.Title
              };

        protected readonly Expression<Func<Book, BookViewModel>> asBookViewModel =

                b => new BookViewModel()
                {
                    BookId = b.BookID,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                    Description = b.Description,
                    EditionType = b.EditionType,
                    AgeRestriction = b.AgeRestriction,
                    Price = b.Price,
                    Copies = b.Copies,
                    ReleaseDate = b.ReleaseDate,
                    Categories = b.Categories.Select(c => c.Name).ToList()
                };

        protected readonly Expression<Func<Author, AuthorViewModel>> asAuthorViewModel =
            a => new AuthorViewModel()
            {
                FirstName = a.FirstName,
                LastName = a.LastName
            };

        protected readonly Expression<Func<Category, CategoryViewModel>> asCategoryViewModel =

                c => new CategoryViewModel()
                {
                    CategoryID = c.CategoryID,
                    Name = c.Name
                };


        public BaseApiController()
            : this(new BookShopData(new BookShopContext()))
        {

        }

        public BaseApiController(IBookShopData data)
        {
            this.Data = data;
        }

        public IBookShopData Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
    }
}
