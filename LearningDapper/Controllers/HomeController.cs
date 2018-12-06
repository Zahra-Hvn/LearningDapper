using LearningDapper.Models;
using LearningDapper.Repository;
using System.Web.Mvc;

namespace LearningDapper.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        UserRepo repo;
        public HomeController()
        {
            repo = new UserRepo();
        }
        // GET: Home
        public ActionResult Index()
        {

            return View(repo.GetUsers());
        }
        public ActionResult Edit(int id)
        {
            var user = repo.GetUserbyId(id);
            if (user != null)
            {
                return View(user);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (repo.Update(user))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (repo.Create(user))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}