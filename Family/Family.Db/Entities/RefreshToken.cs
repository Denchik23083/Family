namespace Family.Db.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }

        public User? User { get; set; }

        public int UserId { get; set; }
    }
}
