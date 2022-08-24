using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Conversation
    {
        /// <summary>
        /// image file
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// first name
        /// </summary>
        public string firstName { get; set; }
        /// <summary>
        /// last name
        /// </summary>
        public string lastName { get; set; }

        /// <summary>
        /// most recent message content
        /// </summary>
        public MostRecentMessage mostRecentMessage { get; set; }

        /// <summary>
        /// total # of message
        /// </summary>
        public int totalMessages { get; set; }
        /// <summary>
        /// userId :: User class >> id
        /// </summary>
        public int userId { get; set; }
    }
}
