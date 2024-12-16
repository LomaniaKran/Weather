namespace Weather.Contracts.Comment
{
    public class ChCommentCon
    {
        public int IdComment { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime CrData { get; set; }
        public TimeSpan CrTime { get; set; }
        public DateTime? ChData { get; set; }
        public TimeSpan? ChTime { get; set; }
        public string Comment1 { get; set; } = null!;
    }
}
