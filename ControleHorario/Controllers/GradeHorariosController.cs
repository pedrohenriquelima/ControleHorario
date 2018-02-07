using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControleHorario.Models.EF;

namespace ControleHorario.Controllers
{
    public class GradeHorariosController : Controller
    {
        private ControleHorarioDBContext db = null;
        
        public GradeHorariosController()
        {
            db = new ControleHorarioDBContext();
        }
        
        public JsonResult GetListGradeHorarios()
        {
            var listaGradeHorarios = new List<Horario>();
            listaGradeHorarios = ConvertListGradeToHorario(db.GradeHorarios.ToList());
            return Json(listaGradeHorarios, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGradeHorarios(string diaSemana)
        {
            GradeHorarios gradeHorarios = db.GradeHorarios.Where(b => b.DiaSemana == diaSemana).First();
            return Json(gradeHorarios, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateGradeHorarios(Horario gradeHorarios)
        {
            db.Entry(ConvertHorarioToGrade(gradeHorarios)).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Json(null);
        }

        [HttpPost]
        public JsonResult AddGradeHorarios(Horario gradeHorarios)
        {
            db.GradeHorarios.Add(ConvertHorarioToGrade(gradeHorarios));
            db.SaveChanges();
            return Json(null);
        }

        [HttpPost]
        public JsonResult DeleteGradeHorarios(int idGradeHorarios)
        {
            var gradeHorarios = db.GradeHorarios.Find(idGradeHorarios);
            db.GradeHorarios.Remove(gradeHorarios);
            db.SaveChanges();
            return Json(null);
        }

        public Horario ConvertGradeToHorario(GradeHorarios gradeHorarios)
        {
            var horaEntrada = new TimeSpan();
            var horaSaida = new TimeSpan();
            var intervalo = new TimeSpan();

            // gradeHorarios.TipoHora.HasValue ? gradeHorarios.TipoHora.Value : new TimeSpan(0, 0, 0);

            if (gradeHorarios.HoraEntrada.HasValue) {
                horaEntrada = gradeHorarios.HoraEntrada.Value;
            } else {
                new TimeSpan(0, 0, 0);
            }
            
            if (gradeHorarios.HoraSaida.HasValue){
                horaSaida = gradeHorarios.HoraSaida.Value;
            } else {
                new TimeSpan(0, 0, 0);
            }

            if (gradeHorarios.Intervalo.HasValue){
                intervalo = gradeHorarios.Intervalo.Value;
            } else {
                new TimeSpan(0, 0, 0);
            }

            return new Horario()
            {
                
                Id = gradeHorarios.Id,
                DiaSemana = gradeHorarios.DiaSemana,
                HoraEntrada = new DateTime().Add(horaEntrada),
                HoraSaida = new DateTime().Add(horaSaida),
                Intervalo = new DateTime().Add(intervalo)
            };
        }

        public GradeHorarios ConvertHorarioToGrade(Horario horario)
        {
            TimeSpan horaEntrada;
            TimeSpan horaSaida;
            TimeSpan intervalo;

            horaEntrada = new TimeSpan(horario.HoraEntrada.Hour, horario.HoraEntrada.Minute, horario.HoraEntrada.Second);
            horaSaida = new TimeSpan(horario.HoraSaida.Hour, horario.HoraSaida.Minute, horario.HoraSaida.Second);
            intervalo = new TimeSpan(horario.Intervalo.Hour, horario.Intervalo.Minute, horario.Intervalo.Second);

            return new GradeHorarios()
            {
                Id = horario.Id,
                DiaSemana = horario.DiaSemana,
                HoraEntrada = horaEntrada,
                HoraSaida = horaSaida,
                Intervalo = intervalo
            };
        }

        //Conversões 
        public List<Horario> ConvertListGradeToHorario(List<GradeHorarios> gradeHorarios)
        {
            var returnListaHorarios = new List<Horario>();

            foreach (var itemGrade in gradeHorarios)
            {
                returnListaHorarios.Add(ConvertGradeToHorario(itemGrade));
            }
            return returnListaHorarios;
        }

        public List<GradeHorarios> ConvertLisHorarioToGrade(List<Horario> horarios)
        {
            var returnListaGradeHorarios = new List<GradeHorarios>();

            foreach (var itemGrade in horarios)
            {
                returnListaGradeHorarios.Add(ConvertHorarioToGrade(itemGrade));
            }
            return returnListaGradeHorarios;
        }
    }
}