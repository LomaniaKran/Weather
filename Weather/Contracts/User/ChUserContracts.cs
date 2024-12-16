namespace Weather.Contracts.User
{
    public class ChUserContracts
    {
        public int Id { get; set; }
        public string UserLogin { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
    }
}
