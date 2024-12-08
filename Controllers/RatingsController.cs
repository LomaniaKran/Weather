using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Models;

namespace Weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        public BooksContext Context { get; }

        public RatingsController(BooksContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Rating> books = Context.Ratings.ToList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Rating? books = Context.Ratings.Where(x => x.BookId == id).FirstOrDefault();
            if (books == null)
            {
                return BadRequest("Не найдено короче");
            }
            return Ok(books);
        }

        [HttpPost]
        public IActionResult Add(Rating books)
        {
            Context.Ratings.Add(books);
            Context.SaveChanges();
            return Ok(books);
        }

        [HttpPut]
        public IActionResult Update(Rating books)
        {
            Context.Ratings.Add(books);
            Context.SaveChanges();
            return Ok(books);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Rating? books = Context.Ratings.Where(x => x.BookId == id).FirstOrDefault();
            if (books == null)
            {
                return BadRequest("Не найдено короче");
            }
            Context.Ratings.Remove(books);
            Context.SaveChanges();
            return Ok();
        }
    }
}
