using Amazy.Context;
using Amazy.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Amazy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> _logger;
        public ApplicationController(ILogger<ApplicationController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUser")]
        public User Get()
        {
            return new User { AMTLimit = 20, Id = 1, JWT = "303", Login = "Zhenya", Password = "1111", Name = "Eugen" };
        }

        [HttpPost(Name = "PostUser")]
        public User Post()
        {
            var user1 = new User { AMTLimit = 10, Name = "Niko", JWT = "101", Login = "Nikko", Password = "2222" };
            var user2 = new User { AMTLimit = 50, Name = "Viko", JWT = "501", Login = "Vikko", Password = "3333" };

            var sneaker1 = new Sneaker { Level = 1, Name = "Nike", Model = "Air Max 4", Wear = 40 };
            var sneaker2 = new Sneaker { Level = 3, Name = "Reebok", Model = "Pilot One", Wear = 30 };
            var sneaker3 = new Sneaker { Level = 4, Name = "Adidas", Model = "F50", Wear = 50 };
            var sneaker4 = new Sneaker { Level = 2, Name = "Nike", Model = "Mercurial 2", Wear = 80 };

            using (ApplicationContext context = new ApplicationContext())
            {
                context.Users.AddRange(user1, user2);
                context.Sneakers.AddRange(sneaker1, sneaker2, sneaker3, sneaker4);
                user1.Sneakers.Add(sneaker4);
                user1.Sneakers.Add(sneaker2);
                user2.Sneakers.Add(sneaker1);
                user2.Sneakers.Add(sneaker3);
                context.SaveChanges();
            }

            return user2;
        }
    }
}