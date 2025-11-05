using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewCoreProject.Models
{
    public class Shop
    {
        public List<Category>? Cate { get; set; }
        public List<Product>? Pro { get; set; } 
    }
}  