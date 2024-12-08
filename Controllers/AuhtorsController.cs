using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Add(Author authors)
        {
            Context.Authors.Add(authors);
            Context.SaveChanges();
            return Ok(authors);
        }

        [HttpPut]
        public IActionResult Update(Author authors)
        {
            Context.Authors.Add(authors);
            Context.SaveChanges();
            return Ok(authors);
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
