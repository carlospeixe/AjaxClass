using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AjaxExample.Models;
using System.IO;

namespace AjaxExample.Controllers
{
    public class BrandsController : Controller
    {
        private Entities db = new Entities();

        // GET: Brands
        public async Task<ActionResult> Index()
        {
            return View(await db.Brands.OrderBy(b => b.Name).ToListAsync());
        }

        // GET: Brands/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = await db.Brands.FindAsync(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // GET: Brands/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AddBrand()
        {
            Brand brand = new Brand();
            return View(brand);
        }

        // POST: Brands/Add
        [HttpPost]
        public async Task<ActionResult> AddBrand(Brand brand)
        {
            

            if (brand.BrandImage != null)
            {
                string filename = Path.GetFileNameWithoutExtension(brand.BrandImage.FileName);
                string extension = Path.GetExtension(brand.BrandImage.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                brand.ImagePath = "~/Images/Brands/" + filename;
                string path = Path.Combine(Server.MapPath("~/Images/Brands/"), filename);
                brand.BrandImage.SaveAs(path);
            
                db.Brands.Add(brand);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else {
                return View();
            }
            

            
        }

        // POST: Brands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Brand brand)
        {

            if (ModelState.IsValid)
            {
                db.Brands.Add(brand);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(brand);
        }

        // GET: Brands/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = await db.Brands.FindAsync(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        [HttpPost]
        public async Task<ActionResult> EditBrand(Brand brand)
        {
            if (brand.BrandImage != null)
            {
                string filename = Path.GetFileNameWithoutExtension(brand.BrandImage.FileName);
                string extension = Path.GetExtension(brand.BrandImage.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                brand.ImagePath = "~/Images/Brands/" + filename;
                string path = Path.Combine(Server.MapPath("~/Images/Brands/"), filename);
                brand.BrandImage.SaveAs(path);

                db.Entry(brand).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,ImagePath")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        // GET: Brands/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = await db.Brands.FindAsync(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Brand brand = await db.Brands.FindAsync(id);
            db.Brands.Remove(brand);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
