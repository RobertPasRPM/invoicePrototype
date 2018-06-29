using System;
namespace InvoicePrototype.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Tax { get; set; }
        public bool IsPromotionItem { get; set; }
        public int PromotionDiscount { get; set; }
    }
}
