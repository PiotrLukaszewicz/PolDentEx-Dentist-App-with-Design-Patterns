namespace PolDentEx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedDatesYetAgain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Patients", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Appointments", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
