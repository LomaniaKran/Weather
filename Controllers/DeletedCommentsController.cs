using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Models;

namespace Weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeletedCommentsController : ControllerBase
    {
        public BooksContext Context { get; }

        public DeletedCommentsController(BooksContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<DeletedComment> books = Context.DeletedComments.ToList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            DeletedComment? books = Context.DeletedComments.Where(x => x.IdComment == id).FirstOrDefault();
            if (books == null)
            {
                return BadRequest("Не найдено короче");
            }
            return Ok(books);
        }

        [HttpPost]
        public IActionResult Add(DeletedComment books)
        {
            Context.DeletedComments.Add(books);
            Context.SaveChanges();
            return Ok(books);
        }

        [HttpPut]
        public IActionResult Update(DeletedComment books)
        {
            Context.DeletedComments.Add(books);
            Context.SaveChanges();
            return Ok(books);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            DeletedComment? books = Context.DeletedComments.Where(x => x.IdComment == id).FirstOrDefault();
            if (books == null)
            {
                return BadRequest("Не найдено короче");
            }
            Context.DeletedComments.Remove(books);
            Context.SaveChanges();
            return Ok();
        }
    }
}
