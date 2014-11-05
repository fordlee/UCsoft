using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCsoft.Common;

namespace UCsoft.Web.Areas.Customer.Controllers
{
    public class CusBaseController : Controller
    {
        //
        // GET: /Customer/CusBase/

        public ActionResult List()
        {
             return View("List");
        }

    }
}
