using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControleHorario.Models.EF
{
    public class Horario
    {
        public int Id { get; set; }
        public string DiaSemana { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public DateTime Intervalo { get; set; }
    }
}