using System;
using System.Collections.Generic;

namespace Weather.Models
{
    public partial class MiniBooksCover
    {
        public int BookId { get; set; }
        public string MiniCover { get; set; } = null!;

        public virtual Book Book { get; set; } = null!;
    }
}
