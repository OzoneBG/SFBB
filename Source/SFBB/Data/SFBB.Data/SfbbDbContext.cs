namespace SFBB.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using SFBB.Data.Migrations;
    using SFBB.Data.Models;
    using System.Data.Entity;
    using System.Linq;
    using System;
    using SFBB.Data.Common.Models;

    public class SfbbDbContext : IdentityDbContext<User>
    {
        public SfbbDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SfbbDbContext, Configuration>());
        }

        public static SfbbDbContext Create()
        {
            return new SfbbDbContext();
        }

        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<Thread> Threads { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Forum> Forums { get; set; }

        public override int SaveChanges()
        {
            ApplyAuditInfoRules();
            ApplyDeletableEntityRules();
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

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}
