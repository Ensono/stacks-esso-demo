using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace htec.backend.API.Models.Responses
{
    /// <summary>
    /// Response model used by GetById api endpoint
    /// </summary>
    public class DOMAIN
    {
        /// <example>d290f1ee-6c54-4b01-90e6-d701748f0851</example>
        [Required]
        public Guid? Id { get; set; }

        /// <example>DOMAIN name</example>
        [Required]
        public string Name { get; set; }

        /// <example>DOMAIN description</example>
        public string Description { get; set; }

        /// <summary>
        /// Represents the categories contained in the domain
        /// </summary>
        public List<Category> Categories { get; set; }

        /// <summary>
        /// Represents the status of the domain. False if disabled
        /// </summary>
        [Required]
        public bool? Enabled { get; set; }
    }
}
