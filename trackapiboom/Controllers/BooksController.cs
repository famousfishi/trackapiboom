using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using trackapiboom.DTOs;
using trackapiboom.Repository.InterfaceServiceTypes;

namespace trackapiboom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            List<BookDTO> data = await _repository.GetAllBooksAsync();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookByIdAsync([FromRoute] int id)
        {
            BookDTO data = await _repository.GetBookByIdAsync(id);

            if (data == null)
            {
                return NotFound($"Book with this ID - {id} is not found");
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddBookAsync([FromBody] BookDTO bookDTO)
        {
            if (bookDTO == null)
            {
                return BadRequest("Client error, check your payload");
            }
            int newBook = await _repository.AddBooksAsync(bookDTO);

            return Ok(newBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookByIdAsync([FromBody] BookDTO bookDTO, [FromRoute] int id)
        {
            await _repository.UpdateBookByIdAsync(id, bookDTO);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _repository.DeleteBook(id);

            return Ok();
        }
    }
}