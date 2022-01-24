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
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adm = new AdminManager(new EfAdminDal());
        RoleManager rm = new RoleManager(new EfRoleDal());
        public ActionResult Index()
        {
            var values = adm.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AdminAdd()
        {
            List<SelectListItem> valueRole = (from x in rm.GetRole()
                                             select new SelectListItem
                                             {
                                                 Text = x.RoleName,
                                                 Value = x.RoleId.ToString()
                                             }).ToList();
            ViewBag.role = valueRole;
            return View();
        }

        [HttpPost]
        public ActionResult AdminAdd(Admin p)
        {
            adm.AdminAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminEdit(int id)
        {
            List<SelectListItem> valueRole = (from x in rm.GetRole()
                                              select new SelectListItem
                                              {
                                                  Text = x.RoleName,
                                                  Value = x.RoleId.ToString()
                                              }).ToList();
            ViewBag.role = valueRole;
            var value = adm.GetByID(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult AdminEdit(Admin p)
        {
            adm.AdminUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult AdminDelete(int id)
        {
            var adminvalue = adm.GetByID(id);
            adminvalue.AdminStatus = !adminvalue.AdminStatus;
            adm.AdminUpdate(adminvalue);
            return RedirectToAction("Index");
        }
    }
}