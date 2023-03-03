namespace codeallot.Models
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? Linkedin { get; set; }
        public string? Github { get; set; }
        public string? CodexCount { get; set; }
        public List<Codex>? Codexes { get; set; }
    }
}
