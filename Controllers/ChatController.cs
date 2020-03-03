using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectConker.Models;
using Repository;

namespace ProjectConker.Controllers
{


    public class ChatAttribs
    {
        public string title;
        public string description;
        public string authorName;
        public string[] tags;
    }

    public class ChatForm
    {
        public string title;
        public string description;
        public string authorName;
        public string tags;
    }


    [ApiController]
    [Route("api/chats/")]
    public class ChatController : ControllerBase
    {
        IRepositoryWrapper _repoWrapper;
        public ChatController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet]
        [Route("getall")]

        public async Task<IEnumerable<ChatAttribs>> GetAllChats()
        {
            var tags = _repoWrapper.Tag.FindAll();

            //one chat can have multiple chatTags
            var chats = _repoWrapper.Chat.FindAll().Include(c => c.ChatTag).ThenInclude(ct => ct.Tag);

            List<ChatAttribs> chatAttribsList = new List<ChatAttribs>();

            foreach(var chat in chats)
            {
                List<String> tagNames = new List<String>();

                foreach(var id in chat.ChatTag.Select(ct => ct.TagId))
                {
                    var tagName = tags.SingleOrDefault(t => t.TagId == id).TagName;
                    Console.WriteLine("tag iiisss " + tagName);
                    tagNames.Add(tagName);
                }
                
                chatAttribsList.Add(new ChatAttribs{
                    title = chat.Title,
                    description = chat.Description,
                    authorName = chat.Author,
                    tags = tagNames.ToArray()
                });
            }
            
            return chatAttribsList;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateChat(ChatForm chatAttribs)
        {

            var newChat = new Chat(){ 
                   Title = chatAttribs.title, 
                   Description = chatAttribs.description,
                   Author = "MatriXcel"
            };

            var tagList = chatAttribs.tags.Split(" ").ToList();
            
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

            return Ok();
        }
    }
}