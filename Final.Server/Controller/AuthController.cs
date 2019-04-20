using Final.Server.Common;
using Final.Server.Interface;
using Final.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Final.Server.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _authServices;

        public AuthController(IAuth authServices)
        {
            _authServices = authServices;
        }
        
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] JwtToken jwtToken)
        {
            try
            {
                return Ok(await _authServices.RefreshToken(jwtToken));
            }
            catch(RefreshTokenException)
            {
                return BadRequest(Message.InvalidRefreshToken);
            }
        }
    }
}