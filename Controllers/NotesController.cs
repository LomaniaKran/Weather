using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Contracts.Note;
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
        public IActionResult Add(NoteCon books)
        {
            var user1 = new Note()
            {
                BookId = books.BookId,
                UserId = books.UserId,
                Note1 = books.Note1,
            };
            Context.Notes.Add(user1);
            Context.SaveChanges();
            return Ok(user1);
        }

        [HttpPut]
        public IActionResult Update(NoteCon books)
        {
            Note? userUp = Context.Notes.Where(x => x.BookId == books.BookId && x.UserId == books.UserId).FirstOrDefault();
            if (userUp == null)
            {
                return BadRequest("Not Found");
            }
            userUp.Note1 = books.Note1;
            Context.Notes.Add(userUp);
            Context.SaveChanges();
            return Ok(userUp);
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
