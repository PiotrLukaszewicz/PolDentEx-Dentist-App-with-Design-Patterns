namespace PolDentEx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedPatientForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "PatientDetailsId", "dbo.PatientDetails");
            AddForeignKey("dbo.Patients", "PatientDetailsId", "dbo.PatientDetails", "PatientDetailsId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "PatientDetailsId", "dbo.PatientDetails");
            AddForeignKey("dbo.Patients", "PatientDetailsId", "dbo.PatientDetails", "PatientDetailsId", cascadeDelete: true);
        }
    }
}
