using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hakutsuru.Models;

namespace hakutsuru.Controllers
{
    public class PcInfoController : Controller
    {
        private PcInfoDBContext db = new PcInfoDBContext();

        // GET: PcInfo
        public ActionResult Index()
        {
            return View(db.PcInfos.ToList());
        }

        // GET: PcInfo/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PcInfo pcInfo = db.PcInfos.Find(id);
            if (pcInfo == null)
            {
                return HttpNotFound();
            }
            return View(pcInfo);
        }

        // GET: PcInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PcInfo/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ControlNumber,IpAddress,Use,Type,ModelNumber,UserName,PcName,Remarks1,Remarks2")] PcInfo pcInfo)
        {
            if (ModelState.IsValid)
            {
                db.PcInfos.Add(pcInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pcInfo);
        }

        // GET: PcInfo/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PcInfo pcInfo = db.PcInfos.Find(id);
            if (pcInfo == null)
            {
                return HttpNotFound();
            }
            return View(pcInfo);
        }

        // POST: PcInfo/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ControlNumber,IpAddress,Use,Type,ModelNumber,UserName,PcName,Remarks1,Remarks2")] PcInfo pcInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pcInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pcInfo);
        }

        // GET: PcInfo/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PcInfo pcInfo = db.PcInfos.Find(id);
            if (pcInfo == null)
            {
                return HttpNotFound();
            }
            return View(pcInfo);
        }

        // POST: PcInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PcInfo pcInfo = db.PcInfos.Find(id);
            db.PcInfos.Remove(pcInfo);
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
