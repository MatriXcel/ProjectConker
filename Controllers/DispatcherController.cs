using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectConker.Searching;

using ProjectConker;

namespace ProjectConker.Controllers
{
    public class Result
    {
        public HttpResponseMessage response;
        public string content;
    }

    [Route("api/dispatcher")]
    [ApiController]
    public class DispatcherController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        public DispatcherController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        
        [HttpGet]
       public async Task<Result> Get(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            Result result = new Result();
            result.response = response;
            result.content = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}