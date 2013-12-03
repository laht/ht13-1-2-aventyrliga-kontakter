using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AdventurousContacts.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        [ActionName("404")]
        public ActionResult HTTP404()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View("NotFound");
        }
    }
}
