using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Carreteras.Models;

namespace Carreteras.Controllers
{
    public class DepartamentosController : Controller
    {
        private BD_CARRETERASEntities db = new BD_CARRETERASEntities();

        // GET: Departamentos
        public ActionResult Index()
        {
            var tb_departamentos = db.tb_departamentos.Include(t => t.tb_usuarios).Include(t => t.tb_usuarios1);
            return View(tb_departamentos.ToList());
        }

        // GET: Departamentos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_departamentos tb_departamentos = db.tb_departamentos.Find(id);
            if (tb_departamentos == null)
            {
                return HttpNotFound();
            }
            return View(tb_departamentos);
        }

        // GET: Departamentos/Create
        public ActionResult Create()
        {
            ViewBag.dep_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            ViewBag.dep_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            return View();
        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dep_id,dep_descripcion,dep_usuario_crea,dep_fecha_crea,dep_usuario_modifica,dep_fecha_modifica,dep_estado")] tb_departamentos tb_departamentos)
        {
            if (ModelState.IsValid)
            {
                db.tb_departamentos.Add(tb_departamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dep_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_departamentos.dep_usuario_crea);
            ViewBag.dep_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_departamentos.dep_usuario_modifica);
            return View(tb_departamentos);
        }

        // GET: Departamentos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_departamentos tb_departamentos = db.tb_departamentos.Find(id);
            if (tb_departamentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.dep_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_departamentos.dep_usuario_crea);
            ViewBag.dep_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_departamentos.dep_usuario_modifica);
            return View(tb_departamentos);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dep_id,dep_descripcion,dep_usuario_crea,dep_fecha_crea,dep_usuario_modifica,dep_fecha_modifica,dep_estado")] tb_departamentos tb_departamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_departamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dep_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_departamentos.dep_usuario_crea);
            ViewBag.dep_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_departamentos.dep_usuario_modifica);
            return View(tb_departamentos);
        }

        // GET: Departamentos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_departamentos tb_departamentos = db.tb_departamentos.Find(id);
            if (tb_departamentos == null)
            {
                return HttpNotFound();
            }
            return View(tb_departamentos);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_departamentos tb_departamentos = db.tb_departamentos.Find(id);
            db.tb_departamentos.Remove(tb_departamentos);
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
