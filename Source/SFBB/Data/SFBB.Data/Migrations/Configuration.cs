namespace SFBB.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SFBB.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<SfbbDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //TO DO: Remove in production
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SfbbDbContext context)
        {
         
        }
    }
}
