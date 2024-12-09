using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Contracts.Evaluation;
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
        public IActionResult Add(EvaluationCon books)
        {
            var user1 = new Evaluation()
            {
                IdComment = books.IdComment,
                Evaluation1 = books.Evaluation1,
            };
            Context.Evaluations.Add(user1);
            Context.SaveChanges();
            return Ok(user1);
        }

        [HttpPut]
        public IActionResult Update(EvaluationCon books)
        {
            Evaluation? userUp = Context.Evaluations.Where(x => x.IdComment == books.IdComment).FirstOrDefault();
            if (userUp == null)
            {
                return BadRequest("Not Found");
            }
            userUp.Evaluation1 = books.Evaluation1;
            Context.Evaluations.Add(userUp);
            Context.SaveChanges();
            return Ok(userUp);
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
