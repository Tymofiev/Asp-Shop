using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication4.Data;
using WebApplication4.Models;
using Microsoft.AspNetCore.Http;
using IMAPApplication.Common;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopDbContext _context;

        public HomeController(ILogger<HomeController> logger, ShopDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            List<Product> products = _context.Products.ToList();
            return View(new CategoriesProducts(categories, products));
        }

        public IActionResult Category(int? id)
        {
            List<Category> categories = _context.Categories.ToList();
            List<Product> products = _context.Products.Where(p => p.CategoryId == id).ToList();
            return View(new CategoriesProducts(categories, products));
        }

        public IActionResult Product(int? id)
        {
            List<Category> categories = _context.Categories.ToList();
            List<Product> products = _context.Products.Where(p => p.ProductId == id).ToList();
            return View(new CategoriesProducts(categories, products));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
