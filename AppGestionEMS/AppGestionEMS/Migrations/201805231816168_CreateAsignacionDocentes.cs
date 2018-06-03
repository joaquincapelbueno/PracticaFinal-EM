namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAsignacionDocentes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AsignacionDocentes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AsignacionDocentes", "UserId");
            AddForeignKey("dbo.AsignacionDocentes", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AsignacionDocentes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AsignacionDocentes", new[] { "UserId" });
            DropColumn("dbo.AsignacionDocentes", "UserId");
        }
    }
}
