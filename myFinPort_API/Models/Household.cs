using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFinPort_API.Models
{
    /// <summary>
    /// The model for the household unit in myFinPort
    /// </summary>
    public class Household
    {
        /// <summary>
        /// The Primary Key of the Household
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User generated name of the Household
        /// </summary>
        public string HouseholdName { get; set; }

        /// <summary>
        /// Shown to new users of the household on joining
        /// </summary>
        public string Greeting { get; set; }

        /// <summary>
        /// The time when the household was created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Soft delete boolean value
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}