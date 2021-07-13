using AutoMapper;
using MentorMenteeApp.Application.Common.Mappings;
using MentorMenteeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorMenteeApp.Application.Users.Queries.GetUsers
{
    public class UserDto : IMapFrom<User>
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserEmail { get; set; }

        public string GitHubProfile { get; set; }

        public string PersonalProfile { get; set; }

        public string Description { get; set; }

        // Relationship
        public List<string> MenteeSkills { get; set; } = new List<string>();

        public List<string>  MentorSkills { get;  set; } = new List<string>();



        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>()
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.UserEmail, opt => opt.MapFrom(s => s.UserEmail))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.PersonalProfile, opt => opt.MapFrom(s => s.PersonalProfile))
                .ForMember(d => d.MentorSkills, opt => opt.MapFrom(s=>string.Join(',',s.MentorSkills.Select(v=>v.Name))))
                .ForMember(d => d.MenteeSkills, opt => opt.MapFrom(s => string.Join(',', s.MenteeSkills.Select(v => v.Name))));

        }

    }
}
