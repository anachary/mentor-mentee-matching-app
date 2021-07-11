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
    public class LoginController : Controller
    {
        [HttpPost("v1/login")]
        public JsonResult Authenticate([FromBody] ApplicationUser applicationUser)
        {
            var loginResponseDto = new LoginResponseDTO();
            return Json(loginResponseDto);

        }
    }
}
