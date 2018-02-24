using Storage.Context;
using Storage.Models;
using Storage.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Storage.Controllers
{
    public class ProductController : Controller
    {
        private StorageContext _db;

        public ProductController()
        {
            _db = new StorageContext();
        }

        // GET: Storage
        public ActionResult Index()
        {
            return View(_db.Products.Include(path => path.ProductType).ToList());
        }

        // GET: Storage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = _db.Products.Find(id);

            var product = _db.Products.Include(path => path.ProductType).Where(p => p.Id == @id).FirstOrDefault<Product>();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Storage/Create
        public ActionResult Create()
        {
            var productCreateViewModel = new ProductProductTypeViewModel();
            var productType = _db.ProductTypes.ToList();
            productCreateViewModel.ProductTypes = productType;
            return View(productCreateViewModel);
        }

        // POST: Storage/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Products.Add(product);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: Storage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var productProductTypeViewModel = new ProductProductTypeViewModel();
            var product = _db.Products.Find(id);
            var productType = _db.ProductTypes.ToList();
            productProductTypeViewModel.Product = product;
            productProductTypeViewModel.ProductTypes = productType;

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(productProductTypeViewModel);
        }

        // POST: Storage/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: Storage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = _db.Products.Find(id);
            var product = _db.Products.Include(path => path.ProductType).Where(p => p.Id == @id).FirstOrDefault<Product>();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Storage/Delete/5
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            //TODO: to be researched further more
            try
            {
                Product p = new Product();
                //if (ModelState.IsValid)
                //{
                    p = _db.Products.Find(product.Id);
                    if (p == null)
                    {
                        return HttpNotFound();
                    }
                    _db.Products.Remove(p);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                //}
                //return View(p);
            }
            catch
            {
                return View();
            }
        }
    }
}
