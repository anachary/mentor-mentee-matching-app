using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MentorMenteeApp.Application.Dto
{
    class UserDto
    {
    }
    public class Location
    {
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }

    public class Recipient
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("email_address")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("password_digest")]
        public string PasswordDigest { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("profile_pic")]
        public string ProfilePic { get; set; }

        [JsonPropertyName("job_title")]
        public string JobTitle { get; set; }

        [JsonPropertyName("expertiseArray")]
        public string ExpertiseArray { get; set; }

        [JsonPropertyName("bio")]
        public string Bio { get; set; }

        [JsonPropertyName("linkedin")]
        public string Linkedin { get; set; }

        [JsonPropertyName("github")]
        public string Github { get; set; }

        [JsonPropertyName("personal_website")]
        public string PersonalWebsite { get; set; }

        [JsonPropertyName("mentor_status")]
        public bool MentorStatus { get; set; }

        [JsonPropertyName("will_buy_coffee")]
        public bool WillBuyCoffee { get; set; }

        [JsonPropertyName("location_id")]
        public int LocationId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    public class Sender
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("email_address")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("password_digest")]
        public string PasswordDigest { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("profile_pic")]
        public string ProfilePic { get; set; }

        [JsonPropertyName("job_title")]
        public string JobTitle { get; set; }

        [JsonPropertyName("expertiseArray")]
        public string ExpertiseArray { get; set; }

        [JsonPropertyName("bio")]
        public string Bio { get; set; }

        [JsonPropertyName("linkedin")]
        public string Linkedin { get; set; }

        [JsonPropertyName("github")]
        public string Github { get; set; }

        [JsonPropertyName("personal_website")]
        public string PersonalWebsite { get; set; }

        [JsonPropertyName("mentor_status")]
        public bool MentorStatus { get; set; }

        [JsonPropertyName("will_buy_coffee")]
        public bool WillBuyCoffee { get; set; }

        [JsonPropertyName("location_id")]
        public int LocationId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    public class ReceivedNotification
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("recipient")]
        public Recipient Recipient { get; set; }

        [JsonPropertyName("sender")]
        public Sender Sender { get; set; }

        [JsonPropertyName("opened")]
        public bool Opened { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
    }

    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("email_address")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("mentor_status")]
        public bool MentorStatus { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("profile_pic")]
        public string ProfilePic { get; set; }

        [JsonPropertyName("job_title")]
        public string JobTitle { get; set; }

        [JsonPropertyName("expertiseArray")]
        public string ExpertiseArray { get; set; }

        [JsonPropertyName("bio")]
        public string Bio { get; set; }

        [JsonPropertyName("linkedin")]
        public string Linkedin { get; set; }

        [JsonPropertyName("github")]
        public string Github { get; set; }

        [JsonPropertyName("personal_website")]
        public string PersonalWebsite { get; set; }

        [JsonPropertyName("will_buy_coffee")]
        public bool WillBuyCoffee { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("active_relationships")]
        public List<object> ActiveRelationships { get; set; }

        [JsonPropertyName("passive_relationships")]
        public List<object> PassiveRelationships { get; set; }

        [JsonPropertyName("mentors")]
        public List<object> Mentors { get; set; }

        [JsonPropertyName("mentees")]
        public List<object> Mentees { get; set; }

        [JsonPropertyName("messages")]
        public List<object> Messages { get; set; }

        [JsonPropertyName("received_notifications")]
        public List<ReceivedNotification> ReceivedNotifications { get; set; }

        [JsonPropertyName("sent_notifications")]
        public List<object> SentNotifications { get; set; }
    }

    public class LoginResponseDTO
    {
        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("jwt")]
        public string Jwt { get; set; }
    }
}
