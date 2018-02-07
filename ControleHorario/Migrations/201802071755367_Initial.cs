namespace ControleHorario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CargaHoraria", "HoraEntrada", c => c.Time(precision: 7));
            AlterColumn("dbo.CargaHoraria", "HoraSaida", c => c.Time(precision: 7));
            AlterColumn("dbo.CargaHoraria", "Intervalo", c => c.Time(precision: 7));
            AlterColumn("dbo.GradeHorarios", "HoraEntrada", c => c.Time(precision: 7));
            AlterColumn("dbo.GradeHorarios", "HoraSaida", c => c.Time(precision: 7));
            AlterColumn("dbo.GradeHorarios", "Intervalo", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GradeHorarios", "Intervalo", c => c.DateTime(nullable: true));
            AlterColumn("dbo.GradeHorarios", "HoraSaida", c => c.DateTime(nullable: true));
            AlterColumn("dbo.GradeHorarios", "HoraEntrada", c => c.DateTime(nullable: true));
            AlterColumn("dbo.CargaHoraria", "Intervalo", c => c.DateTime(nullable: true));
            AlterColumn("dbo.CargaHoraria", "HoraSaida", c => c.DateTime(nullable: true));
            AlterColumn("dbo.CargaHoraria", "HoraEntrada", c => c.DateTime(nullable: true));
        }
    }
}
