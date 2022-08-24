using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class User
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
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
    }
}
