using MentorMenteeApp.Application.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MentorMenteeApp.Application.Dto
{
    public class LoginResponseDTO
    {
        [JsonPropertyName("user")]
        public UserDetailVm User { get; set; }

        [JsonPropertyName("jwt")]
        public string Jwt { get; set; }
    }
}
