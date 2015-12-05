namespace calREST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedcontentforappointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Content");
        }
    }
}
