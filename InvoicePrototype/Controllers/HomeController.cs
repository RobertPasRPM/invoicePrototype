using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using InvoicePrototype.DataAccess;
using InvoicePrototype.Models;

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
            var items = _dataAccess.GetData();
            var viewModel = new FullAndPartialViewModel();
            viewModel.Items = items;

            return View(viewModel);
        }

        public ActionResult InvoiceTable(string itemId){
            var viewModel = new FullAndPartialViewModel();
            return PartialView(viewModel);
        }
    }
}
