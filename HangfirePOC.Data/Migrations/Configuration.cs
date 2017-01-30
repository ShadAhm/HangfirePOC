namespace HangfirePOC.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HangfirePOC.Data.EDM.ActivitiesDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HangfirePOC.Data.EDM.ActivitiesDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Activities.AddOrUpdate(
                    new Model.Activity { Name = "Activity 1" },
                    new Model.Activity {  Name = "Activity 2"},
                    new Model.Activity {  Name = "Activity 3"}
                );
        }
    }
}
