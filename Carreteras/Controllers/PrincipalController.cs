using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carreteras.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Principal
        public ActionResult Principal()
        {
            return View();
        }

        public ActionResult Carreteras()
        {
            return View();
        }

        public ActionResult Seguridad()
        {
            return View();
        }

        public ActionResult General()
        {
            return View();
        }

        public ActionResult ControladorCarreteras()
        {
            return RedirectToAction("Index","Carreteras");
        }

        public ActionResult ControladorTramos()
        {
            return RedirectToAction("Index", "Tramos");
        }

        public ActionResult ControladorCategorias()
        {
            return RedirectToAction("Index", "Categorias");
        }

        public ActionResult ControladorDepartamentos()
        {
            return RedirectToAction("Index", "Departamentos");
        }

        public ActionResult ControladorEmpleados()
        {
            return RedirectToAction("Index", "Empleados");
        }

        public ActionResult ControladorRoles()
        {
            return RedirectToAction("Index", "Roles");
        }

        public ActionResult ControladorPantallas()
        {
            return RedirectToAction("Index", "Pantallas");
        }

        public ActionResult ControladorUsuarios()
        {
            return RedirectToAction("Index", "Usuarios");
        }
    }
}