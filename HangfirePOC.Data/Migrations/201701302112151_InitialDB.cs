namespace HangfirePOC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ActivitySchedules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OptimizationRequestID = c.Int(),
                        ActivityID = c.Int(nullable: false),
                        Name = c.String(),
                        RunType = c.Int(nullable: false),
                        DelayValue = c.Int(nullable: false),
                        Description = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Activities", t => t.ActivityID, cascadeDelete: true)
                .ForeignKey("dbo.OptimizationRequests", t => t.OptimizationRequestID)
                .Index(t => t.OptimizationRequestID)
                .Index(t => t.ActivityID);
            
            CreateTable(
                "dbo.OptimizationRequests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RequestDate = c.DateTime(nullable: false),
                        ScheduleDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActivitySchedules", "OptimizationRequestID", "dbo.OptimizationRequests");
            DropForeignKey("dbo.ActivitySchedules", "ActivityID", "dbo.Activities");
            DropIndex("dbo.ActivitySchedules", new[] { "ActivityID" });
            DropIndex("dbo.ActivitySchedules", new[] { "OptimizationRequestID" });
            DropTable("dbo.OptimizationRequests");
            DropTable("dbo.ActivitySchedules");
            DropTable("dbo.Activities");
        }
    }
}
