namespace SFBB.Web.Controllers
{
    using SFBB.Data;
    using SFBB.Data.Common.Repository;
    using SFBB.Data.Models;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private IRepository<Thread> _threads;

        //Poor man's DI
        public HomeController()
            : this(new GenericRepository<Thread>(new SfbbDbContext()))
        {
        }

        public HomeController(IRepository<Thread> threads)
        {
            _threads = threads;
        }

        public ActionResult Index()
        {
            var posts = _threads.All();

            return View(posts);
        }
    }
}