﻿using System;

namespace htec.backend.API.Models.Responses
{
    /// <summary>
    /// Response model representing a search result item in the SearchDOMAIN api endpoint
    /// </summary>
    public class SearchDOMAINResponseItem
    {
        /// <example>d290f1ee-6c54-4b01-90e6-d701748f0851</example>
        public Guid Id { get; set; }

        /// <example>DOMAIN name</example>
        public string Name { get; set; }

        /// <example>DOMAIN description</example>
        public string Description { get; set; }

        /// <summary>
        /// Represents the status of the domain. False if disabled
        /// </summary>
        public bool Enabled { get; set; }
    }
}
