using System;
using System.Collections.Generic;

namespace InvoicePrototype.Models
{
    public class FullAndPartialViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<Item> InvoiceRows { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalTax { get; set; }
        public decimal Total { get; set; }
        public decimal AmountToPay => Total - Discount;
    }
}
