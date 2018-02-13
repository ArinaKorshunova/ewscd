namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUser : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Appointments", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Doctors", "UserId", c => c.Long(nullable: false));
            AddColumn("dbo.Doctors", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Patients", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CuratorPatients", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Curators", "UserId", c => c.Long(nullable: false));
            AddColumn("dbo.Curators", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Diseases", "Description", c => c.String());
            AddColumn("dbo.Diseases", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DiseaseProcedures", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Procedures", "DEscription", c => c.String());
            AddColumn("dbo.Procedures", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PatientDiseases", "CreateDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Doctors", "UserId");
            CreateIndex("dbo.Curators", "UserId");
            AddForeignKey("dbo.Doctors", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Curators", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Curators", "UserId", "dbo.Users");
            DropForeignKey("dbo.Doctors", "UserId", "dbo.Users");
            DropIndex("dbo.Curators", new[] { "UserId" });
            DropIndex("dbo.Doctors", new[] { "UserId" });
            DropColumn("dbo.PatientDiseases", "CreateDate");
            DropColumn("dbo.Procedures", "CreateDate");
            DropColumn("dbo.Procedures", "DEscription");
            DropColumn("dbo.DiseaseProcedures", "CreateDate");
            DropColumn("dbo.Diseases", "CreateDate");
            DropColumn("dbo.Diseases", "Description");
            DropColumn("dbo.Curators", "CreateDate");
            DropColumn("dbo.Curators", "UserId");
            DropColumn("dbo.CuratorPatients", "CreateDate");
            DropColumn("dbo.Patients", "CreateDate");
            DropColumn("dbo.Doctors", "CreateDate");
            DropColumn("dbo.Doctors", "UserId");
            DropColumn("dbo.Appointments", "CreateDate");
            DropTable("dbo.Users");
        }
    }
}
