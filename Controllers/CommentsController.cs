using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml.Linq;
using Weather.Contracts.Comment;
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
        public IActionResult Add(CommentCon books)
        {
            var user1 = new Comment()
            {
                BookId = books.BookId,
                UserId = books.UserId,
                CrData = books.CrData,
                CrTime = books.CrTime,
                ChData = books.ChData,
                ChTime = books.ChTime,
                Comment1 = books.Comment1,
            };
            Context.Comments.Add(user1);
            Context.SaveChanges();
            return Ok(user1);
        }

        [HttpPut]
        public IActionResult Update(ChCommentCon books)
        {
            Comment? userUp = Context.Comments.Where(x => x.IdComment == books.IdComment).FirstOrDefault();
            if (userUp == null)
            {
                return BadRequest("Not Found");
            }
            userUp.BookId = books.BookId;
            userUp.UserId = books.UserId;
            userUp.CrData = books.CrData;
            userUp.CrTime = books.CrTime;
            userUp.ChData = books.ChData;
            userUp.ChTime = books.ChTime;
            userUp.Comment1 = books.Comment1;
            Context.Comments.Add(userUp);
            Context.SaveChanges();
            return Ok(userUp);
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
