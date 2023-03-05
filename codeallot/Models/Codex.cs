namespace codeallot.Models
{
    public class Codex
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Filename { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public User? CreatedBy { get; set; }
        public string? Link { get; set; }
    }
}
