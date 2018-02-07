using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControleHorario.Models.EF;

namespace ControleHorario.Controllers
{
    public class ColaboradorController : Controller
    {
        private ControleHorarioDBContext db = null;
        
        public ColaboradorController()
        {
            db = new ControleHorarioDBContext();
        }

        public JsonResult Login(DadosLogin dadosLogin)
        {
            var colaborador = new Colaborador();
            colaborador = db.Colaborador.Where(b => b.Email.Equals(dadosLogin.Email) && b.Senha.Equals(dadosLogin.Senha)).FirstOrDefault();
            return Json(colaborador, JsonRequestBehavior.AllowGet);  
        }

        public JsonResult GetListColaboradores()
        {
            var listaColaboradores = db.Colaborador.ToList();
            return Json(listaColaboradores, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetColaborador(int id)
        {
            var colaborador = db.Colaborador.Find(id);
            return Json(colaborador, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetColaboradorByMatricula(int matricula)
        {
            var colaborador = db.Colaborador.Where(b => b.Matricula.Equals(matricula)).FirstOrDefault();
            return Json(colaborador, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateColaborador(Colaborador colaborador)
        {
            db.Entry(colaborador).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Json(null);
        }

        [HttpPost]
        public JsonResult AddColaborador(Colaborador colaborador)
        {
            db.Colaborador.Add(colaborador);
            db.SaveChanges();
            return Json(null);
        }

        [HttpPost]
        public JsonResult DeleteColaborador(int idColaborador)
        {
            var colaborador = db.Colaborador.Find(idColaborador);
            db.Colaborador.Remove(colaborador);
            db.SaveChanges();
            return Json(null);
        }
    }
}