using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIs.Models
{
    public class TodoItem
    {
        /// <summary>
        /// The Id property functions as the unique key in a relational database.
        /// </summary>
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }

        public string? Secret { get; set; }
    }
}
