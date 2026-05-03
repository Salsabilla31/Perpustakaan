using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerpustakaanAPP.Api.Areas.Book.Outputs;
using PerpustakaanAPP.Api.Areas.Book.Services;
using PerpustakaanAPP.Api.Areas.Book.Models.Resposes;
using PerpustakaanAPP.Api.Areas.Book.Models.Request;


namespace PerpustakaanAPP.Api.Areas.Book.Controllers
{
    [Area("Book")]
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("add")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BookOutput), StatusCodes.Status200OK)]
        
        public async Task<IActionResult> Addsync([FromBody] BookRequestDTO req)
        {
            var objJSON = new BookOutput();
            objJSON.Data = await _bookService.AddAsync(req);
            return new OkObjectResult(objJSON);
        }

        [HttpPut("update/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BookOutput), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] BookRequestDTO req)
        {
            var objJSON = new BookOutput();
            objJSON.Data = await _bookService.UpdateAsync(id, req);
            return new OkObjectResult(objJSON);
        }

        [HttpDelete("delete/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BookOutput), StatusCodes.Status200OK)]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var objJSON = new BookOutput();
            objJSON.Data = await _bookService.DeleteAsync(id);
            return new OkObjectResult(objJSON);
        }


    }
}