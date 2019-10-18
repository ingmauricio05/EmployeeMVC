using System.Net.Http;

namespace EmployeesModel
{
    public class Request
    {
        public HttpMethod Method { get; set; }
        public string Query { get; set; }

    }
}
