using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Models;

namespace Weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiniBooksCoversController : ControllerBase
    {
        public BooksContext Context { get; }

        public MiniBooksCoversController(BooksContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<MiniBooksCover> books = Context.MiniBooksCovers.ToList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            MiniBooksCover? books = Context.MiniBooksCovers.Where(x => x.BookId == id).FirstOrDefault();
            if (books == null)
            {
                return BadRequest("Не найдено короче");
            }
            return Ok(books);
        }

        [HttpPost]
        public IActionResult Add(MiniBooksCover books)
        {
            Context.MiniBooksCovers.Add(books);
            Context.SaveChanges();
            return Ok(books);
        }

        [HttpPut]
        public IActionResult Update(MiniBooksCover books)
        {
            Context.MiniBooksCovers.Add(books);
            Context.SaveChanges();
            return Ok(books);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            MiniBooksCover? books = Context.MiniBooksCovers.Where(x => x.BookId == id).FirstOrDefault();
            if (books == null)
            {
                return BadRequest("Не найдено короче");
            }
            Context.MiniBooksCovers.Remove(books);
            Context.SaveChanges();
            return Ok();
        }
    }
}
