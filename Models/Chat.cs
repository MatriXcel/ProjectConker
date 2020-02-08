using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectConker.Models
{
    public partial class Chat
    {
        public Chat()
        {
            ChatTag = new HashSet<ChatTag>();
        }

        public int ChatId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public virtual ICollection<ChatTag> ChatTag { get; set; }
    }
}
