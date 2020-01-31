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
    public class ComunasController : Controller
    {
        private BD_CARRETERASEntities db = new BD_CARRETERASEntities();

        // GET: Comunas
        public ActionResult Index()
        {
            var tb_comunas = db.tb_comunas.Include(t => t.tb_tramos).Include(t => t.tb_usuarios).Include(t => t.tb_usuarios1);
            return View(tb_comunas.ToList());
        }

        // GET: Comunas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_comunas tb_comunas = db.tb_comunas.Find(id);
            if (tb_comunas == null)
            {
                return HttpNotFound();
            }
            return View(tb_comunas);
        }

        // GET: Comunas/Create
        public ActionResult Create()
        {
            ViewBag.tra_id = new SelectList(db.tb_tramos, "tra_id", "tra_descripcion");
            ViewBag.com_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            ViewBag.com_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            return View();
        }

        // POST: Comunas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "com_id,com_descripcion,com_km_inicio,com_km_fin,tra_id,com_usuario_crea,com_fecha_crea,com_usuario_modifica,com_fecha_modifica,com_estado")] tb_comunas tb_comunas)
        {
            if (ModelState.IsValid)
            {
                db.tb_comunas.Add(tb_comunas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tra_id = new SelectList(db.tb_tramos, "tra_id", "tra_descripcion", tb_comunas.tra_id);
            ViewBag.com_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_comunas.com_usuario_crea);
            ViewBag.com_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_comunas.com_usuario_modifica);
            return View(tb_comunas);
        }

        // GET: Comunas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_comunas tb_comunas = db.tb_comunas.Find(id);
            if (tb_comunas == null)
            {
                return HttpNotFound();
            }
            ViewBag.tra_id = new SelectList(db.tb_tramos, "tra_id", "tra_descripcion", tb_comunas.tra_id);
            ViewBag.com_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_comunas.com_usuario_crea);
            ViewBag.com_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_comunas.com_usuario_modifica);
            return View(tb_comunas);
        }

        // POST: Comunas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "com_id,com_descripcion,com_km_inicio,com_km_fin,tra_id,com_usuario_crea,com_fecha_crea,com_usuario_modifica,com_fecha_modifica,com_estado")] tb_comunas tb_comunas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_comunas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tra_id = new SelectList(db.tb_tramos, "tra_id", "tra_descripcion", tb_comunas.tra_id);
            ViewBag.com_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_comunas.com_usuario_crea);
            ViewBag.com_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_comunas.com_usuario_modifica);
            return View(tb_comunas);
        }

        // GET: Comunas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_comunas tb_comunas = db.tb_comunas.Find(id);
            if (tb_comunas == null)
            {
                return HttpNotFound();
            }
            return View(tb_comunas);
        }

        // POST: Comunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_comunas tb_comunas = db.tb_comunas.Find(id);
            db.tb_comunas.Remove(tb_comunas);
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
