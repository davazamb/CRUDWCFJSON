using CRUDWCFJSON.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDWCFJSON.WEB.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductServiceClient psc = new ProductServiceClient();
            ViewBag.listProducts = psc.FindAll();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            return View("Create");
        }
    }
}