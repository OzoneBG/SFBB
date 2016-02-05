namespace SFBB.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using SFBB.Data.Common.Repository;
    using SFBB.Data.Models;
    using SFBB.Web.ViewModels.Category;

    public class CategoriesController : Controller
    {
        private readonly IDeletableEntityRepository<Category> categories;

        public CategoriesController(IDeletableEntityRepository<Category> categories)
        {
            this.categories = categories;
        }

        public ActionResult Category(int id)
        {
            var forums = this.categories.All().Where(x => x.Id == id).ProjectTo<ForumsByCategoryViewModel>().FirstOrDefault();

            return View(forums);
        }
    }
}