namespace codeallot.Models
{
    public class User
    {
        public User(long id, string email, string name, string? linkedin, string? github, string passwordHash)
        {
            Id = id;
            Email = email;
            Name = name;
            Linkedin = linkedin;
            Github = github;
            PasswordHash = passwordHash;
        }

        public User(long id, string email, string? name, string? status, string? linkedin, string? github, string passwordHash)
        {
            Id = id;
            Email = email;
            Name = name;
            Status = status;
            Linkedin = linkedin;
            Github = github;
            PasswordHash = passwordHash;
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public string? Name { get; set; }

        public string? Status { get; set; }
        public string? Linkedin { get; set; }
        public string? Github { get; set; }
        public List<Codex>? Codexes { get; set; }
        public int? CodexCount { get; set; }

        public string PasswordHash { get; set; }

        public string? Token { get; set; }

    }
}
