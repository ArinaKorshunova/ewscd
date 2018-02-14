namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDiesease : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Appointments", newName: "Actions");
            DropForeignKey("dbo.Patients", "DiseaseId", "dbo.Diseases");
            DropForeignKey("dbo.PatientProcedures", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientProcedures", "ProcedureId", "dbo.Procedures");
            DropIndex("dbo.Patients", new[] { "DiseaseId" });
            DropIndex("dbo.PatientProcedures", new[] { "PatientId" });
            DropIndex("dbo.PatientProcedures", new[] { "ProcedureId" });
            AddColumn("dbo.Actions", "KindAction", c => c.String(nullable: false));
            AddColumn("dbo.Actions", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Patients", "Disease", c => c.String());
            DropColumn("dbo.Patients", "DiseaseId");
            DropTable("dbo.Diseases");
            DropTable("dbo.PatientProcedures");
            DropTable("dbo.Procedures");
        }
        
        public override void Down()
        {
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
                "dbo.PatientProcedures",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PatientId = c.Long(nullable: false),
                        ProcedureId = c.Long(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            AddColumn("dbo.Patients", "DiseaseId", c => c.Long(nullable: false));
            DropColumn("dbo.Patients", "Disease");
            DropColumn("dbo.Actions", "Description");
            DropColumn("dbo.Actions", "KindAction");
            CreateIndex("dbo.PatientProcedures", "ProcedureId");
            CreateIndex("dbo.PatientProcedures", "PatientId");
            CreateIndex("dbo.Patients", "DiseaseId");
            AddForeignKey("dbo.PatientProcedures", "ProcedureId", "dbo.Procedures", "Id");
            AddForeignKey("dbo.PatientProcedures", "PatientId", "dbo.Patients", "Id");
            AddForeignKey("dbo.Patients", "DiseaseId", "dbo.Diseases", "Id");
            RenameTable(name: "dbo.Actions", newName: "Appointments");
        }
    }
}
