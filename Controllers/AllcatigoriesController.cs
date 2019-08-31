using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using onlineshop.Models;

namespace onlineshop.Controllers
{
    public class AllcatigoriesController : Controller
    {
        myshopContext pro1 = null;
        IHostingEnvironment host = null;

        public AllcatigoriesController(myshopContext obj, IHostingEnvironment obj2)
        {
            pro1 = obj;
            host = obj2;
        }

      public IActionResult shirt()
        {
            IList<Products> p = pro1.Products.Where(a => a.Categories == "shirt").ToList();

            return View(p);
        }
        public IActionResult tshirt()
        {
            IList<Products> p = pro1.Products.Where(a => a.Categories == "tshirt").ToList();

            return View(p);
        }
        public IActionResult polos()
        {
            IList<Products> p = pro1.Products.Where(a => a.Categories == "polos").ToList();

            return View(p);
        }
        public IActionResult pents()
        {
            IList<Products> p = pro1.Products.Where(a => a.Categories == "pents").ToList();

            return View(p);
        }
        public IActionResult shoes()
        {
            IList<Products> p = pro1.Products.Where(a => a.Categories == "shoes").ToList();

            return View(p);
        }

    }
}