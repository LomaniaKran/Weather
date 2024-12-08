using System;
using System.Collections.Generic;

namespace Weather.Models
{
    public partial class Evaluation
    {
        public int IdComment { get; set; }
        public int Evaluation1 { get; set; }

        public virtual Comment IdCommentNavigation { get; set; } = null!;
    }
}
