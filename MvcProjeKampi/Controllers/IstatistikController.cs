using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
       
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        //1) Toplam kategori sayısı
        //2) Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
        //3) Yazar adında 'a' harfi geçen yazar sayısı
        //4) En fazla başlığa sahip kategori adı
        //5) Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
        public ActionResult Index()
        {
            ViewBag.kategorisayisi = cm.GetList().Count();
            ViewBag.yazilimkategorisi = hm.GetList().Where(x => x.CategoryId == 3).Count();
            ViewBag.yazarAharf = wm.GetList().Where(x => x.WriterName.Contains("a") || x.WriterName.Contains("A")).Count();
            ViewBag.enfazlakategori = cm.GetList().Where(x => x.CategoryId == 
            (hm.GetList().GroupBy(h => h.CategoryId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.CategoryName).FirstOrDefault();

            ViewBag.durum_true = cm.GetList().Where(x => x.CategoryStatus == true).Count();
            return View();
        }
    }
}