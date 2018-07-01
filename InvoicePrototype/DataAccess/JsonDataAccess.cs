using System;
using System.Collections.Generic;
using System.Linq;
using InvoicePrototype.Models;
using Newtonsoft.Json;
using System.IO;

namespace InvoicePrototype.DataAccess
{
    public class JsonDataAccess : IDataAccess
    {
        public IEnumerable<Item> GetData(){
            using(StreamReader reader = new StreamReader("DataAccess/Mockups/MOCK_DATA-2.json"))
            {
                string json = reader.ReadToEnd();
                var items = JsonConvert.DeserializeObject<IEnumerable<Item>>(json);
                return items;
            }
        }

        public Item GetItem(int itemId){
            using (StreamReader reader = new StreamReader("DataAccess/Mockups/MOCK_DATA-2.json"))
            {
                string json = reader.ReadToEnd();
                var items = JsonConvert.DeserializeObject<IEnumerable<Item>>(json);
                return items.FirstOrDefault(x => x.Id == itemId);
            }
        }
    }
}
