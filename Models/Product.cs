using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspShop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]        
        public int Code { get; set; }
        [Required]
        public double Price { get; set; }
        [MaxLength(128)]
        public string Brand { get; set; }
        public byte[] Image { get; set; }
        [MaxLength(2048)]
        public string Description { get; set; }

        public Category Category { get; set; }

        public string GetImage()
        {
            return "data:image / jpeg; base64," + @Convert.ToBase64String(this.Image);
        }
    }
}
