namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DoctorId = c.Long(nullable: false),
                        PatientId = c.Long(nullable: false),
                        AppointmentDate = c.DateTime(nullable: false),
                        DoctorsCommnet = c.String(),
                        WasHeld = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FIO = c.String(nullable: false),
                        CityName = c.String(nullable: false),
                        Specialization = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CuratorPatients",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PatientId = c.Long(nullable: false),
                        CuratorId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Curators", t => t.CuratorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.CuratorId);
            
            CreateTable(
                "dbo.Curators",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FIO = c.String(nullable: false),
                        CityName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DiseaseProcedures",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DiseaseId = c.Long(nullable: false),
                        ProcedureId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.DiseaseId, cascadeDelete: true)
                .ForeignKey("dbo.Procedures", t => t.ProcedureId, cascadeDelete: true)
                .Index(t => t.DiseaseId)
                .Index(t => t.ProcedureId);
            
            CreateTable(
                "dbo.Procedures",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProcedureName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientDiseases",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PatientId = c.Long(nullable: false),
                        DiseaseId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.DiseaseId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DiseaseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientDiseases", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientDiseases", "DiseaseId", "dbo.Diseases");
            DropForeignKey("dbo.DiseaseProcedures", "ProcedureId", "dbo.Procedures");
            DropForeignKey("dbo.DiseaseProcedures", "DiseaseId", "dbo.Diseases");
            DropForeignKey("dbo.CuratorPatients", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.CuratorPatients", "CuratorId", "dbo.Curators");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.PatientDiseases", new[] { "DiseaseId" });
            DropIndex("dbo.PatientDiseases", new[] { "PatientId" });
            DropIndex("dbo.DiseaseProcedures", new[] { "ProcedureId" });
            DropIndex("dbo.DiseaseProcedures", new[] { "DiseaseId" });
            DropIndex("dbo.CuratorPatients", new[] { "CuratorId" });
            DropIndex("dbo.CuratorPatients", new[] { "PatientId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropTable("dbo.PatientDiseases");
            DropTable("dbo.Procedures");
            DropTable("dbo.DiseaseProcedures");
            DropTable("dbo.Diseases");
            DropTable("dbo.Curators");
            DropTable("dbo.CuratorPatients");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}
