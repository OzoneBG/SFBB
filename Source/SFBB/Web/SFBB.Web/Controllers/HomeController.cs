namespace SFBB.Web.Controllers
{
    using SFBB.Data;
    using SFBB.Data.Common.Repository;
    using SFBB.Data.Models;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using SFBB.Web.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IDeletableEntityRepository<Category> categories;


        public HomeController(IDeletableEntityRepository<Category> categories)
        {
            this.categories = categories;
        }

        public ActionResult Index()
        {
            var cats = this.categories.All().Project().To<IndexCategoriesForumsViewModel>();

            return View(cats);
        }
    }
}