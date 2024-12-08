using System;
using System.Collections.Generic;

namespace Weather.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Notes = new HashSet<Note>();
        }

        public int Id { get; set; }
        public string UserLogin { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string UserEmail { get; set; } = null!;

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
