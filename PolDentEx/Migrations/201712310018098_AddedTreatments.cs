namespace PolDentEx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTreatments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TreatmentOnAppointments",
                c => new
                    {
                        TreatmentOnAppointmentId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        TreatmentId = c.Int(nullable: false),
                        AppointmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TreatmentOnAppointmentId)
                .ForeignKey("dbo.Appointments", t => t.AppointmentId, cascadeDelete: true)
                .ForeignKey("dbo.Treatments", t => t.TreatmentId, cascadeDelete: true)
                .Index(t => t.TreatmentId)
                .Index(t => t.AppointmentId);
            
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        TreatmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Nfzid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TreatmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TreatmentOnAppointments", "TreatmentId", "dbo.Treatments");
            DropForeignKey("dbo.TreatmentOnAppointments", "AppointmentId", "dbo.Appointments");
            DropIndex("dbo.TreatmentOnAppointments", new[] { "AppointmentId" });
            DropIndex("dbo.TreatmentOnAppointments", new[] { "TreatmentId" });
            DropTable("dbo.Treatments");
            DropTable("dbo.TreatmentOnAppointments");
        }
    }
}
