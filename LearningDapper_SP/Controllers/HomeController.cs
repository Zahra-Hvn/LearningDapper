using LearningDapper_SP.Models;
using LearningDapper_SP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningDapper_SP.Controllers
{
    public class HomeController : Controller
    {
        UserRepo userRepo;
        public HomeController()
        {
            userRepo = new UserRepo();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View(userRepo.GetUsers());
        }
        public ActionResult Edit(int id)
        {
            var model = userRepo.GetUserById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (userRepo.UpdateUser(user))
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }
        public ActionResult Delete(int id)
        {
            userRepo.DeleteUser(id);
            return RedirectToAction("Index");
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(User user)
        {
            if (userRepo.InsertUser(user))
            {
                return RedirectToAction("Index");
            }
            return View(user);

        }
    }
}