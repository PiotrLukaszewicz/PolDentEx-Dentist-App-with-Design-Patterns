namespace PolDentEx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedRedundantProps : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Patients", "DetailsId");
            DropColumn("dbo.Patients", "PatientDetails_DetailsId");
            DropColumn("dbo.Patients", "CardId");
            DropColumn("dbo.Patients", "PatientCard_CardId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "PatientCard_CardId", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "CardId", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "PatientDetails_DetailsId", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "DetailsId", c => c.Int(nullable: false));
        }
    }
}
