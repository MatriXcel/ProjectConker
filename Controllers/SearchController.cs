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
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SearchEngine _engine;
        private readonly IHttpClientFactory _clientFactory;
        public SearchController(SearchEngine engine, IHttpClientFactory clientFactory)
        {
            _engine = engine;
            _clientFactory = clientFactory;
        }

        
        [HttpGet]
       public IEnumerable<SearchResult> Get(string q)
        {
            return _engine.search(q.Split(" "));
        }
    }
}
