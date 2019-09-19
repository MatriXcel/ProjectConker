using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.SignalR;

namespace ProjectConker
{
    public class IMessage
    {
       public string timestamp;
       public string message;
       public string author;
       public string iconLink;
   }
    public class ChatHub : Hub
    {
        public Task SendToAll(string name, IMessage messageData)
        {
            Console.WriteLine(messageData.message);
             return Clients.All.SendAsync("ReceiveMessage", name, messageData);
        }
    } 
}