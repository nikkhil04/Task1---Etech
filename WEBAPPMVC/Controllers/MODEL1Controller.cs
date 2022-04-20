using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WEBAPPMVC.Context;
using WEBAPPMVC.Models;

namespace WEBAPPMVC.Controllers
{
    public class MODEL1Controller : Controller
    {
        private WEBAPPMVCContext1 db = new WEBAPPMVCContext1();

        // GET: MODEL1
        public ActionResult Index()
        {
            return View(db.MODELs.ToList());
        }

        // GET: MODEL1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODEL1 mODEL1 = db.MODELs.Find(id);
            if (mODEL1 == null)
            {
                return HttpNotFound();
            }
            return View(mODEL1);
        }

        // GET: MODEL1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MODEL1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,itemName,itemPrice,itemImage")] MODEL1 mODEL1)
        {

            if (ModelState.IsValid)
            {

                    string fileName = Path.GetFileName(DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N")) + ".png";
                    string path = Path.Combine(Server.MapPath("~/Extra/Images"), fileName);
                    mODEL1.itemImage.SaveAs(path);
                    mODEL1.itemImagestring = "/Extra/Images" + fileName;
                db.MODELs.Add(mODEL1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mODEL1);
        }

        // GET: MODEL1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODEL1 mODEL1 = db.MODELs.Find(id);
            if (mODEL1 == null)
            {
                return HttpNotFound();
            }
            return View(mODEL1);
        }

        // POST: MODEL1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,itemName,itemPrice,itemImage")] MODEL1 mODEL1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mODEL1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mODEL1);
        }

        // GET: MODEL1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODEL1 mODEL1 = db.MODELs.Find(id);
            if (mODEL1 == null)
            {
                return HttpNotFound();
            }
            return View(mODEL1);
        }

        // POST: MODEL1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MODEL1 mODEL1 = db.MODELs.Find(id);
            db.MODELs.Remove(mODEL1);
            db.SaveChanges();
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
