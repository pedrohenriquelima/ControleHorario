using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControleHorario.Models.EF;

namespace ControleHorario.Controllers
{
    public class CargaHorariaController : Controller
    {
        private ControleHorarioDBContext db = null;
        
        public CargaHorariaController()
        {
            db = new ControleHorarioDBContext();
        }

        public JsonResult GetListCargaHoraria()
        {
            var listaCargaHoraria = db.CargaHoraria.ToList();
            return Json(listaCargaHoraria, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCargaHoraria(int id)
        {
            CargaHoraria cargaHoraria = db.CargaHoraria.Where(b => b.Id == id).First();
            return Json(cargaHoraria, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCargaHorariaColaborador(int id_colaborador)
        {
            CargaHoraria cargaHoraria = db.CargaHoraria.Where(b => b.Colaborador.Id == id_colaborador).First();
            return Json(cargaHoraria, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateCargaHoraria(CargaHoraria cargaHoraria)
        {
            db.Entry(cargaHoraria).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Json(null);
        }

        [HttpPost]
        public JsonResult AddCargaHoraria(CargaHoraria cargaHoraria)
        {
            db.CargaHoraria.Add(cargaHoraria);
            db.SaveChanges();
            return Json(null);
        }

        [HttpPost]
        public JsonResult DeleteCargaHoraria(int idCargaHoraria)
        {
            var cargaHoraria = db.CargaHoraria.Find(idCargaHoraria);
            db.CargaHoraria.Remove(cargaHoraria);
            db.SaveChanges();
            return Json(null);
        }
    }
}