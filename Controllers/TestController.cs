using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using onlineshop.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace onlineshop.Controllers
{
    [Route("api/[controller]")]
    
    public class TestController : Controller
    {
        myshopContext pro3;
        public TestController(myshopContext db )
        {

            pro3 = db;

        }

        public String  index(String name)
        {

            // Customer c = pro3.Customer.SingleOrDefault();
            //return Json(c);
            return name;
        }
            
            
            // GET: api/<controller>
        [HttpPost]
        public  String login([FromBody]Customer user)
        {
            Customer c=pro3.Customer.Where(a => a.CustomerEmail == user.CustomerEmail).SingleOrDefault();
            if (c != null)
                return JsonConvert.SerializeObject( "loginsuccess");
            else
            {
                return JsonConvert.SerializeObject("loginnotsuccess");
            }
        }
      
        


    }
}
