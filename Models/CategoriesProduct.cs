using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class CategoriesProduct
    {
        public List<Category> categories { get; set; }
        public Product Product { get; set; }

        public CategoriesProduct(List<Category> categories, Product product)
        {
            this.categories = categories;
            Product = product;
        }
    }
}
