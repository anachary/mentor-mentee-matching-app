using MentorMenteeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace MentorMenteeApp.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Skill> Skills { get; set; }

        public DbSet<SkillGroup> SkillGroups { get; set; }

        public DbSet<Workshop> Workshops { get; set; }

        public DbSet<MentorMenteeSession> MentorMenteeSessions { get; set; }

        public DbSet<MentorMenteeSessionStatus> MenteeSessionStatuses { get; set; }
        public DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
