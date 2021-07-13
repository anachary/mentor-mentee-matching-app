using AutoMapper;
using MentorMenteeApp.Application.Common.Mappings;
using MentorMenteeApp.Application.Users.Queries.GetUsers;
using MentorMenteeApp.Domain.Entities;
using System.Collections.Generic;

namespace MentorMenteeApp.Application.Users.Queries
{
    public class UserDetailVm : IMapFrom<User>
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserEmail { get; set; }

        public string GitHubProfile { get; set; }

        public string PersonalProfile { get; set; }

        public string Description { get; set; }

        // Relationship
        public List<SkillDto> MenteeSkills { get; protected set; } = new List<SkillDto>();

        public List<SkillDto> MentorSkills { get; protected set; } = new List<SkillDto>();

        public List<MentorMenteeSessionDto> MenteeSessions { get; protected set; } = new List<MentorMenteeSessionDto>();

        public List<MentorMenteeSessionDto> MentorSessions { get; protected set; } = new List<MentorMenteeSessionDto>();

        public List<WorkshopDto> MenteeWorkShop { get; protected set; } = new List<WorkshopDto>();

        public List<WorkshopDto> MentorWorkshop { get; protected set; } = new List<WorkshopDto>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailVm>()
                .ForMember(v => v.MenteeSkills, opt => opt.MapFrom(v => v.MentorSkills))
                .ForMember(v => v.MentorSkills, opt => opt.MapFrom(v => v.MentorSkills))
                .ForMember(v => v.MentorSessions, opt => opt.MapFrom(v => v.MentorSessions))
                .ForMember(v => v.MenteeSessions, opt => opt.MapFrom(v => v.MenteeSessions))
                .ForMember(v => v.MenteeWorkShop, opt => opt.MapFrom(v => v.MentorSessions))
                .ForMember(v => v.MentorWorkshop, opt => opt.MapFrom(v => v.MenteeSessions));

        }
    }
}