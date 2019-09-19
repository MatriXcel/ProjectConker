using System;
using System.Collections.Generic;

namespace ProjectConker.Models
{
    public partial class Tag
    {
        public Tag()
        {
            RoadmapTags = new HashSet<RoadmapTag>();
        }

        public int TagId { get; set; }
        public string TagName { get; set; }
        public string TagDesc { get; set; }
        public int? NumFollowers { get; set; }

        public virtual ICollection<RoadmapTag> RoadmapTags { get; set; }
    }
}
