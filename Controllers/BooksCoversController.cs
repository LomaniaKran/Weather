using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Models;

namespace Weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksCoversController : ControllerBase
    {
        public BooksContext Context { get; }

        public BooksCoversController(BooksContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<BooksCover> books = Context.BooksCovers.ToList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BooksCover? books = Context.BooksCovers.Where(x => x.BookId == id).FirstOrDefault();
            if (books == null)
            {
                return BadRequest("Не найдено короче");
            }
            return Ok(books);
        }

        [HttpPost]
        public IActionResult Add(BooksCover books)
        {
            Context.BooksCovers.Add(books);
            Context.SaveChanges();
            return Ok(books);
        }

        [HttpPut]
        public IActionResult Update(BooksCover books)
        {
            Context.BooksCovers.Add(books);
            Context.SaveChanges();
            return Ok(books);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            BooksCover? books = Context.BooksCovers.Where(x => x.BookId == id).FirstOrDefault();
            if (books == null)
            {
                return BadRequest("Не найдено короче");
            }
            Context.BooksCovers.Remove(books);
            Context.SaveChanges();
            return Ok();
        }
    }
}
