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
    public class CategoriasController : Controller
    {
        private BD_CARRETERASEntities db = new BD_CARRETERASEntities();

        // GET: Categorias
        public ActionResult Index()
        {
            var tb_categorias = db.tb_categorias.Include(t => t.tb_usuarios).Include(t => t.tb_usuarios1);
            return View(tb_categorias.ToList());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_categorias tb_categorias = db.tb_categorias.Find(id);
            if (tb_categorias == null)
            {
                return HttpNotFound();
            }
            return View(tb_categorias);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            ViewBag.cat_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            ViewBag.cat_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cat_id,cat_descripcion,cat_usuario_crea,cat_fecha_crea,cat_usuario_modifica,cat_fecha_modifica,cat_estado")] tb_categorias tb_categorias)
        {
            if (ModelState.IsValid)
            {
                db.tb_categorias.Add(tb_categorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cat_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_categorias.cat_usuario_crea);
            ViewBag.cat_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_categorias.cat_usuario_modifica);
            return View(tb_categorias);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_categorias tb_categorias = db.tb_categorias.Find(id);
            if (tb_categorias == null)
            {
                return HttpNotFound();
            }
            ViewBag.cat_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_categorias.cat_usuario_crea);
            ViewBag.cat_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_categorias.cat_usuario_modifica);
            return View(tb_categorias);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cat_id,cat_descripcion,cat_usuario_crea,cat_fecha_crea,cat_usuario_modifica,cat_fecha_modifica,cat_estado")] tb_categorias tb_categorias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_categorias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cat_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_categorias.cat_usuario_crea);
            ViewBag.cat_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_categorias.cat_usuario_modifica);
            return View(tb_categorias);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_categorias tb_categorias = db.tb_categorias.Find(id);
            if (tb_categorias == null)
            {
                return HttpNotFound();
            }
            return View(tb_categorias);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_categorias tb_categorias = db.tb_categorias.Find(id);
            db.tb_categorias.Remove(tb_categorias);
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
