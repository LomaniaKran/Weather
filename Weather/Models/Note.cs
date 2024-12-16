using System;
using System.Collections.Generic;

namespace Weather.Models
{
    public partial class Note
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string? Note1 { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
