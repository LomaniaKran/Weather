using System;
using System.Collections.Generic;

namespace Weather.Models
{
    public partial class Book
    {
        public Book()
        {
            Comments = new HashSet<Comment>();
            Notes = new HashSet<Note>();
        }

        public int Id { get; set; }
        public string NameBook { get; set; } = null!;
        public int AuthorId { get; set; }
        public int NumСhapters { get; set; }
        public int NumPages { get; set; }
        public string Genres { get; set; } = null!;
        public string DescriptionB { get; set; } = null!;

        public virtual Author Author { get; set; } = null!;
        public virtual BooksAddit BooksAddit { get; set; } = null!;
        public virtual BooksCover BooksCover { get; set; } = null!;
        public virtual MiniBooksCover MiniBooksCover { get; set; } = null!;
        public virtual Rating Rating { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
