using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControleHorario.Models.EF
{
    [Table("Colaboradores")]
    public class Colaborador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }
        [Required]
        public int Matricula { get; set; }
        [Required]
        [MaxLength(150)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required]
        [MaxLength(30)]
        public string TipoUsuario { get; set; }

        public IEnumerable<CargaHoraria> CargaHoraria { get; set; }
    }
}