namespace BookShop.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Data;
    using ForumSystem.Models;
    using Microsoft.AspNet.Identity;
    using Service.Models.BindingModels;
    using Service.Models.ViewModels;

    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/books")]
    public class BooksController : BaseApiController
    {
        public BooksController()
            : base(new BookShopData(new BookShopContext()))
        {
        }

        public BooksController(IBookShopData data)
            : base(data)
        {
            this.Data = data;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetBookById(int id)
        {
            var book = this.Data.Books.All().Where(b => b.BookID == id)
                .Select(asBookViewModel)
                .FirstOrDefault();

            if (book == null)
            {
                return this.BadRequest("No book with such id");
            }

            var author = this.Data.Authors.All().FirstOrDefault(a => a.AuthorID == book.AuthorId);
            var authorModel = new AuthorViewModel()
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            return this.Ok(new { Book = book, Author = authorModel });
        }

        [HttpGet]
        [ResponseType(typeof(IQueryable<BookSimpleViewModel>))]
        [Route("")]
        public IHttpActionResult GetTop10BooksByPatternName(string search)
        {
            var books = this.Data.Books.All()
                .Where(b => b.Title.ToLower().Contains(search.ToLower()))
                .OrderBy(b => b.Title)
                .Select(asBookSimpleModel)
                .AsQueryable();

            return this.Ok(books);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult EditBook(int id, BookUpdateBindingModel bookUpdateModel)
        {
            var book = this.Data.Books.Find(id);

            if (book == null)
            {
                return this.BadRequest("There is no book with such id");
            }

            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            book.Title = bookUpdateModel.Title;
            book.Description = bookUpdateModel.Description;
            book.ReleaseDate = bookUpdateModel.ReleaseDate;
            book.AgeRestriction = bookUpdateModel.AgeRestriction;
            book.Price = bookUpdateModel.Price;
            book.EditionType = bookUpdateModel.EditionType;
            book.AuthorId = bookUpdateModel.AuthorId;
            book.Copies = bookUpdateModel.Copies;

            this.Data.Books.Update(book);
            this.Data.SaveChanges();

            return this.Ok(book);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult AddBook(BookCreateBindingModel bookUpdateModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.Data.Books.All()
                .Any(b => b.Title.ToLower().Equals(bookUpdateModel.Title.ToLower()) && b.AuthorId == bookUpdateModel.AuthorId))
            {
                return this.BadRequest("There is already a book with this title from the same author");
            }

            var book = new Book()
            {
                Title = bookUpdateModel.Title,
                Description = bookUpdateModel.Description,
                ReleaseDate = bookUpdateModel.ReleaseDate,
                AgeRestriction = bookUpdateModel.AgeRestriction,
                Price = bookUpdateModel.Price,
                EditionType = bookUpdateModel.EditionType,
                AuthorId = bookUpdateModel.AuthorId,
                Copies = bookUpdateModel.Copies
            };

            var regex = new Regex("\\s+");
            var categoriesArray = regex.Split(bookUpdateModel.Categories);

            var catCtrl = new CategoriesController(this.Data);

            foreach (var name in categoriesArray)
            {
                var category = new CategoryUpdateBindingModel() { Name = name };
                catCtrl.CreateCategory(category);
            }

            this.Data.Books.Add(book);
            this.Data.SaveChanges();

            return this.Ok(book);
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteBook(int id)
        {
            var book = this.Data.Books.Find(id);

            if (book == null)
            {
                return this.BadRequest("No book with such id");
            }

            this.Data.Books.Delete(id);
            this.Data.SaveChanges();

            return this.Ok(book);
        }

        [HttpPut]
        [Route("buy/{id}")]
        public IHttpActionResult BuyBook(int id)
        {
            var currentUserId = User.Identity.GetUserId();
            var book = this.Data.Books.Find(id);

            if (book == null)
            {
                return this.BadRequest("There is no book with such id");
            }

            if (book.Copies == 0)
            {
                return this.BadRequest("All the copies have been sold out");
            }

            book.Copies -= 1;

            var purchase = new Purchase()
            {
                Book = book,
                DateOfPurchase = DateTime.Now,
                Price = book.Price,
                PurchaseStatus = PurchaseStatus.Normal,
                User = this.Data.Users.Find(currentUserId)
            };

            this.Data.Books.Update(book);

            this.Data.Purchases.Add(purchase);

            this.Data.SaveChanges();

            return this.Ok("Book sold");
        }
    }
}
