namespace PolDentEx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsFixed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientCards",
                c => new
                    {
                        PatientCardId = c.Int(nullable: false, identity: true),
                        HistoryFile = c.String(),
                        AllergiesFile = c.String(),
                        DiseaseFile = c.String(),
                        TakenMedicinesFile = c.String(),
                        RtgFile = c.String(),
                    })
                .PrimaryKey(t => t.PatientCardId);
            
            CreateTable(
                "dbo.Teeth",
                c => new
                    {
                        ToothId = c.Int(nullable: false, identity: true),
                        HumanToothId = c.Int(nullable: false),
                        Note1 = c.String(),
                        Note2 = c.String(),
                        Note3 = c.String(),
                        Note4 = c.String(),
                        Extracted = c.Boolean(nullable: false),
                        PatientCardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ToothId)
                .ForeignKey("dbo.HumanTeeth", t => t.HumanToothId, cascadeDelete: true)
                .ForeignKey("dbo.PatientCards", t => t.PatientCardId, cascadeDelete: true)
                .Index(t => t.HumanToothId)
                .Index(t => t.PatientCardId);
            
            CreateTable(
                "dbo.HumanTeeth",
                c => new
                    {
                        HumanToothId = c.Int(nullable: false, identity: true),
                        ToothName = c.String(),
                        IsMilkTooth = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HumanToothId);
            
            CreateTable(
                "dbo.PatientDetails",
                c => new
                    {
                        PatientDetailsId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PatientDetailsId);
            
            AddColumn("dbo.Patients", "PatientCardId", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "PatientDetailsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "PatientCardId");
            CreateIndex("dbo.Patients", "PatientDetailsId");
            AddForeignKey("dbo.Patients", "PatientCardId", "dbo.PatientCards", "PatientCardId", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "PatientDetailsId", "dbo.PatientDetails", "PatientDetailsId", cascadeDelete: true);
            DropColumn("dbo.Patients", "PatientDetails_FirstName");
            DropColumn("dbo.Patients", "PatientDetails_LastName");
            DropColumn("dbo.Patients", "PatientDetails_PhoneNumber");
            DropColumn("dbo.Patients", "PatientCard_HistoryFile");
            DropColumn("dbo.Patients", "PatientCard_AllergiesFile");
            DropColumn("dbo.Patients", "PatientCard_DiseaseFile");
            DropColumn("dbo.Patients", "PatientCard_TakenMedicinesFile");
            DropColumn("dbo.Patients", "PatientCard_RtgFile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "PatientCard_RtgFile", c => c.String());
            AddColumn("dbo.Patients", "PatientCard_TakenMedicinesFile", c => c.String());
            AddColumn("dbo.Patients", "PatientCard_DiseaseFile", c => c.String());
            AddColumn("dbo.Patients", "PatientCard_AllergiesFile", c => c.String());
            AddColumn("dbo.Patients", "PatientCard_HistoryFile", c => c.String());
            AddColumn("dbo.Patients", "PatientDetails_PhoneNumber", c => c.String(nullable: false));
            AddColumn("dbo.Patients", "PatientDetails_LastName", c => c.String(nullable: false));
            AddColumn("dbo.Patients", "PatientDetails_FirstName", c => c.String(nullable: false));
            DropForeignKey("dbo.Patients", "PatientDetailsId", "dbo.PatientDetails");
            DropForeignKey("dbo.Patients", "PatientCardId", "dbo.PatientCards");
            DropForeignKey("dbo.Teeth", "PatientCardId", "dbo.PatientCards");
            DropForeignKey("dbo.Teeth", "HumanToothId", "dbo.HumanTeeth");
            DropIndex("dbo.Teeth", new[] { "PatientCardId" });
            DropIndex("dbo.Teeth", new[] { "HumanToothId" });
            DropIndex("dbo.Patients", new[] { "PatientDetailsId" });
            DropIndex("dbo.Patients", new[] { "PatientCardId" });
            DropColumn("dbo.Patients", "PatientDetailsId");
            DropColumn("dbo.Patients", "PatientCardId");
            DropTable("dbo.PatientDetails");
            DropTable("dbo.HumanTeeth");
            DropTable("dbo.Teeth");
            DropTable("dbo.PatientCards");
        }
    }
}
