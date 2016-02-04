namespace SFBB.Web.Controllers
{
    using SFBB.Data.Common.Repository;
    using SFBB.Data.Models;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using SFBB.Web.ViewModels.Category;
    using System.Linq;

    public class CategoryController : Controller
    {
        private readonly IDeletableEntityRepository<Category> categories;

        public CategoryController(IDeletableEntityRepository<Category> categories)
        {
            this.categories = categories;
        }

        public ActionResult GetForumsByCategory(int id)
        {
            var forums = this.categories.All().Where(x => x.Id == id).ProjectTo<ForumsByCategoryViewModel>().FirstOrDefault();
        
            return View(forums);
        }
    }
}