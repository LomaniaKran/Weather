using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Contracts.BooksAddit;
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
        public IActionResult Add(BooksAdditCon books)
        {
            var user1 = new BooksAddit()
            {
                BookId = books.BookId,
                ShortDescription = books.ShortDescription,
            };
            Context.BooksAddits.Add(user1);
            Context.SaveChanges();
            return Ok(user1);
        }

        [HttpPut]
        public IActionResult Update(BooksAdditCon books)
        {
            BooksAddit? userUp = Context.BooksAddits.Where(x => x.BookId == books.BookId).FirstOrDefault();
            if (userUp == null)
            {
                return BadRequest("Not Found");
            }
            userUp.ShortDescription = books.ShortDescription;
            Context.BooksAddits.Add(userUp);
            Context.SaveChanges();
            return Ok(userUp);
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
