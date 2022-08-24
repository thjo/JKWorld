using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class MostRecentMessage
    {
        /// <summary>
        /// message
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// milliseconds
        /// </summary>
        public ulong timestamp { get; set; }
        /// <summary>
        /// userId of the user who the message is from. :: User class >> id
        /// </summary>
        public int userId { get; set; }
    }
}
