using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Contracts.BooksCover;
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
        public IActionResult Add(BooksCoverCon books)
        {
            var user1 = new BooksCover()
            {
                BookId = books.BookId,
                Cover = books.Cover,
            };
            Context.BooksCovers.Add(user1);
            Context.SaveChanges();
            return Ok(user1);
        }

        [HttpPut]
        public IActionResult Update(BooksCoverCon books)
        {
            BooksCover? userUp = Context.BooksCovers.Where(x => x.BookId == books.BookId).FirstOrDefault();
            if (userUp == null)
            {
                return BadRequest("Not Found");
            }
            userUp.Cover = books.Cover;
            Context.BooksCovers.Add(userUp);
            Context.SaveChanges();
            return Ok(userUp);
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
