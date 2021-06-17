using MentorMenteeApp.Domain.Common;
using MentorMenteeApp.Domain.Enums;
using System.Collections.Generic;

namespace MentorMenteeApp.Domain.Entities
{
    public class MentorMenteeSessionStatus : AuditableEntity
    {
        public int Id { get; set; }
        public Status Status { get; set; }

         // Relationship
         public MentorMenteeSession MentorMenteeSession { get; set; }
    }
}