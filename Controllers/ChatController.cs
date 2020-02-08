using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectConker.Models;
using Repository;

namespace ProjectConker.Controllers
{


    public class ChatForm
    {
        public string title;
        public string description;
        public string tags;
    }

    [ApiController]
    [Route("api/chat/")]
    public class ChatController : ControllerBase
    {
        IRepositoryWrapper _repoWrapper;
        public ChatController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateChat(ChatForm chatForm)
        {

            var newChat = new Chat(){ 
                   Title = chatForm.title, 
                   Description = chatForm.description,
                   Author = "MatriXcel"
            };

            var tagList = chatForm.tags.Trim().Split(" ").ToList();

            foreach(string str in tagList)
            {
                Console.WriteLine("it iiiiisssssssssssssssss " + str);
            }
            

            var newChatTags = tagList.Select(tag => 
            {
                var existingTag = _repoWrapper.Tag.FindAll().AsTracking().SingleOrDefault(t => t.TagName == tag);
                return (existingTag != null) ? existingTag : new Tag{ TagName = tag };
            })
            .Select(tag => new ChatTag
            {
                Chat = newChat,
                Tag = tag
            })
            .ToList();

            _repoWrapper.AddRange(newChatTags);
            await _repoWrapper.Save();

            //_dbContext.AddRange(newChatTags);

            


        //     Console.WriteLine(chatForm.tags);

        //     var chat = _repoWrapper.Chat.FindAll().AsTracking()
        //     .Include(c => c.ChatTag)
        //     .ThenInclude(ct => ct.Tag).FirstOrDefault(c => c.ChatId == 1);

        //     var chatTagID = chat.ChatTag.ToList()[0].TagId;
            
        //     var tag = _repoWrapper.Tag.FindAll().SingleOrDefault(t => t.TagId == chatTagID);

        //    Console.WriteLine("I am right heeeeere " + tag.TagName);



            //Console.WriteLine(_repoWrapper.Chat.FindAll().ToList()[1].Description);
            // _repoWrapper.Chat.Update(chat);
            //_context.SaveChanges();

            return Ok();
        }
    }
}