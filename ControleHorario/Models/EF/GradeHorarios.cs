using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControleHorario.Models.EF
{
    [Table("GradeHorarios")]
    public class GradeHorarios
    {
        [Key]
        public int Id { get; set; }
        public string DiaSemana { get; set; }
        public System.Nullable<TimeSpan> HoraEntrada { get; set; }
        public System.Nullable<TimeSpan> HoraSaida { get; set; }
        public System.Nullable<TimeSpan> Intervalo { get; set; }
    }
}