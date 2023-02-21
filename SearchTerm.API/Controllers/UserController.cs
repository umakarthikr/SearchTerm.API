using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SearchTerm.API.Entities;
using SearchTerm.API.Requests.Model;
using SearchTerm.API.Services;

namespace SearchTerm.API.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : Controller
    {
        private IUserService _userService;
        private IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _mapper.Map<User>(request);
            var response = await _userService.CreateAsync(user);

            return CreatedAtAction("GetUserById", new { id = response.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(int id)
        {
            var userInfo = await _userService.GetUserAsync(id);
            if(userInfo == null)
            {
                return NotFound();
            }

            return userInfo;
        }

        [HttpGet]
        [Route("Search/")]
        public async Task<IActionResult> GetUsersAsync(string searchString)
        {
            var matchingUsers = await _userService.GetUsersAsync(searchString);
            return Ok(matchingUsers);
        }

    }
}
