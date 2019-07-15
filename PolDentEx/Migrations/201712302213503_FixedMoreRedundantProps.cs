namespace PolDentEx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedMoreRedundantProps : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Patients", "PatientCard_JawId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "PatientCard_JawId", c => c.Int(nullable: false));
        }
    }
}
