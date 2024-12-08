using System;
using System.Collections.Generic;

namespace Weather.Models
{
    public partial class DeletedComment
    {
        public int IdComment { get; set; }
        public DateTime? DeletedData { get; set; }
        public TimeSpan? DeletedTime { get; set; }

        public virtual Comment IdCommentNavigation { get; set; } = null!;
    }
}
