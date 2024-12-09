namespace Weather.Contracts.Author
{
    public class AuthorContr
    {
        public int BookId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Patronymic { get; set; }
    }
}
