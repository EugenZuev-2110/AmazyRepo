using Amazy.Context;
using Amazy.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Amazy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
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

            using (ApplicationContext context = new ApplicationContext())
            {
                context.Users.AddRange(user1, user2);
                context.SaveChanges();
            }

            return user2;
        }
    }
}