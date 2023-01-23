namespace Api.Models
{
    public class LoginMetadata
    {
        public Guid Id { get; set; }
        public Member Member { get; set; }
        public DateTime Date { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
    }
}