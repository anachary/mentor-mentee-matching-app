using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MentorMenteeApp.Application.Dto
{
    public class LoginRequestDto
    {
        
        [JsonPropertyName("email_address")]
        string EmailAddress { get; set; }

        [JsonPropertyName("password")]
        string Password { get; set; }
    }
}
