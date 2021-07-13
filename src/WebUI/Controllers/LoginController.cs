using MentorMenteeApp.Application.Dto;
using MentorMenteeApp.Domain.Entities;
using MentorMenteeApp.Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorMenteeApp.WebUI.Controllers
{ 
    [ApiController]
    public class LoginController : Controller
    {
        [HttpPost("api/v1/login")]
        public IActionResult  Authenticate([FromBody]LoginRequestDto loginRequest)
        {

            return Ok();

        }
    }
}
