using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using ProjectConker.Models;
using ProjectConker.Searching;

using SearchR = System.IO;

namespace ProjectConker.Roadmaps
{
    public class RoadmapService
    {
         readonly ConkerDbContext _dbContext;
         readonly SearchEngine _searchEngine;

         public RoadmapService(ConkerDbContext dbContext, SearchEngine searchEngine)
         {
             _dbContext = dbContext;
             _searchEngine = searchEngine;

         }

         public async Task dummy()
         {
             await _searchEngine.addDocuments();
         }

        public async Task Store(RoadmapForm form)
         {
            var roadmap = new Roadmap {
                Title = form.Title, 
                Summary = form.Summary, 
            };

            var roadmapTags = form.Tags
                .Select(tagId => new Tag        // First we take our form.tags and convert it to Tag objects
                {
                    TagName = tagId
                })
                .Select(tag => new RoadmapTag  // Then we take the result of the previous conversion and we 
                {                               // transform again to RoadmapTags, we even could do this in one pass
                    Roadmap = roadmap,          // but this way is more clear what the transformations are
                    Tag = tag
                })
                .ToList();

            _dbContext.AddRange(roadmapTags);
            await _dbContext.SaveChangesAsync();

            _searchEngine.addDocument(roadmap);
            
        }

    }
}

