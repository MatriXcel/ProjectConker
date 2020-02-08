using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectConker.Models
{
    public partial class Tag
    {
        public Tag()
        {
            ChatTag = new HashSet<ChatTag>();
            RoadmapTag = new HashSet<RoadmapTag>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }
        public string TagName { get; set; }
        public string TagDesc { get; set; }
        public int? NumFollowers { get; set; }

        public virtual ICollection<ChatTag> ChatTag { get; set; }
        public virtual ICollection<RoadmapTag> RoadmapTag { get; set; }
    }
}
