﻿using System;
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
    public class CarreterasController : Controller
    {
        private BD_CARRETERASEntities db = new BD_CARRETERASEntities();

        // GET: Carreteras
        public ActionResult Index()
        {
            var tb_carreteras = db.tb_carreteras.Include(t => t.tb_categorias).Include(t => t.tb_ciudades).Include(t => t.tb_usuarios).Include(t => t.tb_usuarios1);
            return View(tb_carreteras.ToList());
        }

        // GET: Carreteras/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_carreteras tb_carreteras = db.tb_carreteras.Find(id);
            if (tb_carreteras == null)
            {
                return HttpNotFound();
            }
            return View(tb_carreteras);
        }

        // GET: Carreteras/Create
        public ActionResult Create()
        {
            ViewBag.cat_id = new SelectList(db.tb_categorias, "cat_id", "cat_descripcion");
            ViewBag.ciu_id = new SelectList(db.tb_ciudades, "ciu_id", "ciu_descripcion");
            ViewBag.car_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            ViewBag.car_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            return View();
        }

        // POST: Carreteras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "car_id,car_descripcion,cat_id,car_km_inicio,car_km_fin,ciu_id,car_finC,car_usuario_crea,car_fecha_crea,car_usuario_modifica,car_fecha_modifica,car_estado")] tb_carreteras tb_carreteras)
        {
            if (ModelState.IsValid)
            {
                db.tb_carreteras.Add(tb_carreteras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cat_id = new SelectList(db.tb_categorias, "cat_id", "cat_descripcion", tb_carreteras.cat_id);
            ViewBag.ciu_id = new SelectList(db.tb_ciudades, "ciu_id", "ciu_descripcion", tb_carreteras.ciu_id);
            ViewBag.car_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_carreteras.car_usuario_crea);
            ViewBag.car_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_carreteras.car_usuario_modifica);
            return View(tb_carreteras);
        }

        // GET: Carreteras/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_carreteras tb_carreteras = db.tb_carreteras.Find(id);
            if (tb_carreteras == null)
            {
                return HttpNotFound();
            }
            ViewBag.cat_id = new SelectList(db.tb_categorias, "cat_id", "cat_descripcion", tb_carreteras.cat_id);
            ViewBag.ciu_id = new SelectList(db.tb_ciudades, "ciu_id", "ciu_descripcion", tb_carreteras.ciu_id);
            ViewBag.car_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_carreteras.car_usuario_crea);
            ViewBag.car_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_carreteras.car_usuario_modifica);
            return View(tb_carreteras);
        }

        // POST: Carreteras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "car_id,car_descripcion,cat_id,car_km_inicio,car_km_fin,ciu_id,car_finC,car_usuario_crea,car_fecha_crea,car_usuario_modifica,car_fecha_modifica,car_estado")] tb_carreteras tb_carreteras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_carreteras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cat_id = new SelectList(db.tb_categorias, "cat_id", "cat_descripcion", tb_carreteras.cat_id);
            ViewBag.ciu_id = new SelectList(db.tb_ciudades, "ciu_id", "ciu_descripcion", tb_carreteras.ciu_id);
            ViewBag.car_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_carreteras.car_usuario_crea);
            ViewBag.car_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_carreteras.car_usuario_modifica);
            return View(tb_carreteras);
        }

        // GET: Carreteras/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_carreteras tb_carreteras = db.tb_carreteras.Find(id);
            if (tb_carreteras == null)
            {
                return HttpNotFound();
            }
            return View(tb_carreteras);
        }

        // POST: Carreteras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_carreteras tb_carreteras = db.tb_carreteras.Find(id);
            db.tb_carreteras.Remove(tb_carreteras);
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