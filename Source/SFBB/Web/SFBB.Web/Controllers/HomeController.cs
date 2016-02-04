namespace SFBB.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using SFBB.Web.ViewModels.Home;
    using SFBB.Data;
    using SFBB.Data.Common.Repository;
    using SFBB.Data.Models;

    public class HomeController : Controller
    {
        private readonly IDeletableEntityRepository<Category> categories;

        private readonly IDeletableEntityRepository<Forum> forums;

        private readonly IDeletableEntityRepository<Thread> threads;

        public HomeController(IDeletableEntityRepository<Category> categories, IDeletableEntityRepository<Forum> forums, IDeletableEntityRepository<Thread> threads)
        {
            this.categories = categories;
            this.forums = forums;
            this.threads = threads;
        }

        public ActionResult Index()
        {
            var cats = this.categories.All().ProjectTo<IndexViewModel>().ToList();

            return View(cats);
        }
    }
}