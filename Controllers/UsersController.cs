using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Contracts.User;
using Weather.Models;

namespace Weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public BooksContext Context { get; }

        public UsersController(BooksContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = Context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            User? user = Context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Не найдено короче");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add(UserContracts user)
        {
            var user1 = new User()
            {
                UserLogin = user.UserLogin,
                UserPassword = user.UserPassword,
                UserEmail = user.UserEmail,
            };
            Context.Users.Add(user1);
            Context.SaveChanges();
            return Ok(user1);
        }

        [HttpPut]
        public IActionResult Update(ChUserContracts user)
        {
            User? userUp = Context.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            if (userUp == null)
            {
                return BadRequest("Not Found");
            }
            userUp.UserLogin = user.UserLogin;
            userUp.UserPassword = user.UserPassword;
            userUp.UserEmail = user.UserEmail;
            Context.Users.Add(userUp);
            Context.SaveChanges();
            return Ok(userUp);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            User? user = Context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Не найдено короче");
            }
            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok();
        }
    }
}
