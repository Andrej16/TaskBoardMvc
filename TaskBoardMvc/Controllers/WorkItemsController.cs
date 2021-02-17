using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TaskBoardMvc.Models;

namespace TaskBoardMvc.Controllers
{
    public class WorkItemsController : Controller
    {
        private WorkItemDbContext db = new WorkItemDbContext();
        public ActionResult WorkItemsGrid(string searchString)
        {
            IQueryable<WorkItem> workItems = from wi in db.WorkItems select wi;
            if (!string.IsNullOrEmpty(searchString))
                workItems = workItems.Where(s => (s.TfsNum + s.TfsName).ToLower().Contains(searchString.ToLower()));

            List<WorkItem> listItems = new List<WorkItem>();
            foreach (var w in workItems) 
            {
                WorkItem newWi = new WorkItem();
                newWi.Id = w.Id;
                newWi.BackupId = w.BackupId;
                newWi.TfsName = w.TfsName;
                newWi.TfsNum = w.TfsNum;
                newWi.TfsUrl = w.TfsUrl;
                newWi.Updated = w.Updated;
                newWi.UsedItems_Changed = w.UsedItems_Changed?.Length > 50 ? w.UsedItems_Changed.Substring(0, 50) : w.UsedItems_Changed;
                newWi.UsedItems_New = w.UsedItems_New?.Length > 50 ? w.UsedItems_New.Substring(0, 50) : w.UsedItems_New;
                newWi.Sprint = w.Sprint;
                listItems.Add(newWi);
            }
            return View(listItems);
        }
        // GET: WorkItems
        public ActionResult Index(string searchString)
        {
            var workItems = from wi in db.WorkItems select wi;
            if(!string.IsNullOrEmpty(searchString))
                workItems = workItems.Where(s => (s.TfsNum + s.TfsName).ToLower().Contains(searchString.ToLower()));

            List<WorkItem> listItems = new List<WorkItem>();
            foreach (var w in workItems)
            {
                WorkItem newWi = new WorkItem();
                newWi.Id = w.Id;
                newWi.BackupId = w.BackupId;
                newWi.TfsName = w.TfsName;
                newWi.TfsNum = w.TfsNum;
                newWi.TfsUrl = w.TfsUrl;
                newWi.Updated = w.Updated;               
                newWi.UsedItems_Changed = w.UsedItems_Changed?.Length > 50 ? w.UsedItems_Changed.Substring(0, 50) : w.UsedItems_Changed;
                newWi.UsedItems_New = w.UsedItems_New?.Length > 50 ? w.UsedItems_New.Substring(0, 50) : w.UsedItems_New;
                listItems.Add(newWi);
            }
            return View(listItems);
        }
        // GET: WorkItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItem workItem = db.WorkItems.Find(id);
            if (workItem == null)
            {
                return HttpNotFound();
            }
            return View(workItem);
        }

        // GET: WorkItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkItems/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TfsNum,TfsName,UsedItems_Changed,UsedItems_New,TfsUrl,BackupId")] WorkItem workItem)
        {
            if (ModelState.IsValid)
            {
                workItem.Updated = DateTime.Now;
                db.WorkItems.Add(workItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workItem);
        }

        // GET: WorkItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItem workItem = db.WorkItems.Find(id);
            if (workItem == null)
            {
                return HttpNotFound();
            }
            return View(workItem);
        }

        // POST: WorkItems/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TfsNum,TfsName,UsedItems_Changed,UsedItems_New,TfsUrl,BackupId,Updated")] WorkItem workItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workItem);
        }

        // GET: WorkItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItem workItem = db.WorkItems.Find(id);
            if (workItem == null)
            {
                return HttpNotFound();
            }
            return View(workItem);
        }
        // POST: WorkItems/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkItem workItem = db.WorkItems.Find(id);
            db.WorkItems.Remove(workItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult WhatsNew()
        {
            var items = from wi in db.WorkItems select wi;

            return View(items.ToList());
        }
        public ActionResult About()
        {
            return View();
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
