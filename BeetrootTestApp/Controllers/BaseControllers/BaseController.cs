using BeetrootTestApp.Common.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace BeetrootTestApp.Web.Controllers.BaseControllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected virtual OkObjectResult OkResult(object value)
        {
            return Ok(new ApiResponse(value));
        }

        protected OkObjectResult OkResult()
        {
            return Ok(new ApiResponse());
        }
    }
}
