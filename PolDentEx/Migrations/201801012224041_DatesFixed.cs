namespace PolDentEx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatesFixed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "Date", c => c.DateTime(nullable: false));
        }
    }
}
