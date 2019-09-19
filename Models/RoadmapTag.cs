using System;
using System.Collections.Generic;

namespace ProjectConker.Models
{
    public partial class RoadmapTag
    {
        public int RoadmapId { get; set; }
        public int TagId { get; set; }

        public virtual Roadmap Roadmap { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
