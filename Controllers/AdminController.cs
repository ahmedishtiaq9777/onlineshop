using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using onlineshop.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace onlineshop.Controllers
{
    public class AdminController : Controller
    {
        myshopContext pro1 = null;
        IHostingEnvironment host = null;

        public AdminController(myshopContext obj,IHostingEnvironment obj2)
        {
            pro1 = obj;
            host = obj2;
        }
        public IActionResult Adminlogin()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Adminlogin(Adminlogin obj)
        {

            Adminlogin b=  pro1.Adminlogin.Where(a => a.Email == obj.Email && a.Password == obj.Password).SingleOrDefault();
            if (b != null)
            {
                HttpContext.Session.SetInt32("id", 1);

                return RedirectToAction("productlist");
            }
               else
               {
                ViewBag.error = "Your Username or password is incurrect";
                return View("Adminlogin");
               }
            }
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Adminlogin");

        }
        public IActionResult Addproduct()
        {
            if (HttpContext.Session.GetInt32("id") == 1)
            {
                ViewBag.procode = "yoyo";
                return View();
            }
            else
            {
                return  RedirectToAction("Adminlogin");
            }
                    
               
        }
        [HttpPost]
        public IActionResult Addproduct(Products obj,IList<IFormFile> img)
        {
            if (HttpContext.Session.GetInt32("id") == 1)
            {

                string[] array = new string[3];
                int a = 0;
                string path = host.WebRootPath + "/img/products/";
                foreach (var i in img)
                {
                    
                   
                    string fname= Path.GetFileName(i.FileName);
                     i.CopyTo(new System.IO.FileStream(path + fname, System.IO.FileMode.Create));
                    array[a] = "/img/products/" + fname;
                    a++;
                }



                obj.ProductImg1 = array[0];
                obj.ProductImg2 = array[1];
                obj.ProductImg3 = array[2];

                pro1.Products.Add(obj);
                
                pro1.SaveChanges();
                Products p = new Products();
                try
                {
                     p = pro1.Products.Where(b => b.ProductCode == obj.ProductCode).SingleOrDefault();
                } catch (Exception ex)
                {
                    ViewBag.error = ex.Message;
                }

                //HttpContext.Session.SetString("proid", obj.ProductCode);
                //    Console.WriteLine("product id:" + obj.ProductId);
                //ViewBag.pro = "procode";
                HttpContext.Session.SetInt32("proid", p.ProductId);
                TempData["proid"] = p.ProductId;

                    return RedirectToAction("prosizecolor");

                
               
                   
            }
            else
            {
                return RedirectToAction("Adminlogin");

            }
            }
        public IActionResult prosizecolor()
        {


            return View(); }
        [HttpPost]
        public IActionResult prosizecolor(SizeColor obj)
        {
            try
            {
             //   obj.ProductId=HttpContext.Session.GetInt32("product_id");
                
                pro1.SizeColor.Add(obj);
                pro1.SaveChanges();
                TempData["proid"] = HttpContext.Session.GetInt32("proid");
                return RedirectToAction("prosizecolor");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                ViewBag.error = e.Message;
                return View();
            }
             }

        public IActionResult Productlist()
        {
            try
            {
                if (HttpContext.Session.GetInt32("id") == 1)
                {
                    HttpContext.Session.Remove("procode");
                    IList<Products> list = pro1.Products.ToList();
                    return View(list);
                }
                else
                {
                    return RedirectToAction("Adminlogin");
                }
            }
            catch(Exception e)
            {
                ViewBag.error = e.Message;
                return View();
            }
        }
        [HttpGet]
        public IActionResult Deleteproduct(String procode)
        {

            if (HttpContext.Session.GetInt32("id") == 1)
            {
                Products p = pro1.Products.Where(a => a.ProductCode == procode).SingleOrDefault();
                return View(p);
            }
            else {
                return RedirectToAction("Adminlogin");
                 }
        }
      
        public IActionResult Confirmdelete(String  procode)
        {
            if (HttpContext.Session.GetInt32("id") == 1)
            {
                Products obj = pro1.Products.Where(a => a.ProductCode == procode).SingleOrDefault();
                pro1.Remove(obj);
                pro1.SaveChanges();

                return RedirectToAction("Productlist");
            }
            else { return RedirectToAction("Adminlogin"); }
        }
        public IActionResult Editproduct(string procode)
        {
            if (HttpContext.Session.GetInt32("id") == 1)
            {
                Products p = pro1.Products.Where(a => a.ProductCode == procode).SingleOrDefault();
                return View(p);
            }
            else
            {
                return RedirectToAction("Adminlogin");
            }
            }
        [HttpPost]
        public IActionResult Editproduct(Products obj,IList<IFormFile> img)
        {
           string[] arr = new  string[3];
            int counter = 0;
            string path = host.WebRootPath + "/img/products/";
            foreach(var i in img)
            {
                i.CopyTo(new System.IO.FileStream(path + i.FileName, System.IO.FileMode.Create));
                arr[counter] = "/img/products/" + i.FileName;
                counter++;

            }
            Products p = pro1.Products.Where(a => a.ProductCode == obj.ProductCode).SingleOrDefault();
            p.ProductTitle = obj.ProductTitle;
            p.ProductCode = obj.ProductCode;
            p.ProductDisc = obj.ProductDisc;
            p.Brand = obj.Brand;
            p.ProductPrice = obj.ProductPrice;
            p.Type = obj.Type;
            pro1.SaveChanges();
            return RedirectToAction("Productlist");
        }

        public IActionResult Allproducts(int id)
        {
            return View();
        }

    }
}