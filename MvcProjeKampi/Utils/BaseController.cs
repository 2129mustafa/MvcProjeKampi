using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Utils
{
    public class BaseController : Controller
    {
        public string Mail { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext context)
        {
            if (Session["AdminUserName"] == null)
            {

            }
            else
            {
                Mail = (string)Session["AdminUserName"];
            }
            base.OnActionExecuting(context);
        }
    }
}