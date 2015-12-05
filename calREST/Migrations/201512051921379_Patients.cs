namespace calREST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Patients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        OwnerId = c.String(maxLength: 128),
                        PatienName = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Note = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            AddColumn("dbo.Appointments", "PatientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "PatientId");
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.Patients", "PatientId", cascadeDelete: true);
            DropColumn("dbo.Appointments", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "Content", c => c.String());
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "OwnerId", "dbo.AspNetUsers");
            DropIndex("dbo.Patients", new[] { "OwnerId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropColumn("dbo.Appointments", "PatientId");
            DropTable("dbo.Patients");
        }
    }
}
