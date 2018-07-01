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
            var items = _dataAccess.GetData<Item>("DataAccess/Mockups/Items.json");
            var viewModel = new FullAndPartialViewModel();
            viewModel.Items = items;

            return View(viewModel);
        }

        public ActionResult InvoiceTable(string itemIds){
            var items = new List<Item>();
            var ids = itemIds.Split(';');
            decimal totalTax = 0;
            decimal total = 0;
            decimal discount = 0;
            var index = 1;
            foreach(var id in ids){
                var innerId = 0;
                var quantity = 1;
                var tempVariable = string.Empty;

                if(id.Contains("-")){
                    quantity = Int32.Parse(id.Split('-')[1]);
                    tempVariable = id.Replace("-" + quantity, string.Empty);
                }else{
                    tempVariable = id;
                }

                if(Int32.TryParse(tempVariable, out innerId)){
                    var item = _dataAccess.GetItem<Item>("DataAccess/Mockups/Items.json",innerId);
                    if(quantity!=1){
                        item = new Item()
                        {
                            Id = item.Id,
                            Description = item.Description,
                            Quantity = quantity,
                            UnitPrice = item.UnitPrice,
                            Tax = item.Tax,
                            IsPromotionItem=item.IsPromotionItem,
                            PromotionDiscount=item.PromotionDiscount
                        };
                    }

                    item.Index = index;
                    items.Add(item);
                    totalTax += item.TotalTax;
                    discount += item.Discount;
                    total += item.Total;
                    index += 1;
                }
            }

            var viewModel = new FullAndPartialViewModel();
            viewModel.InvoiceRows = items;
            viewModel.TotalTax = totalTax;
            ProcessTotal(viewModel, total, discount);
            return PartialView(viewModel);
        }

        public ActionResult GenerateInvoice(string invoiceTable){
            ViewBag.InvoiceTable = invoiceTable;
            return View("InvoiceTemplate");
        }

        private void ProcessTotal(FullAndPartialViewModel viewModel, decimal total, decimal discount){
            var rangeList = _dataAccess.GetData<RangeAndDiscount>("DataAccess/Mockups/RangeList.json");
            var closest = rangeList.Aggregate((x, y) => Math.Abs(x.Range - total) < Math.Abs(y.Range - total) ? x : y);
            var rangeDiscount = (total * closest.Discount) / 100;
            total = total - rangeDiscount;
            viewModel.Total = total;
            viewModel.Discount = discount+rangeDiscount;
        }
    }
}
