using System;
using System.Collections.Generic;

namespace Weather.Models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public int BookId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Patronymic { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
