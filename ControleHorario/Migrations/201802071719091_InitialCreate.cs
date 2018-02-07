namespace ControleHorario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargaHoraria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dia = c.DateTime(nullable: false, storeType: "date"),
                        HoraEntrada = c.DateTime(nullable: true),
                        HoraSaida = c.DateTime(nullable: true),
                        Intervalo = c.DateTime(nullable: true),
                        Colaborador_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaboradores", t => t.Colaborador_Id)
                .Index(t => t.Colaborador_Id);
            
            CreateTable(
                "dbo.Colaboradores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 150),
                        Matricula = c.Int(nullable: true),
                        Senha = c.String(nullable: false, maxLength: 150),
                        TipoUsuario = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GradeHorarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiaSemana = c.String(),
                        HoraEntrada = c.DateTime(nullable: true),
                        HoraSaida = c.DateTime(nullable: true),
                        Intervalo = c.DateTime(nullable: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CargaHoraria", "Colaborador_Id", "dbo.Colaboradores");
            DropIndex("dbo.CargaHoraria", new[] { "Colaborador_Id" });
            DropTable("dbo.GradeHorarios");
            DropTable("dbo.Colaboradores");
            DropTable("dbo.CargaHoraria");
        }
    }
}
