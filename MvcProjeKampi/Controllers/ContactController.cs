using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using MvcProjeKampi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        MessageManager mm = new MessageManager(new EfMessageDal());
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetById(id);
            return View(contactvalues);
        }

        public PartialViewResult ContactPartial()
        {
           
            ViewBag.deger1 = cm.GetList().Count();
            ViewBag.deger2 = mm.GetListInbox(Mail).Count();
            ViewBag.deger3 = mm.GetListSendbox(Mail).Count();
            ViewBag.deger4 = mm.GetInboxUnReadList(Mail).Count();
            ViewBag.deger5 = mm.GetInboxReadList(Mail).Count();


            //Okundu
            //Gelen Mesajlar


            //Okunmadı


           



            return PartialView();
        }
    }
}