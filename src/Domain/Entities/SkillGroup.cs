using MentorMenteeApp.Domain.Common;
using System.Collections.Generic;

namespace MentorMenteeApp.Domain.Entities
{
    public class SkillGroup : AuditableEntity
    {
        public int Id { get ; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
      
        //Relationships
        public List<Skill> Skills{ get; set; }

    }
}