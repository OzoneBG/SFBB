namespace SFBB.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;

    using SFBB.Data.Common.Models;
    using SFBB.Data.Migrations;
    using SFBB.Data.Models;

    public class SfbbDbContext : IdentityDbContext<User>
    {
        public SfbbDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SfbbDbContext, Configuration>());
        }

        public IDbSet<Thread> Threads { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Forum> Forums { get; set; }

        public IDbSet<Reply> Replies { get; set; }
        
        public static SfbbDbContext Create()
        {
            return new SfbbDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
