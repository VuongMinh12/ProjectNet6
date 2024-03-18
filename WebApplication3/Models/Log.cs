using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Log
    {
        public int LogId { get; set; }
        public string Content { get; set; } = null!;
        public string Type { get; set; } = null!;
        public DateTime Time { get; set; }
    }
}
