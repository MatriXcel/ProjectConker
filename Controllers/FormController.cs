using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// using WebApiServerApp.Searching;
using Microsoft.AspNetCore.Cors;

using ProjectConker.Roadmaps;
using ProjectConker.Searching;

namespace ProjectConker.Controllers
{

    [Route("api/submitForm")]
    [ApiController]

    public class FormController : ControllerBase
    {
        readonly RoadmapService _roadmapService;
        
        public FormController(RoadmapService roadmapService)
        {
            _roadmapService = roadmapService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoadmapForm formData)
        {
            await _roadmapService.Store(formData);

            // await _roadmapService.AddToDatabase(
            //     new RoadmapForm { 
            //         Title = "NBA Basketball Roadmap", 
            //         Summary = "Here are some of the things I used to propell me to NBA heights in my basketballing journey, from little kid to NBA champ",
            //         Tags = new String[]{ "basketball", "sports" } 
            //     }
            // );

            return Ok();
        }
    }
}