using System.Security.Claims;
using API.Dtos;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        // This method will get the currently logged in user based on the token that they have stored
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            // To access the User you must be using the [Authorize] attribute otherwise it won't be available
            var user = await _userManager.FindByEmailFromClaimsPrincipal(User);

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };
        }

        // Useful for validation on the client side, we don't actually need to do this check from the server side and identity takes care of that
        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<AddressDto>> GetUserAddress()
        {
            var user = await _userManager.FindUserByClaimsPrincipleWithAddress(User);

            return _mapper.Map<Address, AddressDto>(user.Address);
        }

        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto address)
        {
            var user = await _userManager.FindUserByClaimsPrincipleWithAddress(User);

            user.Address = _mapper.Map<AddressDto, Address>(address);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded) return Ok(_mapper.Map<Address, AddressDto>(user.Address));

            return BadRequest("Problem updating the user");
        }

        // Returning a simpler UserDto since AppUser has too much information from identity
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            // Retreive the user by their email
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized(new ApiResponse(401));

            // Check the password. Returns an Identity.SignInResult
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email // required for identity
            };

            // Returns an IdentityResult
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(new ApiResponse(400)); // Should probably tell the user what they did wrong (ex weak password), we'll do this later in the course

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user),
                Email = user.Email
            };
        }
    }
}