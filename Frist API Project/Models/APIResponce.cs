using System.Net;

namespace Frist_API_Project.Models
{
    public class APIResponce
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string>? ErrorMessage { get; set; }
        public object Result { get; set; }
    }
}
