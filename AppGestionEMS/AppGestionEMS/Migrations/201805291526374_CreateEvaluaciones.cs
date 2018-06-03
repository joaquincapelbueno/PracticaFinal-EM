namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEvaluaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evaluaciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CursoId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Convocatoria = c.Int(nullable: false),
                        Trabajo1 = c.Int(nullable: false),
                        Trabajo2 = c.Int(nullable: false),
                        Trabajo3 = c.Int(nullable: false),
                        Test = c.Int(nullable: false),
                        Practica = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CursoId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Matriculas", "CursoId", c => c.Int(nullable: false));
            AddColumn("dbo.Matriculas", "GrupoClasesId", c => c.Int(nullable: false));
            AddColumn("dbo.Matriculas", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Matriculas", "CursoId");
            CreateIndex("dbo.Matriculas", "GrupoClasesId");
            CreateIndex("dbo.Matriculas", "UserId");
            AddForeignKey("dbo.Matriculas", "CursoId", "dbo.Cursos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Matriculas", "GrupoClasesId", "dbo.GrupoClases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Matriculas", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Matriculas", "GrupoClasesId", "dbo.GrupoClases");
            DropForeignKey("dbo.Matriculas", "CursoId", "dbo.Cursos");
            DropForeignKey("dbo.Evaluaciones", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Evaluaciones", "CursoId", "dbo.Cursos");
            DropIndex("dbo.Matriculas", new[] { "UserId" });
            DropIndex("dbo.Matriculas", new[] { "GrupoClasesId" });
            DropIndex("dbo.Matriculas", new[] { "CursoId" });
            DropIndex("dbo.Evaluaciones", new[] { "UserId" });
            DropIndex("dbo.Evaluaciones", new[] { "CursoId" });
            DropColumn("dbo.Matriculas", "UserId");
            DropColumn("dbo.Matriculas", "GrupoClasesId");
            DropColumn("dbo.Matriculas", "CursoId");
            DropTable("dbo.Evaluaciones");
        }
    }
}
