using System.Net;

namespace OrderService
{
    public class ApiResponse
    {
        public HttpStatusCode HttpCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
