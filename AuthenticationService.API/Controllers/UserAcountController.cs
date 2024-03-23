using AuthenticationService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserAcountController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandeler;

        public UserAcountController(JwtTokenHandler jwtTokenHandler)
        {
            this._jwtTokenHandeler = jwtTokenHandler;
        }

        [HttpPost]
        public ActionResult<AuthenticationResponseDto?> Login(AuthenticationRequestDto authenticationRequestDto)
        {
            var result = _jwtTokenHandeler.GenerateJwtToken(authenticationRequestDto);
            if (result == null) return Unauthorized();
            return Ok(result);
        }
    }
}
