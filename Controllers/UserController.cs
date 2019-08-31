using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using onlineshop.Models;

namespace onlineshop.Controllers
{
    public class UserController : Controller
    {
        myshopContext pro2 = null;
        IHostingEnvironment host2 = null;

        public UserController(myshopContext obj, IHostingEnvironment obj2)
        {
            pro2 = obj;
            host2 = obj2;
        }
        public IActionResult checkout()
        { return View(); }

        public IActionResult myorder()
        { return View(); }

        public IActionResult mycart()
        { return View(); }
        [HttpPost]
        public PartialViewResult returnproductinfo(string[] code)
        {
            IList<Products> plist = new List<Products>();
            int index = 0;
            string[] k = null;
            foreach (string i in code)
            {
                
                 k=i.Split('_');
                code[index] = k[0];
                index++;
            }

            //Products[] selectedpro = new Products[]
            //{
            //    foreach(string i in code)
            //{
            //    IList<Products> p
            //}



            //};
            // Console.WriteLine(p[0]);

            try {

                //int index = 0;

                foreach (string i in code)
                {

                    Products p = pro2.Products.Where(a => a.ProductCode == i).SingleOrDefault();
                    plist.Add(p);
                    // index++;
                }
                //Console.Write("kkkk");
                //pro2.Products.Where(a => a.ProductCode == code).Si
                ViewBag.data = 1212;
                
                return PartialView("_cartpartial",plist);
            }
            catch(Exception e)
            {
                ViewBag.data = 1212;
                Console.Write(e.Message);
                return PartialView("_cartpartial");
            }

           
        }
        [HttpPost]
        public IActionResult add_to_cart(string procode)
        {
            int uid = (int)HttpContext.Session.GetInt32("userid");




            /*
            try
            {







            

            int uid = (int)HttpContext.Session.GetInt32("userid");

            
            if(uid!=null)
            {
                   Cart c1= pro2.Cart.Where(a => a.CustomerId == uid).SingleOrDefault();
                   // if(c1!=null)
                    //int cid = (int)HttpContext.Session.GetInt32("cartid");
                    if (c1!= null)
                {

                        Orderitems o = new Orderitems();
                        o.ProductCode = procode;
                        o.
    



                   }
                    else
                    {
                        Cart c = new Cart();
                        c.CustomerId = uid;

                        pro2.Cart.Add(c);
                       Cart c2= pro2.Cart.Where(a => a.CustomerId == c.CustomerId).SingleOrDefault();
                        HttpContext.Session.SetInt32("cartid", c2.CartId);



                    }
                }
                else
                {

                    return RedirectToAction("register");
                }

            }
            catch (Exception e)
            {
                return View();
            }*/
            return View();
        
            
             }
        public IActionResult login()
        {

            return View();

        }
        [HttpPost]
        public IActionResult login(Customer obj)
        {
            Customer c = pro2.Customer.Where(a => a.CustomerEmail == obj.CustomerEmail && a.CustomerPass == obj.CustomerPass).SingleOrDefault();

            if(c!=null)
            { HttpContext.Session.SetInt32("userid", c.CustomerId);
                return RedirectToAction("index", "home", new {area="" });
            }
            else
            { ViewBag.error = "Your Username or password is incurrect";
                return View();
            }
            
        }
        public IActionResult register()
        {
          
                

            return View();
        }
        [HttpPost]
        public IActionResult  register(Customer obj)
        {
            
                Customer c1=pro2.Customer.Where(a => a.CustomerEmail == obj.CustomerEmail).SingleOrDefault();
                if (c1== null)
                {
                    pro2.Customer.Add(obj);
                    pro2.SaveChanges();
                    string email = obj.CustomerEmail;
                    Customer c2 = pro2.Customer.Where(a => a.CustomerEmail == email).SingleOrDefault();

                    HttpContext.Session.SetInt32("id", c2.CustomerId);
                    return RedirectToAction("Index", "Home", new { area = "" });

                }
                else
                {
                    ViewBag.error = "This Email is Allready Taken";
                    return View();
                }
                
                
           
        }
        
        public IActionResult selectedcategory(int id)
        {
            IList<Products> p = null;
            List<string> siZe = null;
            try {
                if (id == 1) { p = pro2.Products.Where(a => a.Categories == "MenPolos").ToList();    ViewBag.category = "MenPolos";
                     siZe = new List<string>(new string[] { "S", "M", "L","XL" }); 
                }
                if (id == 2) { p = pro2.Products.Where(a => a.Categories == "MenShirts").ToList();   ViewBag.category = "MenShirts"; }
                if (id == 3) { p = pro2.Products.Where(a => a.Categories == "MenTshirts").ToList();  ViewBag.category = "MenTshirts"; }
                if (id == 4) { p = pro2.Products.Where(a => a.Categories == "MenDenim").ToList();    ViewBag.category = "MenDenim"; }
                if (id == 5) { p = pro2.Products.Where(a => a.Categories == "MenNonDenim").ToList(); ViewBag.category = "MenNonDenim"; }
                if (id == 6) { p = pro2.Products.Where(a => a.Categories == "MenSweater").ToList();  ViewBag.category = "MenSweater"; }
                if (id == 7) { p = pro2.Products.Where(a => a.Categories == "MenCout").ToList();     ViewBag.category = "MenCout"; }
                if (id == 8) { p = pro2.Products.Where(a => a.Categories == "MenUpper").ToList();    ViewBag.category = "MenUpper"; }
                if (id == 9) { p = pro2.Products.Where(a => a.Categories == "MenJacket").ToList();   ViewBag.category = "MenJacket"; }
                if (id == 10) { p = pro2.Products.Where(a => a.Categories == "MenShoes").ToList();   ViewBag.category = "MenShoes"; }
                if (id == 11) { p = pro2.Products.Where(a => a.Categories == "MenBags").ToList();    ViewBag.category = "MenBags"; }

                if (id == 12) { p = pro2.Products.Where(a => a.Categories == "WomenTops").ToList();   ViewBag.category = "WomenTops"; }
                if (id == 13) { p = pro2.Products.Where(a => a.Categories == "WomenBottom").ToList(); ViewBag.category = "WomenBottom"; }
                if (id == 14) { p = pro2.Products.Where(a => a.Categories == "WomenShowls").ToList(); ViewBag.category = "WomenShowls"; }
                if (id == 15) { p = pro2.Products.Where(a => a.Categories == "WomenSweater").ToList();ViewBag.category = "WomenSweater"; }
                if (id == 16) { p = pro2.Products.Where(a => a.Categories == "WomenCout").ToList();   ViewBag.category = "WomenCout"; }
                if (id == 17) { p = pro2.Products.Where(a => a.Categories == "WomenUpper").ToList();  ViewBag.category = "WomenUpper"; }
                if (id == 18) { p = pro2.Products.Where(a => a.Categories == "WomenJacket").ToList(); ViewBag.category = "WomenJacket"; }
                if (id == 19) { p = pro2.Products.Where(a => a.Categories == "WomenShoes").ToList();  ViewBag.category = "WomenShoes"; }
                if (id == 20) { p = pro2.Products.Where(a => a.Categories == "WomenBags").ToList();   ViewBag.category = "WomenBags"; }

                if (id == 21) { p = pro2.Products.Where(a => a.Categories == "boyKids(1-5)Shirts").ToList();  ViewBag.category = "boyKids(1-5)Shirts"; }
                if (id == 22) { p = pro2.Products.Where(a => a.Categories == "boyKids(1-5)Tshirts").ToList(); ViewBag.category = "boyKids(1-5)Tshirts"; }
                if (id == 23) { p = pro2.Products.Where(a => a.Categories == "boyKids(1-5)Bottom").ToList();  ViewBag.category = "boyKids(1-5)Bottom"; }
                if (id == 24) { p = pro2.Products.Where(a => a.Categories == "boyKids(1-5)Sweater").ToList(); ViewBag.category = "boyKids(1-5)Sweater"; }
                if (id == 25) { p = pro2.Products.Where(a => a.Categories == "boyKids(1-5)Cout").ToList();    ViewBag.category = "boyKids(1-5)Cout"; }
                if (id == 26) { p = pro2.Products.Where(a => a.Categories == "boyKids(1-5)Upper").ToList();   ViewBag.category = "boyKids(1-5)Upper"; }
                if (id == 27) { p = pro2.Products.Where(a => a.Categories == "boyKids(1-5)Jacket").ToList();  ViewBag.category = "boyKids(1-5)Jacket"; }
                if (id == 28) { p = pro2.Products.Where(a => a.Categories == "boyKids(1-5)Shoes").ToList();   ViewBag.category = "boyKids(1-5)Shoes"; }

                if (id == 29) { p = pro2.Products.Where(a => a.Categories == "boyKids(6-12)Shirts").ToList(); ViewBag.category = "boyKids(6-12)Shirts"; }
                if (id == 30) { p = pro2.Products.Where(a => a.Categories == "boyKids(6-12)Tshirts").ToList(); ViewBag.category = "boyKids(6-12)Tshirts"; }
                if (id == 31) { p = pro2.Products.Where(a => a.Categories == "boyKids(6-12)Bottom").ToList(); ViewBag.category = "boyKids(6-12)Bottom"; }
                if (id == 32) { p = pro2.Products.Where(a => a.Categories == "boyKids(6-12)Sweater").ToList(); ViewBag.category = "boyKids(6-12)Sweater"; }
                if (id == 33) { p = pro2.Products.Where(a => a.Categories == "boyKids(6-12)Cout").ToList(); ViewBag.category = "boyKids(6-12)Cout"; }
                if (id == 34) { p = pro2.Products.Where(a => a.Categories == "boyKids(6-12)Upper").ToList(); ViewBag.category = "boyKids(6-12)Upper"; }
                if (id == 35) { p = pro2.Products.Where(a => a.Categories == "boyKids(6-12)Jacker").ToList(); ViewBag.category = "boyKids(6-12)Jacket"; }
                if (id == 36) { p = pro2.Products.Where(a => a.Categories == "boyKids(6-12)Shoes").ToList(); ViewBag.category = "boyKids(6-12)Shoes"; }

                if (id == 37) { p = pro2.Products.Where(a => a.Categories == "GirlKids(1-5)Tops").ToList();ViewBag.category = "GirlKids(1-5)Tops"; }
                if (id == 38) { p = pro2.Products.Where(a => a.Categories == "GirlKids(1-5)Bottom").ToList(); ViewBag.category = "GirlKids(1-5)Bottom"; }
                if (id == 39) { p = pro2.Products.Where(a => a.Categories == "GirlKids(1-5)Tees").ToList(); ViewBag.category = "GirlKids(1-5)Tees"; } 
             if (id == 40) { p = pro2.Products.Where(a => a.Categories == "GirlKids(1-5)Sweater").ToList(); ViewBag.category = "GirlKids(1-5)Sweater"; }
                if (id == 41) { p = pro2.Products.Where(a => a.Categories == "GirlKids(1-5)Cout").ToList(); ViewBag.category = "GirlKids(1-5)Cout"; }
                if (id == 42) { p = pro2.Products.Where(a => a.Categories == "GirlKids(1-5)Upper").ToList(); ViewBag.category = "GirlKids(1-5)Upper"; }
                if (id == 43) { p = pro2.Products.Where(a => a.Categories == "GirlKids(1-5)Jacket").ToList(); ViewBag.category = "GirlKids(1-5)Jacket"; }
                if (id == 44) { p = pro2.Products.Where(a => a.Categories == "GirlKids(1-5)Shoes").ToList(); ViewBag.category = "GirlKids(1-5)Shoes"; }

                if (id == 45) { p = pro2.Products.Where(a => a.Categories == "GirlKids(6-12)top").ToList();    ViewBag.category = "GirlKids(6-12)top"; }
                if (id == 46) { p = pro2.Products.Where(a => a.Categories == "GirlKids(6-12)Bottom").ToList(); ViewBag.category = "GirlKids(6-12)Bottm"; }
                if (id == 47) { p = pro2.Products.Where(a => a.Categories == "GirlKids(6-12)Tees").ToList();   ViewBag.category = "GirlKids(6-12)Tees"; }
                if (id == 48) { p = pro2.Products.Where(a => a.Categories == "GirlKids(6-12)Sweater").ToList();ViewBag.category = "GirlKids(6-12)Sweater"; }
                if (id == 49) { p = pro2.Products.Where(a => a.Categories == "GirlKids(6-12)Cout").ToList();   ViewBag.category = "GirlKids(6-12)Cout"; }
                if (id == 50) { p = pro2.Products.Where(a => a.Categories == "GirlKids(6-12)Upper").ToList();  ViewBag.category = "GirlKids(6-12)Upper"; }
                if (id == 51) { p = pro2.Products.Where(a => a.Categories == "GirlKids(6-12)Jacket").ToList(); ViewBag.category = "GirlKids(6-12)Jacket"; }
                if (id == 52) { p = pro2.Products.Where(a => a.Categories == "GirlKids(6-12)Shoes").ToList();  ViewBag.category = "GirlKids(6-12)Shoes"; }

                if (id == 53) { p = pro2.Products.Where(a => a.Categories == "AccesariesMen").ToList(); ViewBag.category = "AccesariesMen"; }
                if (id == 54) { p = pro2.Products.Where(a => a.Categories == "AccesariesWomen").ToList(); ViewBag.category = "AccesariesWomen"; }


                var t = new Tuple<IList<Products>, List<string>>(p, siZe);
                return View(t);
            }
            catch (Exception e) { ViewBag.error = e.Message; return View(p); }

        }


        public IActionResult shoppingcart()
        {
            return View();
        }
       
        [HttpPost]
        public PartialViewResult viewcartitem(string[] code)
        {
            IList<Products> plist = new List<Products>();
            int index = 0;
            string[] k = null;
            foreach (string i in code)
            {

                k = i.Split('_');
                code[index] = k[0];
                index++;
            }

            try
            {

                //int index = 0;

                foreach (string i in code)
                {

                    Products p = pro2.Products.Where(a => a.ProductCode == i).SingleOrDefault();
                    plist.Add(p);
                    // index++;
                }
                //Console.Write("kkkk");
                //pro2.Products.Where(a => a.ProductCode == code).Si
               // ViewBag.data = 1212;

                return PartialView("_viewcartpartial", plist);
            }
            catch (Exception e)
            {
                ViewBag.data = 1212;
                Console.Write(e.Message);
                return PartialView("_cartpartial");
            }



        }
        }
       
   
}