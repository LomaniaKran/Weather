using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Contracts.Author;
using Weather.Models;

namespace Weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuhtorsController : ControllerBase
    {
        public BooksContext Context { get; }

        public AuhtorsController(BooksContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Author> authors = Context.Authors.ToList();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Author? authors = Context.Authors.Where(x => x.Id == id).FirstOrDefault();
            if (authors == null)
            {
                return BadRequest("Не найдено короче");
            }
            return Ok(authors);
        }

        [HttpPost]
        public IActionResult Add(AuthorContr authors)
        {
            var user1 = new Author()
            {
                BookId = authors.BookId,
                FirstName = authors.FirstName,
                LastName = authors.LastName,
                Patronymic = authors.Patronymic,
            };
            Context.Authors.Add(user1);
            Context.SaveChanges();
            return Ok(user1);
        }

        [HttpPut]
        public IActionResult Update(ChAuthorContr authors)
        {
            Author? userUp = Context.Authors.Where(x => x.Id == authors.Id).FirstOrDefault();
            if (userUp == null)
            {
                return BadRequest("Not Found");
            }
            userUp.BookId = authors.BookId;
            userUp.FirstName = authors.FirstName;
            userUp.LastName = authors.LastName;
            userUp.Patronymic = authors.Patronymic;
            Context.Authors.Add(userUp);
            Context.SaveChanges();
            return Ok(userUp);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Author? authors = Context.Authors.Where(x => x.Id == id).FirstOrDefault();
            if (authors == null)
            {
                return BadRequest("Не найдено короче");
            }
            Context.Authors.Remove(authors);
            Context.SaveChanges();
            return Ok();
        }
    }
}
