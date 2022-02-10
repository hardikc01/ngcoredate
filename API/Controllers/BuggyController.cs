using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret code";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var user = _context.Users.Find(-1);

            if(user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var user = _context.Users.Find(-1);
            var retUser = user.ToString();
            return retUser;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("Bad Request");
        }

        [HttpPost("test1")]
        public ActionResult<LoginDto> test1(RegisterDto u)
        {
            return Ok(u);
        }

         [HttpPost("test2")]
        public ActionResult<LoginDto> test2(LoginDto u)
        {
            return Ok(u);
        }    

    }
}