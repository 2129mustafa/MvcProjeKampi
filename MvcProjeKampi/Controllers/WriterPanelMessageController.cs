﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer;
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
    public class WriterPanelMessageController : BaseController
    {
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
      
        public ActionResult Inbox()
        {
            string mail = (string)Session["WriterMail"];
           
            var messagelist = mm.GetListInbox(mail);
            return View(messagelist);
        }

        public ActionResult Sendbox()
        {
            string mail = (string)Session["WriterMail"];
            var messagelist = mm.GetListSendbox(mail);
            return View(messagelist);
        }

        public ActionResult MessageListMenu()
        {
            return PartialView();
        }

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
            string sendermail = (string)Session["WriterMail"];
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