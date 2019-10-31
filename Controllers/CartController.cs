using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMAPApplication.Common;
using Microsoft.AspNetCore.Mvc;
using AspShop.Data;
using AspShop.Models;

namespace AspShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ShopDbContext _context;

        public CartController(ShopDbContext context)
        {            
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = SessionExtensions.GetComplexData<List<Cart>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            }
            else
            {
                ViewBag.total = 0;
            }
            return View(new CategoriesCart(_context.Categories.ToList(), cart));
        }

        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            Product product = new Product();
            if (SessionExtensions.GetComplexData<List<Cart>>(HttpContext.Session, "cart") == null)
            {
                List<Cart> cart = new List<Cart>();
                cart.Add(new Cart(_context.Products.Where(p => p.ProductId == id).ToList().ElementAt(0), 1));
                SessionExtensions.SetComplexData(HttpContext.Session, "cart", cart);
                ViewBag.cartCount = 1;
                ViewData["cartCount"] = 1;
            }
            else
            {
                List<Cart> cart = SessionExtensions.GetComplexData<List<Cart>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Cart(_context.Products.Where(p => p.ProductId == id).ToList().ElementAt(0), 1));
                }
                SessionExtensions.SetComplexData(HttpContext.Session, "cart", cart);
                ViewBag.cartCount = cart.Count;
            }            
            return RedirectToAction("Index", "Home");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Cart> cart = SessionExtensions.GetComplexData<List<Cart>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionExtensions.SetComplexData(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        public IActionResult Order()
        {
            return View("Index");
        }

        private int isExist(int id)
        {
            List<Cart> cart = SessionExtensions.GetComplexData<List<Cart>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}