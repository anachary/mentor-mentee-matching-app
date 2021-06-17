using MentorMenteeApp.Application.Common.Interfaces;
using MentorMenteeApp.Domain.Common;
using MentorMenteeApp.Domain.Entities;
using MentorMenteeApp.Infrastructure.Identity;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MentorMenteeApp.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService,
            IDateTime dateTime) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<SkillGroup> SkillGroups { get; set; }

        public DbSet<Workshop> Workshops { get; set; }

        public DbSet<MentorMenteeSession> MentorMenteeSessions { get; set; }

        public DbSet<MentorMenteeSessionStatus> MenteeSessionStatuses { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany(u => u.MenteeSessions);

            builder.Entity<User>()
                .HasMany(u => u.MentorSkills);

            builder.Entity<User>()
            .   HasMany(u => u.MenteeSkills);

            builder.Entity<User>()
                .HasMany(u => u.MenteeWorkShop);
            builder.Entity<User>()
                 .HasMany(u => u.MentorWorkshop);

            builder.Entity<User>()
                .HasMany(u => u.MentorSessions);

            builder.Entity<Skill>()
                .HasOne(s=>s.SkillGroup);

            builder.Entity<Skill>()
                .HasMany(s => s.MentorSkillUsers);

            builder.Entity<Skill>()
                .HasMany(s => s.MenteeSkillUsers);

            builder.Entity<Skill>()
               .HasMany(s => s.IndividualScheduledSession);

            builder.Entity<Skill>()
                      .HasMany(s => s.Workshops);

            builder.Entity<MentorMenteeSession>()
                .HasOne(s => s.MenteeUser);
            builder.Entity<MentorMenteeSession>()
                .HasOne(s => s.MentorUser);
            builder.Entity<MentorMenteeSession>()
                .HasMany(s => s.MentorMenteeSessionStatus);
            builder.Entity<MentorMenteeSession>()
               .HasMany(s => s.Skills);


            builder.Entity<Workshop>()
              .HasMany(s => s.Skills);
            builder.Entity<Workshop>()
                .HasMany(s => s.MentorUser);
            builder.Entity<Workshop>()
                .HasMany(s => s.MenteeUser);
            builder.Entity<Workshop>()
               .HasMany(s => s.Skills);
        }


    }
}
