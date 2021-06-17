using MentorMenteeApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorMenteeApp.Domain.Entities
{
    public class User : AuditableEntity
    {
        public int UserId { get; set; }
       
        public string UserEmail { get; set; }

        public string GitHubProfile { get; set; }

        public string PersonalProfile { get; set;}

        public string Description { get; set; }

        // Relationship
        public List<Skill> MenteeSkills { get; protected set; } = new List<Skill>();

        public List<Skill> MentorSkills { get; protected set; } = new List<Skill>();

        public List<MentorMenteeSession> MenteeSessions { get; protected set; } = new List<MentorMenteeSession>();

        public List<MentorMenteeSession> MentorSessions { get; protected set; } = new List<MentorMenteeSession>();

        public List<Workshop> MenteeWorkShop { get; protected set; } = new List<Workshop>();

        public List<Workshop> MentorWorkshop { get; protected set; } = new List<Workshop>();
    }
}
