using System;
using System.Net.Http;
namespace EmployeesList.Helper
{
    public class HelperAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            return client;
        }
    }
}
