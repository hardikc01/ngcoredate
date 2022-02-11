using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            userRepository = _userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> Get()
        {
            var users =  await _userRepository.GetUsersAsync();
            var returnUser = _mapper.Map<IEnumerable<MemberDto>>(users);
            return Ok(returnUser);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> Get(string username)
        {
            var user =  await _userRepository.GetUserByUsernameAsync(username);
            var returnUser = _mapper.Map<MemberDto>(user);
            return Ok(returnUser);
        }

       
    }
}