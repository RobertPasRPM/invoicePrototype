using System;
using System.Collections.Generic;
using InvoicePrototype.Models;

namespace InvoicePrototype.DataAccess
{
    public interface IDataAccess
    {
        IEnumerable<Item> GetData();
    }
}
