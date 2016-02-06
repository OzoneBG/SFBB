namespace SFBB.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using SFBB.Data.Common.Repository;
    using SFBB.Data.Models;
    using SFBB.Web.ViewModels.Threads;

    public class ThreadsController : Controller
    {

        private readonly IDeletableEntityRepository<Thread> threads;

        public ThreadsController(IDeletableEntityRepository<Thread> threads)
        {
            this.threads = threads;
        }

        // GET: Threads
        public ActionResult Thread(int id)
        {
            var currentThreads = this.threads.All().Where(x => x.Id == id);

            var threads = currentThreads.ProjectTo<ThreadsViewModel>().FirstOrDefault();

            return View(threads);
        }
    }
}