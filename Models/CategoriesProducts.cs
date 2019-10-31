using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class CategoriesProducts
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }

        public CategoriesProducts(List<Category> categories, List<Product> products)
        {
            Categories = categories;
            Products = products;
        }
    }
}
