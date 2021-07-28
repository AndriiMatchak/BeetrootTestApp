using BeetrootTestApp.Common.StaticResources;

namespace BeetrootTestApp.Common.Models.Base
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            Message = ApiResponseMessages.Success;
        }

        public ApiResponse(dynamic data)
        {
            Message = ApiResponseMessages.Success;
            Data = data;
        }

        public string Message { get; set; }

        public object Errors { get; set; }

        public dynamic Data { get; set; }
    }
}
