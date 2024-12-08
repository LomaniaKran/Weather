using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Models;

namespace Weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksAdditsController : ControllerBase
    {
        public BooksContext Context { get; }

        public BooksAdditsController(BooksContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<BooksAddit> books = Context.BooksAddits.ToList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BooksAddit? books = Context.BooksAddits.Where(x => x.BookId == id).FirstOrDefault();
            if (books == null)
            {
                return BadRequest("Не найдено короче");
            }
            return Ok(books);
        }

        [HttpPost]
        public IActionResult Add(BooksAddit books)
        {
            Context.BooksAddits.Add(books);
            Context.SaveChanges();
            return Ok(books);
        }

        [HttpPut]
        public IActionResult Update(BooksAddit books)
        {
            Context.BooksAddits.Add(books);
            Context.SaveChanges();
            return Ok(books);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            BooksAddit? books = Context.BooksAddits.Where(x => x.BookId == id).FirstOrDefault();
            if (books == null)
            {
                return BadRequest("Не найдено короче");
            }
            Context.BooksAddits.Remove(books);
            Context.SaveChanges();
            return Ok();
        }
    }
}
