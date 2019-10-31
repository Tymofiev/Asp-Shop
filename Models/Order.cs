using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Cart> Products { get; set; }

        public Order(int id, string userEmail, DateTime date, ICollection<Cart> products)
        {
            Id = id;
            UserEmail = userEmail;
            Date = date;
            Products = products;
        }
    }
}
