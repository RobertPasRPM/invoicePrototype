using System;
using System.Collections.Generic;
using InvoicePrototype.Models;

namespace InvoicePrototype.DataAccess
{
    public interface IDataAccess
    {
        IEnumerable<T> GetData<T>(string location);
        T GetItem<T>(string location, int itemId) where T : Item;
    }
}
