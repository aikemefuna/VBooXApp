using VBooX.Application.Wrappers;

namespace VBooX.WebApi.Helpers
{
    public class ResponseHelper<TD>
    {
        public static Response<TD> SuccessMessage(TD param, string message)
        {
            var response = new Response<TD>
            {
                Data = param,
                Message = message,
                StatusCode = 200,
                Succeeded = true,
            };
            return response;
        }
        public static Response<TD> Failed(TD param, string message)
        {
            var response = new Response<TD>
            {
                Data = param,
                Message = message,
                StatusCode = 400,
                Succeeded = false,
            };
            return response;
        }
        public static Response<TD> Exists(TD param, string message)
        {
            var response = new Response<TD>
            {
                Data = param,
                Message = message,
                StatusCode = 409,
                Succeeded = false,
            };
            return response;
        }
    }
}
