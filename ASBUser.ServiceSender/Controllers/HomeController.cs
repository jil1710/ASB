using ASBShared.Models;
using ASBUser.ServiceSender.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASBUser.ServiceSender.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly IEventBus _eventBus;
        private readonly IConfiguration configuration;

        public HomeController(IEventBus eventBus,IConfiguration configuration)
        {
            this._eventBus = eventBus;
            this.configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromBody] User user)
        {
            await _eventBus.SendMessageAsync<User>(user,configuration.GetSection("AzureQueue").Value!);
            return new JsonResult($"Account created successfully! Please confirm the email {user.Email}");
        }
    }
}