namespace HangfirePOC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecurringScheduleType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActivitySchedules", "RecurringScheduleType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ActivitySchedules", "RecurringScheduleType");
        }
    }
}
