namespace HangfirePOC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        ActivityID = c.Int(nullable: false),
                        Name = c.String(),
                        RunType = c.Int(nullable: false),
                        DelayValue = c.Int(nullable: false),
                        DelayType = c.Int(nullable: false),
                        Description = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        RecurringScheduleType = c.Int(nullable: false),
                        LastRun = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Activities", t => t.ActivityID, cascadeDelete: true)
                .Index(t => t.ActivityID);
            
            CreateTable(
                "dbo.ActivityScheduleLines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RequestDate = c.DateTime(nullable: false),
                        ScheduleDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        ActivityScheduleID = c.Int(nullable: false),
                        ScheduleLineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ActivitySchedules", t => t.ActivityScheduleID, cascadeDelete: true)
                .Index(t => t.ActivityScheduleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActivityScheduleLines", "ActivityScheduleID", "dbo.ActivitySchedules");
            DropForeignKey("dbo.ActivitySchedules", "ActivityID", "dbo.Activities");
            DropIndex("dbo.ActivityScheduleLines", new[] { "ActivityScheduleID" });
            DropIndex("dbo.ActivitySchedules", new[] { "ActivityID" });
            DropTable("dbo.ActivityScheduleLines");
            DropTable("dbo.ActivitySchedules");
            DropTable("dbo.Activities");
        }
    }
}
