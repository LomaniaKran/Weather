using System;
using System.Collections.Generic;

namespace Weather.Models
{
    public partial class BooksAddit
    {
        public int BookId { get; set; }
        public string ShortDescription { get; set; } = null!;

        public virtual Book Book { get; set; } = null!;
    }
}
