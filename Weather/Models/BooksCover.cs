using System;
using System.Collections.Generic;

namespace Weather.Models
{
    public partial class BooksCover
    {
        public int BookId { get; set; }
        public string Cover { get; set; } = null!;

        public virtual Book Book { get; set; } = null!;
    }
}
