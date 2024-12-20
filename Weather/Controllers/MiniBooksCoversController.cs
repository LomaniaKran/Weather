﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Contracts.MiniBooksCover;
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
        public IActionResult Add(MiniBooksCoverCon books)
        {
            var user1 = new MiniBooksCover()
            {
                BookId = books.BookId,
                MiniCover = books.MiniCover,
            };
            Context.MiniBooksCovers.Add(user1);
            Context.SaveChanges();
            return Ok(user1);
        }

        [HttpPut]
        public IActionResult Update(MiniBooksCoverCon books)
        {
            MiniBooksCover? userUp = Context.MiniBooksCovers.Where(x => x.BookId == books.BookId).FirstOrDefault();
            if (userUp == null)
            {
                return BadRequest("Not Found");
            }
            userUp.MiniCover = books.MiniCover;
            Context.MiniBooksCovers.Add(userUp);
            Context.SaveChanges();
            return Ok(userUp);
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
