using System;
using System.Collections.Generic;

namespace ProjectConker.Models
{
    public partial class Chat
    {
        public int ChatId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public virtual ChatTag ChatTag { get; set; }
    }
}
