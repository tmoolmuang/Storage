using Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Storage.ViewModels
{
    public class ProductProductTypeViewModel
    {
        public IEnumerable<ProductType> ProductTypes { get; set; }
        public Product Product { get; set; }
    }
}