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
    public class PantallasController : Controller
    {
        private BD_CARRETERASEntities db = new BD_CARRETERASEntities();

        // GET: Pantallas
        public ActionResult Index()
        {
            var tb_pantallas = db.tb_pantallas.Include(t => t.tb_usuarios).Include(t => t.tb_usuarios1);
            return View(tb_pantallas.ToList());
        }

        // GET: Pantallas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_pantallas tb_pantallas = db.tb_pantallas.Find(id);
            if (tb_pantallas == null)
            {
                return HttpNotFound();
            }
            return View(tb_pantallas);
        }

        // GET: Pantallas/Create
        public ActionResult Create()
        {
            ViewBag.pant_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            ViewBag.pant_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            return View();
        }

        // POST: Pantallas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pant_id,pant_descripcion,pant_usuario_crea,pant_fecha_crea,pant_usuario_modifica,pant_fecha_modifica,pant_estado")] tb_pantallas tb_pantallas)
        {
            if (ModelState.IsValid)
            {
                db.tb_pantallas.Add(tb_pantallas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pant_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_pantallas.pant_usuario_crea);
            ViewBag.pant_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_pantallas.pant_usuario_modifica);
            return View(tb_pantallas);
        }

        // GET: Pantallas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_pantallas tb_pantallas = db.tb_pantallas.Find(id);
            if (tb_pantallas == null)
            {
                return HttpNotFound();
            }
            ViewBag.pant_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_pantallas.pant_usuario_crea);
            ViewBag.pant_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_pantallas.pant_usuario_modifica);
            return View(tb_pantallas);
        }

        // POST: Pantallas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pant_id,pant_descripcion,pant_usuario_crea,pant_fecha_crea,pant_usuario_modifica,pant_fecha_modifica,pant_estado")] tb_pantallas tb_pantallas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_pantallas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pant_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_pantallas.pant_usuario_crea);
            ViewBag.pant_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_pantallas.pant_usuario_modifica);
            return View(tb_pantallas);
        }

        // GET: Pantallas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_pantallas tb_pantallas = db.tb_pantallas.Find(id);
            if (tb_pantallas == null)
            {
                return HttpNotFound();
            }
            return View(tb_pantallas);
        }

        // POST: Pantallas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_pantallas tb_pantallas = db.tb_pantallas.Find(id);
            db.tb_pantallas.Remove(tb_pantallas);
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
