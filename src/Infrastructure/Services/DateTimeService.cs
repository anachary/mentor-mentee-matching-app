using MentorMenteeApp.Application.Common.Interfaces;
using System;

namespace MentorMenteeApp.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
