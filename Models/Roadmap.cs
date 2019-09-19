using System;
using System.Collections.Generic;

namespace ProjectConker.Models
{
    public partial class Roadmap
    {
        public Roadmap()
        {
            RoadmapTags = new HashSet<RoadmapTag>();
        }

        public int RoadmapId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }

        public virtual ICollection<RoadmapTag> RoadmapTags { get; set; }
    }
}
