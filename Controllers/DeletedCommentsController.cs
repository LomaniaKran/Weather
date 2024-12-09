using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Contracts.DeletedComment;
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
        public IActionResult Add(DeletedCommentCon books)
        {
            var user1 = new DeletedComment()
            {
                IdComment = books.IdComment,
                DeletedData = books.DeletedData,
                DeletedTime = books.DeletedTime,
            };
            Context.DeletedComments.Add(user1);
            Context.SaveChanges();
            return Ok(user1);
        }

        [HttpPut]
        public IActionResult Update(DeletedCommentCon books)
        {
            DeletedComment? userUp = Context.DeletedComments.Where(x => x.IdComment == books.IdComment).FirstOrDefault();
            if (userUp == null)
            {
                return BadRequest("Not Found");
            }
            userUp.IdComment = books.IdComment;
            userUp.DeletedData = books.DeletedData;
            userUp.DeletedTime = books.DeletedTime;
            Context.DeletedComments.Add(userUp);
            Context.SaveChanges();
            return Ok(userUp);
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
