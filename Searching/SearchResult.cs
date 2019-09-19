
using System;
using System.Collections.Generic;
using ProjectConker.Models;


namespace ProjectConker.Searching
{
    public struct SearchResult
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Summary { get; set; }
        public IEnumerable<String> Tags { get; set; }
    }
}