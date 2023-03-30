namespace codeallot.Models
{
    // User Login Confirmation DTO
    public class UserLCDTO
    {
        public RegisterUser? registerUser { get; set; }
        public string? token { get; set; }
    }
}
