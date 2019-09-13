using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyTeam.Entities
{
    public class AppDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Member> Members { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(new Team { Id = 1, Name = "Trainingstierchen" });
            modelBuilder.Entity<Member>().HasData(new Member { Id = 1, Name = "Pascal", Born = DateTime.UtcNow.Date, TeamId = 1 });
            modelBuilder.Entity<Member>().HasData(new Member { Id = 2, Name = "Emanuel", Born = DateTime.UtcNow.Date, TeamId = 1 });
            modelBuilder.Entity<Member>().HasData(new Member { Id = 3, Name = "Nils", Born = DateTime.UtcNow.Date, TeamId = 1 });
        }

        public override int SaveChanges()
        {
            var newEntities = this.ChangeTracker.Entries()
                .Where(
                    x => x.State == EntityState.Added &&
                    x.Entity != null &&
                    x.Entity as ITimestampedEntity != null
                    )
                .Select(x => x.Entity as ITimestampedEntity);

            var modifiedEntities = this.ChangeTracker.Entries()
                .Where(
                    x => x.State == EntityState.Modified &&
                    x.Entity != null &&
                    x.Entity as ITimestampedEntity != null
                    )
                .Select(x => x.Entity as ITimestampedEntity);

            foreach (var newEntity in newEntities)
            {
                newEntity.CreatedAt = DateTime.UtcNow;
                newEntity.LastModified = DateTime.UtcNow;
            }

            foreach (var modifiedEntity in modifiedEntities)
            {
                modifiedEntity.LastModified = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }
    }

}