using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.AuthServices;

namespace API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IAuthService _authService;

        public UserController(
            IAuthService authService
            )
        {
            _authService = authService;
        }

        [HttpPost("authenticate")]
        public IActionResult Post(string username, string pass)
        {
            return Ok();
        }

        [HttpGet]
        [CustomAuthorize]
        public IActionResult Get()
        {


            return Ok();
        }
    }
}
