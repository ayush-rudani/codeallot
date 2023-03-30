namespace codeallot.Models
{
    public class RegisterUser
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? Linkedin { get; set; }
        public string? Github { get; set; }
    }
}
