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
        private IRepository<Category> categories;


        public HomeController(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public ActionResult Index()
        {
            var cats = categories.All().Project().To<IndexCategoriesForumsViewModel>();

            return View(cats);
        }
    }
}