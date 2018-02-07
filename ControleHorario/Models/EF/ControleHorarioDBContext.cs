using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ControleHorario.Models.EF
{
    public class ControleHorarioDBContext : DbContext
    {

        public ControleHorarioDBContext() : base("name = ControleHorarioDBContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<CargaHoraria> CargaHoraria { get; set; }
        public DbSet<GradeHorarios> GradeHorarios { get; set; }
        
    }
}