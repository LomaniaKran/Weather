using System;
using System.Collections.Generic;

namespace Weather.Models
{
    public partial class Comment
    {
        public int IdComment { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime CrData { get; set; }
        public TimeSpan CrTime { get; set; }
        public DateTime? ChData { get; set; }
        public TimeSpan? ChTime { get; set; }
        public string Comment1 { get; set; } = null!;

        public virtual Book Book { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual DeletedComment DeletedComment { get; set; } = null!;
        public virtual Evaluation Evaluation { get; set; } = null!;
    }
}
