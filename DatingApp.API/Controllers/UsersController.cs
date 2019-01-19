using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;
        private readonly IMapper _mapper;

        public UsersController(IDataRepository dataRepository,IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _dataRepository.GetUsers();
            var userForList = _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(userForList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _dataRepository.GetUser(id);
            var UserDetailToReturn = _mapper.Map<UserForDetailedDto>(user);
            return Ok(UserDetailToReturn);
        }

    }
}