using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControleHorario.Models.EF
{
    [Table("CargaHoraria")]
    public class CargaHoraria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Colaborador Colaborador { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Dia { get; set; }
        public System.Nullable<TimeSpan> HoraEntrada { get; set; }
        public System.Nullable<TimeSpan> HoraSaida { get; set; }
        public System.Nullable<TimeSpan> Intervalo { get; set; }

    }
}