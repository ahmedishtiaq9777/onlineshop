using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using onlineshop.Models;
using Microsoft.DotNet;


namespace onlineshop.Controllers
{
    public class HomeController : Controller
    {
        myshopContext pro = null;

        public HomeController(myshopContext obj)
        {
            pro = obj;
        }
        public IActionResult Index()
        {

            

            allinone all = new allinone();
           IList<Products> p= pro.Products.ToList<Products>();
           /* IList<Products> p = pro.Products.OrderByDescending(x=>x.ProductId).Take()*/
          

            all.products = p;
           // ViewBag.data = 1212;
            return View(all);

        }


        public IActionResult login()
        {
            return View();
        }


        public IActionResult register()
        {
            return View();
        }
        public IActionResult Error()
        {
            
            return View();
        }
        public IActionResult aboutus()
        {
            return View();
        }
        public IActionResult productdetail(String procode)
        {
            try
            {
                Products obj = pro.Products.Where(a => a.ProductCode == procode).SingleOrDefault();
                List<SizeColor> sc = pro.SizeColor.Where(a => a.ProductId == obj.ProductId).ToList();
                var t = new Tuple<Products, List<SizeColor>>(obj, sc);
                return View(t);
            }
            catch(Exception e)
            {
                ViewBag.error = e.Message;
                return View();
            }
        }
        public IActionResult about()
        {
            
            return View("about");
        }
        [HttpPost]
        public IActionResult about(value v)
        {
            int sqresult = v.val * v.val;

            return Json(new { result = sqresult });
        }
        public IActionResult temp()
        {
            TempData["procode"] = "yoyo";

          return  RedirectToAction("about");
        }
        public PartialViewResult hello()
        {

            return PartialView();
        }



      
    }
}
