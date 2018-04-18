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

        public ActionResult AjaxDemo()
        {
            return View();
        }

        public ActionResult _index()
        {
            List<Product> products = new List<Product>();
            products = _db.Products.ToList();
                       
            return PartialView(products);
        }

        public ActionResult _delete(int id)
        {
            Product product = _db.Products.Find(id);
            _db.Products.Remove(product);
            _db.SaveChanges();

            List<Product> products = new List<Product>();
            products = _db.Products.ToList();
            return PartialView("_index", products);
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductProductTypeViewModel pp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Products.Add(pp.Product);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }

                //fill productypes for re-displaying create form when fail
                pp.ProductTypes = _db.ProductTypes.ToList();
                return View(pp);
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
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductProductTypeViewModel pp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(pp.Product).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                //fill productypes for re-displaying edit form when fail
                pp.ProductTypes = _db.ProductTypes.ToList();
                return View(pp);
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
        [ValidateAntiForgeryToken]
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
