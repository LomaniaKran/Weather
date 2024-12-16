namespace Weather.Contracts.DeletedComment
{
    public class DeletedCommentCon
    {
        public int IdComment { get; set; }
        public DateTime? DeletedData { get; set; }
        public TimeSpan? DeletedTime { get; set; }
    }
}
