using System;
using System.Collections.Generic;

namespace ProjectConker.Models
{
    public partial class ChatTag
    {
        public int ChatId { get; set; }
        public int TagId { get; set; }

        public virtual Chat Chat { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
