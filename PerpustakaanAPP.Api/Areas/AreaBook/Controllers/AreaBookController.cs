using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerpustakaanAPP.Api.Areas.AreaBook.Outputs;
using PerpustakaanAPP.Api.Areas.AreaBook.Services;
using PerpustakaanAPP.Api.Areas.AreaBook.Models.Responses;
using PerpustakaanAPP.Api.Areas.AreaBook.Models.Request;


namespace PerpustakaanAPP.Api.Areas.AreaBook.Controllers
{
    [Area("AreaBook")]
    [Route("api/areabook")]
    [ApiController]
    public class AreaBookController : ControllerBase
    {
        private readonly AreaBookService _areaBookService;  
        public AreaBookController(AreaBookService areaBookService)
        {
            _areaBookService = areaBookService;
        }

        [HttpPost("add")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AreaBookOutput), StatusCodes.Status200OK)]

        public async Task<IActionResult> Addsync([FromBody] AreaBookRequestDTO req)
        {
            var objJSON = new AreaBookOutput();
            objJSON.Data = await _areaBookService.AddAsync(req);
            return new OkObjectResult(objJSON);
        }

        [HttpPut("update/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AreaBookOutput), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] AreaBookRequestDTO req)
        {
            var objJSON = new AreaBookOutput();
            objJSON.Data = await _areaBookService.UpdateAsync(id, req);
            return new OkObjectResult(objJSON);
        }

        [HttpDelete("delete/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AreaBookOutput), StatusCodes.Status200OK)]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var objJSON = new AreaBookOutput();
            objJSON.Data = await _areaBookService.DeleteAsync(id);
            return new OkObjectResult(objJSON);
        }


    }
}