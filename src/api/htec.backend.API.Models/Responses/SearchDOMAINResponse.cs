using System.Collections.Generic;

namespace htec.backend.API.Models.Responses
{
    /// <summary>
    /// Response model used by SearchDOMAIN api endpoint
    /// </summary>
    public class SearchDOMAINResponse
    {
        /// <example>10</example>
        public int Size { get; set; }

        /// <example>0</example>
        public int Offset { get; set; }

        /// <summary>
        /// Contains the items returned from the search
        /// </summary>
        public List<SearchDOMAINResponseItem> Results { get; set; }
    }
}
