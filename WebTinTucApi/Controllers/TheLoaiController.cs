using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebTinTucApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheLoaiController : Controller
    {
        private readonly ITheLoaiRepository _bookRepository;
        private readonly ILogger<TheLoaiController> _logger;

        public TheLoaiController(ITheLoaiRepository repo, ILogger<TheLoaiController> logger)
        {
            _bookRepository = repo;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                return Ok(await _bookRepository.GetAllBooksAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookAsync(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(TheLoaiEntity model)
        {
            try
            {
                var newBookId = await _bookRepository.AddBookAsync(model);
                var book = await _bookRepository.GetBookAsync(newBookId);
                return book == null ? NotFound() : Ok(book);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] TheLoaiEntity model)
        {
            if (id != model.CategoryId)
            {
                return NotFound();
            }
            await _bookRepository.UpdateBookAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return Ok();
        }
    }
}
