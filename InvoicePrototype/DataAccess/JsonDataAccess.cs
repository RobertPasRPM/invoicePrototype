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
        public IEnumerable<T> GetData<T>(string jsonLocation){
            using(StreamReader reader = new StreamReader(jsonLocation))
            {
                string json = reader.ReadToEnd();
                var items = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
                return items;
            }
        }

        public T GetItem<T>(string jsonLocation, int itemId) where T : Item
        {
            using (StreamReader reader = new StreamReader(jsonLocation))
            {
                string json = reader.ReadToEnd();
                var items = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
                return items.FirstOrDefault(x => x.Id == itemId);
            }
        }
    }
}
