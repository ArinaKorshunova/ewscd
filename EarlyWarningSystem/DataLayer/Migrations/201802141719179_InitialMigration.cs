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
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FIO = c.String(nullable: false),
                        Specialization = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Role = c.String(nullable: false),
                        Dscription = c.String(),
                        UserId = c.Long(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        PasswordHash = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FIO = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        CityName = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CuratorPatients",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PatientId = c.Long(nullable: false),
                        CuratorId = c.Long(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.CuratorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.CuratorId);
            
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DiseaseProcedures",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DiseaseId = c.Long(nullable: false),
                        ProcedureId = c.Long(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
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
                        DEscription = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientDiseases",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PatientId = c.Long(nullable: false),
                        DiseaseId = c.Long(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
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
            DropForeignKey("dbo.CuratorPatients", "CuratorId", "dbo.Employees");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "UserId", "dbo.Users");
            DropIndex("dbo.PatientDiseases", new[] { "DiseaseId" });
            DropIndex("dbo.PatientDiseases", new[] { "PatientId" });
            DropIndex("dbo.DiseaseProcedures", new[] { "ProcedureId" });
            DropIndex("dbo.DiseaseProcedures", new[] { "DiseaseId" });
            DropIndex("dbo.CuratorPatients", new[] { "CuratorId" });
            DropIndex("dbo.CuratorPatients", new[] { "PatientId" });
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropTable("dbo.PatientDiseases");
            DropTable("dbo.Procedures");
            DropTable("dbo.DiseaseProcedures");
            DropTable("dbo.Diseases");
            DropTable("dbo.CuratorPatients");
            DropTable("dbo.Patients");
            DropTable("dbo.Users");
            DropTable("dbo.Employees");
            DropTable("dbo.Appointments");
        }
    }
}
