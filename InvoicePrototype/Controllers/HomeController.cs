using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using InvoicePrototype.DataAccess;

namespace InvoicePrototype.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dataAccess=new JsonDataAccess();
            var items = dataAccess.GetData();

            return View();
        }
    }
}
