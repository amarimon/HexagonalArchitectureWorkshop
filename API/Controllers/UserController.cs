using Core.Module.Shared.Domain;
using Core.Module.Users.Application;
using Core.Module.Users.Domain;
using Core.Module.Users.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private IUserRepository userRepository;
        private IEventBus eventBus;

        public UserController()
        {
            userRepository = new InMemoryUserRepository();
        }

        // GET: User/Create
        /// <summary>
        /// Create an user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/User")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            try
            {
                UserCreator userCreator = new UserCreator(userRepository, eventBus);
                await userCreator.Create(request);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
        }
    }
}
