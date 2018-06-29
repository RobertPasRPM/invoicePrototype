using System;
using System.Collections.Generic;
using InvoicePrototype.Models;
using Newtonsoft.Json;
using System.IO;

namespace InvoicePrototype.DataAccess
{
    public class JsonDataAccess : IDataAccess
    {
        public IEnumerable<Item> GetData(){
            var items = new List<Item>();
            using(StreamReader reader = new StreamReader("DataAccess/Mockups/MOCK_DATA-2.json"))
            {
                string json = reader.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Item>>(json);
            }

            return items;
        }
    }
}
