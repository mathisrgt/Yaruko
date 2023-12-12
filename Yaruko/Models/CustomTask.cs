using System;
using System.Collections.Generic;

namespace Yaruko.Models
{
    public class CustomTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public List<string> Tags { get; set; }
        public DateTime Deadline { get; set; }
    }
}
