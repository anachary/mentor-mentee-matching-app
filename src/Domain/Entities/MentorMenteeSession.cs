using MentorMenteeApp.Domain.Common;
using System;
using System.Collections.Generic;

namespace MentorMenteeApp.Domain.Entities
{
    public class MentorMenteeSession : AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public string SessionLink { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndTime { get; set; }
        public User MentorUser { get; set; }
        public User MenteeUser { get; set; }
        public List<Skill> Skills { get; set; }
        public List<MentorMenteeSessionStatus> MentorMenteeSessionStatus { get; set; }

    }
}