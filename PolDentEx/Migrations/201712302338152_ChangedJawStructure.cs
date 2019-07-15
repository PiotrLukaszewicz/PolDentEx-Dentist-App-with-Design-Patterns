namespace PolDentEx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedJawStructure : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Patients", "PatientCard_Jaw_JawId");
            DropColumn("dbo.Patients", "PatientCard_Jaw_Description");
            DropColumn("dbo.Patients", "PatientCard_Jaw_State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "PatientCard_Jaw_State", c => c.Boolean(nullable: false));
            AddColumn("dbo.Patients", "PatientCard_Jaw_Description", c => c.String());
            AddColumn("dbo.Patients", "PatientCard_Jaw_JawId", c => c.Int(nullable: false));
        }
    }
}
