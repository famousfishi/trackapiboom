using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trackapiboom.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
