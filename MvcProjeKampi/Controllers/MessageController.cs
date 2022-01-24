using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using MvcProjeKampi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : BaseController
    {
        // GET: Message

        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
        
        public ActionResult Inbox()
        {
            string mail = (string)Session["AdminUserName"];
            var messagelist = mm.GetListInbox(mail);
            //var messagelist = mm.GetListInbox(Mail);
            return View(messagelist);
        }
        
        public ActionResult Sendbox()
        {
            string mail = (string)Session["AdminUserName"];
            var messagelist = mm.GetListSendbox(mail);
            return View(messagelist);
        }

        //public ActionResult GetInBoxMessageStars(int id)
        //{
        //    var values = mm.GetById(id);
        //    values.Star = true;
        //    mm.MessageUpdate(values);
        //    return View(values);
        //}

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            values.MessageRead = true;
            mm.MessageUpdate(values);
            return View(values);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string sendermail = (string)Session["AdminUserName"];
            ValidationResult results = messagevalidator.Validate(message);
            if (results.IsValid)
            {
                message.SenderMail = sendermail;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(message);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

    }
}