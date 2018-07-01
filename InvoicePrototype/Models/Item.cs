using System;
using Newtonsoft.Json;
namespace InvoicePrototype.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        [JsonProperty("unit_price")]
        public decimal UnitPrice { get; set; }
        public int Tax { get; set; }
        [JsonProperty("is_promotion_item")]
        public bool IsPromotionItem { get; set; }
        [JsonProperty("promotion_discount")]
        public int PromotionDiscount { get; set; }
    }
}
