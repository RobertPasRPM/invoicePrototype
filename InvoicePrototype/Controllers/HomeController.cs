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

        public ActionResult InvoiceTable(string itemIds){
            var items = new List<Item>();
            var ids = itemIds.Split(';');
            var index = 1;
            foreach(var id in ids){
                var innerId = 0;
                if(Int32.TryParse(id,out innerId)){
                    var item = _dataAccess.GetItem(innerId);
                    item.Index = index;
                    items.Add(item);
                    index += 1;
                }
            }

            var viewModel = new FullAndPartialViewModel();
            viewModel.InvoiceRows = items;
            return PartialView(viewModel);
        }
    }
}
