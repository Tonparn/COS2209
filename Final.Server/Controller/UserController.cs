using Final.Server.Interface;
using Final.Shared;
using Microsoft.AspNetCore.Mvc;
using Final.Server.Validation;
using System;
using System.Threading.Tasks;
using Final.Server.Common;

namespace Final.Server.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser _userServices;

        public UserController(IUser userServices, IAuth authServices)
        {
            _userServices = userServices;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Register([FromBody] UserParam user)
        {
            try
            {
                UserValidation.ValidateRegister(user);

                await _userServices.Register(user);

                return Ok(Message.RegisterSuccess);
            }
            catch(RegisterException)
            {
                return Conflict(Message.NameAlready);
            }
            catch(AggregateException)
            {
                return Conflict(Message.EmailAlready);
            }
            catch (EmailException)
            {
                return BadRequest(Message.InvalidEmail);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Credentials credens)
        {
            try
            {
                UserValidation.ValidateLogin(credens);

                return Ok(await _userServices.Login(credens));
            }
            catch (LoginException)
            {
                return BadRequest(Message.InvalidCredens);
            }
            catch(WhiteSpaceException)
            {
                return BadRequest(Message.CredensWhiteSpace);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] JwtToken token)
        {
            await _userServices.Logout(token.Name);

            return Ok();
        }
    }
}