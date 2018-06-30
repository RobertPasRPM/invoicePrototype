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
        private readonly IDataAccess _dataAccess;

        public HomeController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public ActionResult Index()
        {
            var _dataAccess = new JsonDataAccess();
            var items = _dataAccess.GetData();

            return View();
        }
    }
}
