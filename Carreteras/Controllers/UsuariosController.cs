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
    public class UsuariosController : Controller
    {
        private BD_CARRETERASEntities db = new BD_CARRETERASEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var tb_usuarios = db.tb_usuarios.Include(t => t.tb_usuarios2).Include(t => t.tb_usuarios3);
            return View(tb_usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_usuarios tb_usuarios = db.tb_usuarios.Find(id);
            if (tb_usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tb_usuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.usu_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            ViewBag.usu_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "usu_id,usu_descripcion,usu_password,usu_usuario_crea,usu_fecha_crea,usu_usuario_modifica,usu_fecha_modifica,usu_estado")] tb_usuarios tb_usuarios)
        {
            if (ModelState.IsValid)
            {
                db.tb_usuarios.Add(tb_usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.usu_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_usuarios.usu_usuario_crea);
            ViewBag.usu_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_usuarios.usu_usuario_modifica);
            return View(tb_usuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_usuarios tb_usuarios = db.tb_usuarios.Find(id);
            if (tb_usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.usu_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_usuarios.usu_usuario_crea);
            ViewBag.usu_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_usuarios.usu_usuario_modifica);
            return View(tb_usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usu_id,usu_descripcion,usu_password,usu_usuario_crea,usu_fecha_crea,usu_usuario_modifica,usu_fecha_modifica,usu_estado")] tb_usuarios tb_usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.usu_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_usuarios.usu_usuario_crea);
            ViewBag.usu_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_usuarios.usu_usuario_modifica);
            return View(tb_usuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_usuarios tb_usuarios = db.tb_usuarios.Find(id);
            if (tb_usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tb_usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_usuarios tb_usuarios = db.tb_usuarios.Find(id);
            db.tb_usuarios.Remove(tb_usuarios);
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
