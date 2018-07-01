using System;
using System.Collections.Generic;

namespace InvoicePrototype.Models
{
    public class FullAndPartialViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<Item> InvoiceRows { get; set; }
    }
}
