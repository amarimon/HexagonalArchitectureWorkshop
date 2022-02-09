using Core.Module.Shared.Domain;
using Core.Module.Users.Application;
using Core.Module.Users.Domain;
using Core.Module.Users.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private IUserRepository userRepository;
        private IEventBus eventBus;
        private readonly UserDbContext userDbContext;

        public UserController(UserDbContext context)
        {
            this.userDbContext = context;
            this.userRepository = new PostgresqlUserRepository(userDbContext);
        }

        // POST: User
        /// <summary>
        /// Create an user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/User")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody]CreateUserRequest request)
        {
            try
            {
                UserCreator userCreator = new UserCreator(userRepository, eventBus);
                await userCreator.Create(request);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message + " " + ex.InnerException + " " + ex.StackTrace);
            }
        }

        // GET: User
        /// <summary>
        /// Get an user by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/User/{userId}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get(String userId)
        {
            try
            {
                UserFinder userFinder = new UserFinder(userRepository);
                User user = await userFinder.Find(userId);

                return StatusCode(200, user);
            }
            catch (Exception ex)
            {
                return StatusCode(404);
            }
        }
    }
}
