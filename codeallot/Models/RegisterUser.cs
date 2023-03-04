namespace codeallot.Models
{
    public class RegisterUser
    {

/*        public RegisterUser(long Id, string email, string password, string? name)
        {
            Id = Id;
            Email = email;
            Password = password;
            Name = name;
        }


        public RegisterUser(long Id, string email, string password, string? name, string? linkedin, string? github)
        {
            Id
            Email = email;
            Password = password;
            Name = name;
            Linkedin = linkedin;
            Github = github;
        }
*/
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? Linkedin { get; set; }
        public string? Github { get; set; }
    }
}
