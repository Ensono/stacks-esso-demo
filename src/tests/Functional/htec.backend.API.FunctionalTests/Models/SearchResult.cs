using System.Collections.Generic;

namespace htec.backend.API.FunctionalTests.Models
{
    public class SearchResult
    {
        public int size { get; set; }
        public int offset { get; set; }
        public List<SearchResultItem> results { get; set; }
    }
}
