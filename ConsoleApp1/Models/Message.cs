using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Message
    {
        /// <summary>
        /// message
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// from - userId :: User class >> id
        /// </summary>
        public int fromUserId { get; set; }
        /// <summary>
        /// to - userId :: User class >> id
        /// </summary>
        public int toUserId { get; set; }

        /// <summary>
        /// milliseconds
        /// </summary>
        public ulong timestamp { get; set; }
    }
}
