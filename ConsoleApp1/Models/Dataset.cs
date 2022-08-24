using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Dataset
    {
        /// <summary>
        /// your user id (Assumed userId is integer)
        /// </summary>
        public int userId { get; set; }
        /// <summary>
        /// messages: between you and those users.
        /// </summary>
        public List<Message> messages { get; set; }
        /// <summary>
        /// users: you have communicated with 
        /// </summary>
        public List<User> users { get; set; }
    }
}
