namespace Weather.Contracts.Book
{
    public class hBookCon
    {
        public int Id { get; set; }
        public string NameBook { get; set; } = null!;
        public int AuthorId { get; set; }
        public int NumСhapters { get; set; }
        public int NumPages { get; set; }
        public string Genres { get; set; } = null!;
        public string DescriptionB { get; set; } = null!;
    }
}
