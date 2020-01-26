using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProjectConker.Controllers
{


    public class ChatForm
    {
        string title;
        string description;
        string tags;
    }

    [ApiController]
    [Route("api/chat/")]
    public class ChatController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateChat(ChatForm chatForm)
        {
            Console.WriteLine("received");
             return Ok();
        }
    }
}