using MentorMenteeApp.Domain.Common;
using System;
using System.Collections.Generic;

namespace MentorMenteeApp.Domain.Entities
{
    public class Workshop : AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string SessionLink { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndTime { get; set; }
        public List<User> MentorUser { get; set; }
        public List<User> MenteeUser { get; set; }
        public List<Skill> Skills { get; set; }
    }
}