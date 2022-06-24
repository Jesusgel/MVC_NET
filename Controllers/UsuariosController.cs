using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica_MVC.Models;
using Practica_MVC.Models.ViewModels;
using Practica_MVC.Utilidades;


namespace Practica_MVC.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {

            using (MvcPruebaEntities db = new MvcPruebaEntities())
            {
                // Solo usuarios activos
               
                //var lst = db.usuario.Where(a => a.StatusId == 2).ToList();

                var lst = (from u in db.Usuario 
                           where u.StatusId == 2
                           select new TablaUsuarioVM(){
                               name = u.name,
                               apellido = u.apellido,
                               correo = u.correo,
                               id = (int)u.id
                           } ).ToList();


                return View(lst);
            }
        }


        [HttpGet]
        public ActionResult Nuevo() {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(UsuarioVM usuarioVM) {
            try {

                if (!ModelState.IsValid) {
                    return View(usuarioVM);
                }

                using(MvcPruebaEntities db = new MvcPruebaEntities()) {

                    Usuario objUsuario = new Usuario();
                    objUsuario.name = usuarioVM.Name;
                    objUsuario.apellido = usuarioVM.Apellido;
                    objUsuario.correo = usuarioVM.Correo;
                    objUsuario.password = usuarioVM.Password;
                    objUsuario.date_created =  DateTime.Now;
                    objUsuario.StatusId = Constantes.ACTIVO;

                    db.Usuario.Add(objUsuario);
                    db.SaveChanges();

                }

                return Redirect(Url.Content("~/Usuarios/"));
            } catch {

                return Content("Error :(");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id) {

            EditUsuarioVM editUsuario = new EditUsuarioVM();

            using (MvcPruebaEntities db = new MvcPruebaEntities())
            {

                Usuario objUsuario = db.Usuario.Find(id);
                editUsuario.Name = objUsuario.name;
                editUsuario.Apellido = objUsuario.apellido;
                editUsuario.Correo = objUsuario.correo;
            
                
            }

            return View(editUsuario);
        }

        [HttpPost]
        public ActionResult Edit(EditUsuarioVM editUsuarioVM)
        {

            if (!ModelState.IsValid)
            {
                return View(editUsuarioVM);
            }

            using (MvcPruebaEntities db = new MvcPruebaEntities())
            {

                Usuario objUsuario = db.Usuario.Find(editUsuarioVM.Id);
                objUsuario.name = editUsuarioVM.Name;
                objUsuario.apellido = editUsuarioVM.Apellido;
                objUsuario.correo = editUsuarioVM.Correo;

                if (!String.IsNullOrEmpty(editUsuarioVM.Password)) {
                    objUsuario.password = editUsuarioVM.Password;
                }

                db.Entry(objUsuario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }


            return Redirect(Url.Content("~/Usuarios/"));
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {

            using (MvcPruebaEntities db = new MvcPruebaEntities())
            {

                Usuario objUsuario = db.Usuario.Find(id);
                objUsuario.StatusId = Constantes.ELIMINADO;

                db.Entry(objUsuario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Content("1");
        }

    }
}
