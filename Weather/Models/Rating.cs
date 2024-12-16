using System;
using System.Collections.Generic;

namespace Weather.Models
{
    public partial class Rating
    {
        public int BookId { get; set; }
        public double Rating1 { get; set; }

        public virtual Book Book { get; set; } = null!;
    }
}
