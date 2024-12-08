using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Models;

namespace Weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationsController : ControllerBase
    {
        public BooksContext Context { get; }

        public EvaluationsController(BooksContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Evaluation> books = Context.Evaluations.ToList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Evaluation? books = Context.Evaluations.Where(x => x.IdComment == id).FirstOrDefault();
            if (books == null)
            {
                return BadRequest("Не найдено короче");
            }
            return Ok(books);
        }

        [HttpPost]
        public IActionResult Add(Evaluation books)
        {
            Context.Evaluations.Add(books);
            Context.SaveChanges();
            return Ok(books);
        }

        [HttpPut]
        public IActionResult Update(Evaluation books)
        {
            Context.Evaluations.Add(books);
            Context.SaveChanges();
            return Ok(books);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Evaluation? books = Context.Evaluations.Where(x => x.IdComment == id).FirstOrDefault();
            if (books == null)
            {
                return BadRequest("Не найдено короче");
            }
            Context.Evaluations.Remove(books);
            Context.SaveChanges();
            return Ok();
        }
    }
}
