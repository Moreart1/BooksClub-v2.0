using BooksClub.BL.Repositories;
using BooksClub.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksClub_v2._0.Controllers
{
    [Authorize]
    [ApiController]
    [Route("books/[controller]")]
    public class BooksController : ControllerBase
    {
        public readonly BooksRepository repository;

        public BooksController(BooksRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<ModelBooks>> GetAll()
        {
            var result = await repository.Get();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ModelBooks>> Create([FromBody] ModelBooks newBooks)
        {
            await repository.Add(newBooks);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<ModelBooks>> Update([FromBody] ModelBooks newBooks)
        {
            await repository.Update(newBooks);
            return NoContent();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ModelBooks>> Delete(int Id)
        {
            await repository.Delete(Id);
            return NoContent();
        }

    }
}