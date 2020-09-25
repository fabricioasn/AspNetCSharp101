using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//trimed product list get/readable view model 

namespace ShopAPI.ViewModels.ProductViewModel
{
    public class ProductViewModelList
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public string Category { get; set; }
    }
}
