using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Weather.Models;

namespace Weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        public BooksContext Context { get; }

        public CommentsController(BooksContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Comment> books = Context.Comments.ToList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Comment? books = Context.Comments.Where(x => x.IdComment == id).FirstOrDefault();
            if (books == null)
            {
                return BadRequest("Не найдено короче");
            }
            return Ok(books);
        }

        [HttpPost]
        public IActionResult Add(Comment books)
        {
            Context.Comments.Add(books);
            Context.SaveChanges();
            return Ok(books);
        }

        [HttpPut]
        public IActionResult Update(Comment books)
        {
            Context.Comments.Add(books);
            Context.SaveChanges();
            return Ok(books);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Comment? books = Context.Comments.Where(x => x.IdComment == id).FirstOrDefault();
            if (books == null)
            {
                return BadRequest("Не найдено короче");
            }
            Context.Comments.Remove(books);
            Context.SaveChanges();
            return Ok();
        }
    }
}
