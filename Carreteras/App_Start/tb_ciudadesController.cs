using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Carreteras;

namespace Carreteras.App_Start
{
    public class tb_ciudadesController : Controller
    {
        private carreteras_finalEntities db = new carreteras_finalEntities();

        // GET: tb_ciudades
        public ActionResult Index()
        {
            var tb_ciudades = db.tb_ciudades.Include(t => t.tb_departamentos).Include(t => t.tb_usuarios).Include(t => t.tb_usuarios1);
            return View(tb_ciudades.ToList());
        }

        // GET: tb_ciudades/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ciudades tb_ciudades = db.tb_ciudades.Find(id);
            if (tb_ciudades == null)
            {
                return HttpNotFound();
            }
            return View(tb_ciudades);
        }

        // GET: tb_ciudades/Create
        public ActionResult Create()
        {
            ViewBag.dep_id = new SelectList(db.tb_departamentos, "dep_id", "dep_descripcion");
            ViewBag.ciu_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            ViewBag.ciu_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            return View();
        }

        // POST: tb_ciudades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ciu_id,ciu_descripcion,dep_id,ciu_usuario_crea,ciu_fecha_crea,ciu_usuario_modifica,ciu_fecha_modifica,ciu_estado")] tb_ciudades tb_ciudades)
        {
            if (ModelState.IsValid)
            {
                db.tb_ciudades.Add(tb_ciudades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dep_id = new SelectList(db.tb_departamentos, "dep_id", "dep_descripcion", tb_ciudades.dep_id);
            ViewBag.ciu_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_ciudades.ciu_usuario_crea);
            ViewBag.ciu_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_ciudades.ciu_usuario_modifica);
            return View(tb_ciudades);
        }

        // GET: tb_ciudades/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ciudades tb_ciudades = db.tb_ciudades.Find(id);
            if (tb_ciudades == null)
            {
                return HttpNotFound();
            }
            ViewBag.dep_id = new SelectList(db.tb_departamentos, "dep_id", "dep_descripcion", tb_ciudades.dep_id);
            ViewBag.ciu_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_ciudades.ciu_usuario_crea);
            ViewBag.ciu_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_ciudades.ciu_usuario_modifica);
            return View(tb_ciudades);
        }

        // POST: tb_ciudades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ciu_id,ciu_descripcion,dep_id,ciu_usuario_crea,ciu_fecha_crea,ciu_usuario_modifica,ciu_fecha_modifica,ciu_estado")] tb_ciudades tb_ciudades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_ciudades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dep_id = new SelectList(db.tb_departamentos, "dep_id", "dep_descripcion", tb_ciudades.dep_id);
            ViewBag.ciu_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_ciudades.ciu_usuario_crea);
            ViewBag.ciu_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_ciudades.ciu_usuario_modifica);
            return View(tb_ciudades);
        }

        // GET: tb_ciudades/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ciudades tb_ciudades = db.tb_ciudades.Find(id);
            if (tb_ciudades == null)
            {
                return HttpNotFound();
            }
            return View(tb_ciudades);
        }

        // POST: tb_ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_ciudades tb_ciudades = db.tb_ciudades.Find(id);
            db.tb_ciudades.Remove(tb_ciudades);
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
