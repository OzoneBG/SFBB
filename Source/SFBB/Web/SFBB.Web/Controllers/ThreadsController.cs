namespace SFBB.Web.Controllers
{
    using SFBB.Data.Common.Repository;
    using SFBB.Data.Models;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using SFBB.Web.ViewModels.Threads;

    public class ThreadsController : Controller
    {
        private IDeletableEntityRepository<Forum> forums;
        private IDeletableEntityRepository<Thread> threads;

        public ThreadsController(IDeletableEntityRepository<Forum> forums, IDeletableEntityRepository<Thread> threads)
        {
            this.forums = forums;
            this.threads = threads;
        }

        // GET: Threads
        public ActionResult ThreadsByForum(int id)
        {
            var model = this.forums.All().Where(x => x.Id == id).ProjectTo<ThreadsByForumViewModel>().FirstOrDefault();

            model.Threads = this.threads.All().Where(x => x.Forum.Id == id).ProjectTo<ThreadsInformationViewModel>().ToList();

            return View(model);
        }
    }
}