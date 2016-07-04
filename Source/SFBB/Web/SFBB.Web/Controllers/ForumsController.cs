namespace SFBB.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Data.Common.Repository;
    using Data.Models;
    using ViewModels.Threads;

    public class ForumsController : Controller
    {
        private readonly IDeletableEntityRepository<Forum> forums;
        private readonly IDeletableEntityRepository<Thread> threads;

        public ForumsController(IDeletableEntityRepository<Forum> forums, IDeletableEntityRepository<Thread> threads)
        {
            this.forums = forums;
            this.threads = threads;
        }

        // GET: Forums
        public ActionResult Index(int id)
        {
            var model = this.forums.All().Where(x => x.Id == id).ProjectTo<ThreadsByForumViewModel>().FirstOrDefault();

            model.Threads = this.threads.All().Where(x => x.Forum.Id == id).ProjectTo<ThreadsInformationViewModel>().ToList();

            return View(model);
        }
    }
}