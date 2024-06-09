using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RiverLoggerApi.Configuration;
using RiverLoggerApi.Models;
using RiverLoggerApi.Services;
using System.IdentityModel.Tokens.Jwt;

namespace RiverLoggerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        //private readonly IUserService _userService;
        //private readonly JwtMiddleware _jwtHandler;
        //public AccountsController(IUserService userService, JwtMiddleware jwtHandler)
        //{
        //    _userService = userService;
        //    _jwtHandler = jwtHandler;
        //}
        //[HttpPost("Login")]
        //public async Task<IActionResult> Login([FromBody] AuthenticateRequest userForAuthentication)
        //{
        //    var user = await _userService.GetByEmail(userForAuthentication.Email);
        //    if (user == null) // need to check for password still
        //        return Unauthorized(new AuthenticateResponse { ErrorMessage = "Invalid Authentication" });
        //    var signingCredentials = _jwtHandler.GetSigningCredentials();
        //    var claims = _jwtHandler.GetClaims(user);
        //    var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
        //    var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        //    return Ok(new AuthenticateResponse { IsAuthSuccessful = true, Token = token });
        //}
    }
}
