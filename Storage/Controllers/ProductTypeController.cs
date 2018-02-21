using Storage.Context;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Storage.Controllers
{
    public class ProductTypeController : Controller
    {
        private StorageContext _db;

        public ProductTypeController()
        {
            _db = new StorageContext();
        }

        // GET: ProductType
        public ActionResult Index()
        {
            return View(_db.ProductTypes.ToList());
        }

        // GET: ProductType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return HttpNotFound();
            }
            return View(productType);
        }

        // GET: ProductType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductType/Create
        [HttpPost]
        public ActionResult Create(ProductType productType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.ProductTypes.Add(productType);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(productType);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return HttpNotFound();
            }
            return View(productType);
        }

        // POST: ProductType/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductType productType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(productType).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(productType);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return HttpNotFound();
            }
            return View(productType);
        }

        // POST: ProductType/Delete/5
        [HttpPost]
        public ActionResult Delete(ProductType productType)
        {
            try
            {
                ProductType p = new ProductType();
                if (ModelState.IsValid)
                {
                    p = _db.ProductTypes.Find(productType.Id);
                    if (p == null)
                    {
                        return HttpNotFound();
                    }
                    _db.ProductTypes.Remove(p);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(p);
            }
            catch
            {
                return View();
            }
        }
    }
}
