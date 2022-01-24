using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager ctm= new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            var values = cm.GetList().GroupBy(x => x.CategoryName);
            List<CategoryClass> ct = new List<CategoryClass>();
            ct = values.Select(x => new CategoryClass
            {
                CategoryName = x.Key,
                CategoryCount = x.Count()
            }).ToList();
            //ct.Add(new CategoryClass()
            //{
            //    CategoryName="Yazılım",
            //    CategoryCount=4
            //});
            //ct.Add(new CategoryClass()
            //{
            //    CategoryName = "Tiyatro",
            //    CategoryCount = 2
            //});
            //ct.Add(new CategoryClass()
            //{
            //    CategoryName = "Dizi",
            //    CategoryCount = 8
            //});
            //ct.Add(new CategoryClass()
            //{
            //    CategoryName = "Spor",
            //    CategoryCount = 15
            //});
            return ct;
        }
        public ActionResult LineChart()
        {
            return View();
        }
        public ActionResult HeadingChart()
        {
            return Json(HeadList(), JsonRequestBehavior.AllowGet);
        }
        public List<HeadingcClass> HeadList()
        {
            var values = hm.GetList().GroupBy(x => x.Category.CategoryName);
            List<HeadingcClass> headingClasses = new List<HeadingcClass>();
            headingClasses = values.Select(x => new HeadingcClass
            {
                CategoryName = x.Key,
                HeadingCount = x.Count()
            }).ToList();
            return headingClasses;
        }

        public ActionResult ColumnChart()
        {
            return View();
        }

        public ActionResult ContentChart()
        {
            return Json(ContentList(), JsonRequestBehavior.AllowGet);
        }

        public List<ContentClass> ContentList()
        {
            var values = ctm.GetAllList().GroupBy(x => x.Heading.HeadingName);
            List<ContentClass> contentClasses = new List<ContentClass>();
            contentClasses = values.Select(x => new ContentClass
            {
                HeadingName = x.Key,
                ContentCount = x.Count()
            }).ToList();
            return contentClasses;
        }

    }
}