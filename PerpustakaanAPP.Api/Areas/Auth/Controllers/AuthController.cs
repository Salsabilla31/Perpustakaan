using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerpustakaanAPP.Api.Areas.Auth.Models.Request;
using PerpustakaanAPP.Api.Areas.Auth.Outputs;
using PerpustakaanAPP.Api.Areas.Auth.Services;

namespace PerpustakaanAPP.Api.Areas.Auth.Controllers
{
    [Area("Auth")]
    [Route("api/auths")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("register")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AuthRegisterOuput), StatusCodes.Status200OK)]
        public IActionResult Register([FromBody] AuthRegisterRequestDTO req)
        {
            var objJSON = new AuthRegisterOuput();
            objJSON.Data = _authService.Register(req);
            return new OkObjectResult(objJSON);
        }
    }
}
