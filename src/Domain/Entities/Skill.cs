using MentorMenteeApp.Domain.Common;
using System.Collections.Generic;

namespace MentorMenteeApp.Domain.Entities
{
    public class Skill : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // RelationShips
        public SkillGroup SkillGroup {get;set;} // Parent Umberella
        public List<User> MenteeSkillUsers { get; private set; } = new List<User>(); // who wants to learn  this skill ainkanskywalker group
        public List<User> MentorSkillUsers{ get; private set; } = new List<User>(); // list of user who are mentor in the skill yoda group
        public List<MentorMenteeSession> IndividualScheduledSession { get; private set; } = new List<MentorMenteeSession>(); // individual session scheduled for this skill
        public List<Workshop> Workshops { get; private set; } = new List<Workshop>(); // Workshop which involves list of the skill
    }
}