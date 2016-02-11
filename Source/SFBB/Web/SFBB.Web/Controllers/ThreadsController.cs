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
            var currentThread = this.threads.All().Where(x => x.Id == id);

            string userIP = this.Request.ServerVariables["REMOTE_ADDR"];

            if (true)
            {
                
            }

            currentThread.FirstOrDefault().Views++;

            this.threads.SaveChanges();
            

            var thread = currentThread.ProjectTo<ThreadsViewModel>().FirstOrDefault();

            return View(thread);
        }
    }
}