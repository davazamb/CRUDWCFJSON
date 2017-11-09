using CRUDWCFJSON.WEB.Models;
using CRUDWCFJSON.WEB.ViewModels;
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
        [HttpPost]
        public ActionResult Create(ProductViewModel pvm)
        {
            ProductServiceClient psc = new ProductServiceClient();
            psc.Create(pvm.Product);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            ProductServiceClient psc = new ProductServiceClient();
            psc.Delete(psc.Find(id));
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(string id)
        {
            ProductServiceClient psc = new ProductServiceClient();
            ProductViewModel pvm = new ProductViewModel();
            pvm.Product = psc.Find(id);
            return View("Edit", pvm);
        }
        [HttpPost]
        public ActionResult Edit(ProductViewModel pvm)
        {
            ProductServiceClient psc = new ProductServiceClient();
            psc.Edit(pvm.Product);
            return RedirectToAction("Index");
        }
    }
}