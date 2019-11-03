﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspShop.Models
{
    public class Order
    {        
        [Key]
        [Required]
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<CartItem> Products { get; set; }
    }
}
