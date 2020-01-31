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
    public class EmpleadosController : Controller
    {
        private BD_CARRETERASEntities db = new BD_CARRETERASEntities();

        // GET: Empleados
        public ActionResult Index()
        {
            var tb_empleados = db.tb_empleados.Include(t => t.tb_ciudades).Include(t => t.tb_usuarios).Include(t => t.tb_usuarios1);
            return View(tb_empleados.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_empleados tb_empleados = db.tb_empleados.Find(id);
            if (tb_empleados == null)
            {
                return HttpNotFound();
            }
            return View(tb_empleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.ciu_id = new SelectList(db.tb_ciudades, "ciu_id", "ciu_descripcion");
            ViewBag.emp_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            ViewBag.emp_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "emp_id,emp_nombre,emp_edad,emp_telefono,ciu_id,emp_usuario_crea,emp_fecha_crea,emp_usuario_modifica,emp_fecha_modifica,emp_estado")] tb_empleados tb_empleados)
        {
            if (ModelState.IsValid)
            {
                db.tb_empleados.Add(tb_empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ciu_id = new SelectList(db.tb_ciudades, "ciu_id", "ciu_descripcion", tb_empleados.ciu_id);
            ViewBag.emp_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_empleados.emp_usuario_crea);
            ViewBag.emp_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_empleados.emp_usuario_modifica);
            return View(tb_empleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_empleados tb_empleados = db.tb_empleados.Find(id);
            if (tb_empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.ciu_id = new SelectList(db.tb_ciudades, "ciu_id", "ciu_descripcion", tb_empleados.ciu_id);
            ViewBag.emp_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_empleados.emp_usuario_crea);
            ViewBag.emp_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_empleados.emp_usuario_modifica);
            return View(tb_empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "emp_id,emp_nombre,emp_edad,emp_telefono,ciu_id,emp_usuario_crea,emp_fecha_crea,emp_usuario_modifica,emp_fecha_modifica,emp_estado")] tb_empleados tb_empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ciu_id = new SelectList(db.tb_ciudades, "ciu_id", "ciu_descripcion", tb_empleados.ciu_id);
            ViewBag.emp_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_empleados.emp_usuario_crea);
            ViewBag.emp_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_empleados.emp_usuario_modifica);
            return View(tb_empleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_empleados tb_empleados = db.tb_empleados.Find(id);
            if (tb_empleados == null)
            {
                return HttpNotFound();
            }
            return View(tb_empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_empleados tb_empleados = db.tb_empleados.Find(id);
            db.tb_empleados.Remove(tb_empleados);
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
