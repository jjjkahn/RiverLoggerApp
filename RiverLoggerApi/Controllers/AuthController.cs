using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiverLoggerApi.Models;
using RiverLoggerApi.Repository.DbModels;
using RiverLoggerApi.Services;

namespace RiverLoggerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;
        private readonly IAuthService authService;

        public AuthController( IAuthService authService, IMapper mapper)
        {
            this.authService = authService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(LoginInputModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await authService.IsAuthenticated(userModel.Email, userModel.Password))
                    {
                        var user = await authService.GetByEmail(userModel.Email);
                        var token =  authService.GenerateJwtToken(userModel.Email, user.Role);
                        return Ok(token);
                    }
                    return BadRequest("Email or password are not correct!");
                }
                return BadRequest(ModelState);
            }
            catch (Exception error)
            {
                logger.LogError(error.Message);
                return StatusCode(500);
            }
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<string>> Register(RegisterInputModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (userModel.Password != userModel.ConfirmedPassword)
                    {
                        return BadRequest("Passwords does not match!");
                    }
                    if (await authService.DoesUserExists(userModel.Email))
                    {
                        return BadRequest("User already exists!");
                    }
                    var mappedModel = this.mapper.Map<RegisterInputModel, UserDbo>(userModel);
                    mappedModel.Role = "User";

                    var user = await authService.RegisterUser(mappedModel);
                    if (user != null)
                    {
                        var token = authService.GenerateJwtToken(user.Email, mappedModel.Role);
                        return Ok(token);
                    }
                    return BadRequest("Email or password are not correct!");
                }
                return BadRequest(ModelState);
            }
            catch (Exception error)
            {
                logger.LogError(error.Message);
                return StatusCode(500);
            }
        }
    }
}
