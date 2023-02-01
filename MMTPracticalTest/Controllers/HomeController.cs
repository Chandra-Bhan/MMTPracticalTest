using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MMTPracticalTest.Models;

namespace MMTPracticalTest.Controllers
{
    public class HomeController : Controller
    {
        private mmtdatabaseEntities1 db = new mmtdatabaseEntities1();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.mmt_table.ToList());
        }

        [HttpPost]
        public ActionResult Index(mmt_table mmt_table)
        {
            if (ModelState.IsValid)
            {
                if (mmt_table.agree == true)
                {
                    db.mmt_table.Add(mmt_table);
                    db.SaveChanges();
                    TempData["dataSubmited"] = "<script>alert('Submited Successfully');</script>";
                    return View(db.mmt_table.ToList());


                }
                else
                {
                    TempData["agreeView"] = "<script>alert('Please check the agree');</script>";

                }
               
            }
            else
            {
                TempData["dataSubmited"] = "<script>alert('Please Fill the right data according to warning.');</script>";

            }
            return View(db.mmt_table.ToList());
        }


        public ActionResult Index1()
        {
            var state = db.state_table.ToList();
            var cities = db.city_table.ToList();

            ViewBag.States = new SelectList(state, "stateid", "statename");
            ViewBag.Cities = new SelectList(cities, "cityid", "cityname");
            return PartialView("_CreateView");

        }


        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mmt_table mmt_table = db.mmt_table.Find(id);
            if (mmt_table == null)
            {
                return HttpNotFound();
            }
            return View(mmt_table);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            
            var state = db.state_table.ToList();
            var cities = db.city_table.ToList();

            ViewBag.States = new SelectList(state, "stateid", "statename");
            ViewBag.Cities = new SelectList(cities, "cityid", "cityname");
            return View();
           
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,email,phoneno,address,state,city")] mmt_table mmt_table)
        {
            if (ModelState.IsValid)
            {
                if (mmt_table.agree == true)
                {
                   
                    mmt_table.state = ViewBag.States.Text.ToString();
                    mmt_table.city = ViewBag.Cities.Text.ToString();
                    db.mmt_table.Add(mmt_table);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["agreeView"] = "<script>alert('Please check the agree');</script>";
                    return View();
                }
            }

            return View(mmt_table);
        }


        public ActionResult Create1(int stateid)
        {


            var state = db.state_table.ToList();

            var citiesRow = db.city_table.Where(model => model.sid == stateid).ToList();
            ViewBag.States = new SelectList(state, "stateid", "statename");

            ViewBag.Cities = new SelectList(citiesRow, "cityid", "cityname");


            return PartialView("_CitiesV");

        }

        [HttpPost]
        public void CreateAdd([Bind(Include = "id,name,email,phoneno,address,state,city")] mmt_table mmt_table)
        {
            if (ModelState.IsValid)
            {
                if (mmt_table.agree == true)
                {
                    db.mmt_table.Add(mmt_table);
                    db.SaveChanges();
                    TempData["dataSubmited"] = "<script>alert('Submited Successfully');</script>";

                }
                else
                {
                    TempData["agreeView"] = "<script>alert('Please check the agree');</script>";
                   
                }
            }
            //return RedirectToAction("Index");
            //return View(mmt_table);
        }




        public ActionResult Edit1(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mmt_table mmt_table = db.mmt_table.Find(id);
            if (mmt_table == null)
            {
                return HttpNotFound();
            }

            var state = db.state_table.ToList();
            var cities = db.city_table.ToList();

            ViewBag.States = new SelectList(state, "stateid", "statename");
            ViewBag.Cities = new SelectList(cities, "cityid", "cityname");
            return PartialView("_EditView",mmt_table);

        }


        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mmt_table mmt_table = db.mmt_table.Find(id);
            if (mmt_table == null)
            {
                return HttpNotFound();
            }
            return View(mmt_table);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,email,phoneno,address,state,city")] mmt_table mmt_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mmt_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mmt_table);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mmt_table mmt_table = db.mmt_table.Find(id);
            if (mmt_table == null)
            {
                return HttpNotFound();
            }
            return View(mmt_table);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mmt_table mmt_table = db.mmt_table.Find(id);
            db.mmt_table.Remove(mmt_table);
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
