namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChanging : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CuratorPatients", "CuratorId", "dbo.Employees");
            DropForeignKey("dbo.CuratorPatients", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.DiseaseProcedures", "DiseaseId", "dbo.Diseases");
            DropForeignKey("dbo.DiseaseProcedures", "ProcedureId", "dbo.Procedures");
            DropForeignKey("dbo.PatientDiseases", "DiseaseId", "dbo.Diseases");
            DropForeignKey("dbo.PatientDiseases", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Employees");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Employees", "UserId", "dbo.Users");
            DropIndex("dbo.CuratorPatients", new[] { "PatientId" });
            DropIndex("dbo.CuratorPatients", new[] { "CuratorId" });
            DropIndex("dbo.DiseaseProcedures", new[] { "DiseaseId" });
            DropIndex("dbo.DiseaseProcedures", new[] { "ProcedureId" });
            DropIndex("dbo.PatientDiseases", new[] { "PatientId" });
            DropIndex("dbo.PatientDiseases", new[] { "DiseaseId" });
            CreateTable(
                "dbo.PatientDoctors",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PatientId = c.Long(nullable: false),
                        DoctorId = c.Long(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.DoctorId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.PatientProcedures",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PatientId = c.Long(nullable: false),
                        ProcedureId = c.Long(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .ForeignKey("dbo.Procedures", t => t.ProcedureId)
                .Index(t => t.PatientId)
                .Index(t => t.ProcedureId);
            
            AddColumn("dbo.Patients", "CuratorId", c => c.Long(nullable: false));
            AddColumn("dbo.Patients", "DiseaseId", c => c.Long(nullable: false));
            CreateIndex("dbo.Patients", "CuratorId");
            CreateIndex("dbo.Patients", "DiseaseId");
            AddForeignKey("dbo.Patients", "CuratorId", "dbo.Employees", "Id");
            AddForeignKey("dbo.Patients", "DiseaseId", "dbo.Diseases", "Id");
            AddForeignKey("dbo.Appointments", "DoctorId", "dbo.Employees", "Id");
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.Patients", "Id");
            AddForeignKey("dbo.Employees", "UserId", "dbo.Users", "Id");
            DropTable("dbo.CuratorPatients");
            DropTable("dbo.DiseaseProcedures");
            DropTable("dbo.PatientDiseases");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PatientDiseases",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PatientId = c.Long(nullable: false),
                        DiseaseId = c.Long(nullable: false),
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
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Employees", "UserId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Employees");
            DropForeignKey("dbo.PatientProcedures", "ProcedureId", "dbo.Procedures");
            DropForeignKey("dbo.PatientProcedures", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientDoctors", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientDoctors", "DoctorId", "dbo.Employees");
            DropForeignKey("dbo.Patients", "DiseaseId", "dbo.Diseases");
            DropForeignKey("dbo.Patients", "CuratorId", "dbo.Employees");
            DropIndex("dbo.PatientProcedures", new[] { "ProcedureId" });
            DropIndex("dbo.PatientProcedures", new[] { "PatientId" });
            DropIndex("dbo.PatientDoctors", new[] { "DoctorId" });
            DropIndex("dbo.PatientDoctors", new[] { "PatientId" });
            DropIndex("dbo.Patients", new[] { "DiseaseId" });
            DropIndex("dbo.Patients", new[] { "CuratorId" });
            DropColumn("dbo.Patients", "DiseaseId");
            DropColumn("dbo.Patients", "CuratorId");
            DropTable("dbo.PatientProcedures");
            DropTable("dbo.PatientDoctors");
            CreateIndex("dbo.PatientDiseases", "DiseaseId");
            CreateIndex("dbo.PatientDiseases", "PatientId");
            CreateIndex("dbo.DiseaseProcedures", "ProcedureId");
            CreateIndex("dbo.DiseaseProcedures", "DiseaseId");
            CreateIndex("dbo.CuratorPatients", "CuratorId");
            CreateIndex("dbo.CuratorPatients", "PatientId");
            AddForeignKey("dbo.Employees", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "DoctorId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientDiseases", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientDiseases", "DiseaseId", "dbo.Diseases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DiseaseProcedures", "ProcedureId", "dbo.Procedures", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DiseaseProcedures", "DiseaseId", "dbo.Diseases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CuratorPatients", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CuratorPatients", "CuratorId", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
