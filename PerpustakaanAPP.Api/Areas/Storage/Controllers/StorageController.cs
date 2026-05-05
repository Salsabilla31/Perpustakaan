using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerpustakaanAPP.Api.Areas.Storage.Outputs;
using PerpustakaanAPP.Api.Areas.Storage.Services;
using PerpustakaanAPP.Api.Areas.Storage.Models.Response;
using PerpustakaanAPP.Api.Areas.Storage.Models.Request;


namespace PerpustakaanAPP.Api.Areas.Storage.Controllers
{
    [Area("Storage")]
    [Route("api/storage")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly StorageService _storageService;

        public StorageController(StorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpPost("add")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(StorageOutput), StatusCodes.Status200OK)]

        public async Task<IActionResult> Addsync([FromBody] StorageRequestDTO req)
        {
            var objJSON = new StorageOutput();
            objJSON.Data = await _storageService.AddAsync(req);
            return new OkObjectResult(objJSON);
        }

        [HttpPut("update/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(StorageOutput), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] StorageRequestDTO req)
        {
            var objJSON = new StorageOutput();
            objJSON.Data = await _storageService.UpdateAsync(id, req);
            return new OkObjectResult(objJSON);
        }

        [HttpDelete("delete/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(StorageOutput), StatusCodes.Status200OK)]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var objJSON = new StorageOutput();
            objJSON.Data = await _storageService.DeleteAsync(id);
            return new OkObjectResult(objJSON);
        }


    }
}