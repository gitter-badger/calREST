namespace calREST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientsName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "PatientName", c => c.String(nullable: false));
            DropColumn("dbo.Patients", "PatienName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "PatienName", c => c.String(nullable: false));
            DropColumn("dbo.Patients", "PatientName");
        }
    }
}
