namespace HangfirePOC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedActivityName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "Name");
        }
    }
}
