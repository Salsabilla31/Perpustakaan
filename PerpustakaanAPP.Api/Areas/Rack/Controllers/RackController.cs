using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerpustakaanAPP.Api.Areas.Rack.Outputs;
using PerpustakaanAPP.Api.Areas.Rack.Services;
using PerpustakaanAPP.Api.Areas.Rack.Models.Responses;
using PerpustakaanAPP.Api.Areas.Rack.Models.Request;


namespace PerpustakaanAPP.Api.Areas.Rack.Controllers
{
    [Area("Rack")]
    [Route("api/rack")]
    [ApiController]
    public class RackController : ControllerBase
    {
        private readonly RackService _rackService;
        public RackController(RackService rackService)
        {
            _rackService = rackService;
        }

        [HttpPost("add")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RackOutput), StatusCodes.Status200OK)]

        public async Task<IActionResult> Addsync([FromBody] RackRequestDTO req)
        {
            var objJSON = new RackOutput();
            objJSON.Data = await _rackService.AddAsync(req);
            return new OkObjectResult(objJSON);
        }

        [HttpPut("update/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RackOutput), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] RackRequestDTO req)
        {
            var objJSON = new RackOutput();
            objJSON.Data = await _rackService.UpdateAsync(id, req);
            return new OkObjectResult(objJSON);
        }

        [HttpDelete("delete/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RackOutput), StatusCodes.Status200OK)]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var objJSON = new RackOutput();
            objJSON.Data = await _rackService.DeleteAsync(id);
            return new OkObjectResult(objJSON);
        }


    }
}