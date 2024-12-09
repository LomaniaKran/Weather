namespace Weather.Contracts.Author
{
    public class ChAuthorContr
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Patronymic { get; set; }
    }
}
