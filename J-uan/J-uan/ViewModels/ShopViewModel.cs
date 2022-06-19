using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using J_uan.Models;

namespace J_uan.ViewModels
{
    public class ShopViewModel
    {
        public List<Products> Products { get; set; }
        public List<ProductImages> ProductImages { get; set; }
        public List<Categories> Categories { get; set; }
    }
}
