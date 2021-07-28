using BeetrootTestApp.Common.Models.IncomeModels;
using BeetrootTestApp.Services.Interfaces;
using BeetrootTestApp.Web.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace BeetrootTestApp.Web.Controllers.MessageControllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class MessageController : BaseController
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult GetMessagesByFilter([FromBody] GetMessagesFilterIncomeModel getMessagesFilter)
        {
            return OkResult(_messageService.GetMessagesByFilter(getMessagesFilter));
        }
    }
}
