using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Contracts.Book;
using Weather.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksContext Context { get; }

        public BooksController(BooksContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Book> books = Context.Books.ToList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Book? books = Context.Books.Where(x => x.Id == id).FirstOrDefault();
            if (books == null)
            {
                return BadRequest("Не найдено короче");
            }
            return Ok(books);
        }

        [HttpPost]
        public IActionResult Add(BookCon books)
        {
            var user1 = new Book()
            {
                NameBook = books.NameBook,
                AuthorId = books.AuthorId,
                NumСhapters = books.NumСhapters,
                NumPages = books.NumPages,
                Genres = books.Genres,
                DescriptionB = books.DescriptionB,
            };
            Context.Books.Add(user1);
            Context.SaveChanges();
            return Ok(user1);
        }

        [HttpPut]
        public IActionResult Update(hBookCon books)
        {
            Book? userUp = Context.Books.Where(x => x.Id == books.Id).FirstOrDefault();
            if (userUp == null)
            {
                return BadRequest("Not Found");
            }
            userUp.NameBook = books.NameBook;
            userUp.AuthorId = books.AuthorId;
            userUp.NumСhapters = books.NumСhapters;
            userUp.NumPages = books.NumPages;
            userUp.Genres = books.Genres;
            userUp.DescriptionB = books.DescriptionB;
            Context.Books.Add(userUp);
            Context.SaveChanges();
            return Ok(userUp);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Book? books = Context.Books.Where(x => x.Id == id).FirstOrDefault();
            if (books == null)
            {
                return BadRequest("Не найдено короче");
            }
            Context.Books.Remove(books);
            Context.SaveChanges();
            return Ok();
        }
    }
}
