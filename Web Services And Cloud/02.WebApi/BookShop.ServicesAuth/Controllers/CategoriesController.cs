using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BookShop.Data;
using BookShop.ServicesAuth.Models.BindingModels;
using BookShop.ServicesAuth.Models.ViewModels;
using ForumSystem.Models;

namespace BookShop.Services.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : BaseApiController
    {
        public CategoriesController()
            : base(new BookShopData(new BookShopContext()))
        {
        }

        public CategoriesController(IBookShopData data):base(data)
        {
            this.Data = data;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IQueryable<CategoryViewModel>))]
        public IHttpActionResult GetAllCategories()
        {
            var categories = this.Data.Category.All().Select(asCategoryViewModel).AsQueryable();
            return this.Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetCategoryById(int id)
        {

            var category = this.Data.Category.All()
                .Where(c=>c.CategoryID== id)
                .Select(asCategoryViewModel)
                .FirstOrDefault();
            
            if (category == null)
            {
                return this.BadRequest("There is no category with such id");
            }

            return this.Ok(category);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateCategoryName(int id, CategoryUpdateBindingModel categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = this.Data.Category.Find(id);

            if (category == null)
            {
                return this.BadRequest("No category with such id");
            }
            
            category.Name = categoryModel.Name;

            this.Data.Category.Update(category);
            this.Data.SaveChanges();

            return Ok(category);
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteCategory(int id)
        {
            var category = this.Data.Category.Find(id);

            if (category == null)
            {
                return this.BadRequest("No category with such id");
            }

            this.Data.Category.Delete(id);
            this.Data.SaveChanges();

            return this.Ok(category);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateCategory(CategoryUpdateBindingModel categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var category = this.Data.Category.All()
                .FirstOrDefault(c=>c.Name==categoryModel.Name);

            if (category != null)
            {
                return this.BadRequest("There is already a category with that name");
            }

            var newCategory = new Category()
            {
                Name = categoryModel.Name
            };

            this.Data.Category.Add(newCategory);
            this.Data.SaveChanges();

            return this.Ok(Data);
        }
    }
}
