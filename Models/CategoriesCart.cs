using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspShop.Models
{
    public class CategoriesCart
    {
        public List<Category> Categories { get; set; }
        public List<Cart> Cart { get; set; }

        public CategoriesCart(List<Category> categories, List<Cart> cart)
        {
            Categories = categories;
            Cart = cart;
        }
    }
}
