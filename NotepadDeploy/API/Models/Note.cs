using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public string UserId { get; set; }

    }
}
