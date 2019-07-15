namespace PolDentEx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedDatesYetAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors");
            AddForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors", "DoctorId");
            AlterColumn("dbo.Appointments", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Patients", "Date", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors");
            AddForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors", "DoctorId", cascadeDelete: true);
            AlterColumn("dbo.Patients", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Appointments", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
