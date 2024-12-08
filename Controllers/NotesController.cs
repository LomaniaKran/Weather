using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Models;

namespace Weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        public BooksContext Context { get; }

        public NotesController(BooksContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Note> books = Context.Notes.ToList();
            return Ok(books);
        }

        [HttpGet("id")]
        public IActionResult GetById(int idB, int idU)
        {
            Note? books = Context.Notes.Where(x => x.BookId == idB & x.UserId == idU).FirstOrDefault();
            if (books == null)
            {
                return BadRequest("Не найдено короче");
            }
            return Ok(books);
        }

        [HttpPost]
        public IActionResult Add(Note books)
        {
            Context.Notes.Add(books);
            Context.SaveChanges();
            return Ok(books);
        }

        [HttpPut]
        public IActionResult Update(Note books)
        {
            Context.Notes.Add(books);
            Context.SaveChanges();
            return Ok(books);
        }

        [HttpDelete]
        public IActionResult Delete(int idB, int idU)
        {
            Note? books = Context.Notes.Where(x => x.BookId == idB & x.UserId == idU).FirstOrDefault();
            if (books == null)
            {
                return BadRequest("Не найдено короче");
            }
            Context.Notes.Remove(books);
            Context.SaveChanges();
            return Ok();
        }
    }
}
