using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutvalue = abm.GetList();
            return View(aboutvalue);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            abm.AboutAdd(about);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var key = abm.GetById(id);
            key.AboutStatus = !key.AboutStatus;
            abm.AboutDelete(key);
            return RedirectToAction("Index");
        }

       public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}