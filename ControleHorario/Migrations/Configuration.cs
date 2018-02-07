namespace ControleHorario.Migrations
{
    using Models.EF;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ControleHorario.Models.EF.ControleHorarioDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ControleHorario.Models.EF.ControleHorarioDBContext";
        }

        protected override void Seed(ControleHorario.Models.EF.ControleHorarioDBContext context)
        {
            context.Colaborador.AddOrUpdate(x => x.Id, 
                new Colaborador() { Id = 1, Nome = "Pedro Lima", Email = "pedrolima@even3.com.br", Matricula = 123, Senha = "123", TipoUsuario = "Estagiario" },
                new Colaborador() { Id = 2, Nome = "Admin", Email = "admin@even3.com.br", Matricula = 001, Senha = "admin", TipoUsuario = "Administrador" }
            );

            context.GradeHorarios.AddOrUpdate(x => x.Id, 
                new GradeHorarios() { Id= 1, DiaSemana = "Domingo" },
                new GradeHorarios() { Id = 2, DiaSemana = "Segunda-Feira", HoraEntrada = new TimeSpan(12, 30, 0), HoraSaida = new TimeSpan(19, 0, 0), Intervalo = new TimeSpan(0, 30, 0) },
                new GradeHorarios() { Id = 3, DiaSemana = "Terça-Feira", HoraEntrada = new TimeSpan(12, 30, 0), HoraSaida = new TimeSpan(19, 0, 0), Intervalo = new TimeSpan(0, 30, 0) },
                new GradeHorarios() { Id = 4, DiaSemana = "Quarta-Feira", HoraEntrada = new TimeSpan(12, 30, 0), HoraSaida = new TimeSpan(19, 0, 0), Intervalo = new TimeSpan(0, 30, 0) },
                new GradeHorarios() { Id = 5, DiaSemana = "Quinta-Feira", HoraEntrada = new TimeSpan(12, 30, 0), HoraSaida = new TimeSpan(19, 0, 0), Intervalo = new TimeSpan(0, 30, 0) },
                new GradeHorarios() { Id = 6, DiaSemana = "Sexta-Feira", HoraEntrada = new TimeSpan(12, 30, 0), HoraSaida = new TimeSpan(19, 0, 0), Intervalo = new TimeSpan(0, 30, 0) },
                new GradeHorarios() { Id = 7, DiaSemana = "Sábado" }
            );

            context.SaveChanges();
        }
    }
}
