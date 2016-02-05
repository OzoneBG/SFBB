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

        public HomeController(IDeletableEntityRepository<Category> categories)
        {
            this.categories = categories;
        }

        public ActionResult Index()
        {
            var cats = this.categories.All().Where(z => z.Forums.Count != 0).ProjectTo<IndexViewModel>().ToList();

            return View(cats);
        }

        //TO DO: Construct area
        public ActionResult Announcements()
        {
            return View();
        }

        //TO DO: Construct area
        public ActionResult UnansweredPosts()
        {
            return View();
        }

        //TO DO: Construct area
        public ActionResult Rules()
        {
            return View();
        }

        //TO DO: Construct area
        public ActionResult FAQ()
        {
            return View();
        }
    }
}