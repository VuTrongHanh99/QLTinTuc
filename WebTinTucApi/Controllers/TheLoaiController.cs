using Core.Application.Interfaces;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebTinTucApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheLoaiController : Controller
    {
        private readonly ITheLoaiServices _services;
        

        public TheLoaiController(ITheLoaiServices theLoaiServices)
        {
            _services = theLoaiServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var book = await _services.GetAllService();
            return book == null ? NotFound() : Ok(book);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _services.GetServiceById(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(TheLoaiEntity model)
        {
            try
            {
                var newBookId = await _services.AddService(model);
                return  Ok(newBookId);
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
            await _services.UpdateService(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _services.DeleteService(id);
            return Ok();
        }
    }
}
