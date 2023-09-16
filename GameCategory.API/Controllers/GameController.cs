using GameCategory.Infrastructure.Models;
using GameCategory.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameCategory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private DbTestContext _dbContext;

        public GameController(DbTestContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var repository = new Repository<Game>(_dbContext);
            var dbObj = repository.Get();

            return Ok(dbObj);
        }
    }
}
