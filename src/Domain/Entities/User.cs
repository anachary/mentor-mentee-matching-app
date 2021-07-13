using MentorMenteeApp.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorMenteeApp.Domain.Entities
{
    public class User : IdentityUser
    {
       
        public string FirstName { get; set; }

        public string LastName { get; set; }
       
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
        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }
    }
}
