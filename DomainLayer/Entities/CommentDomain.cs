
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities
{
    public class CommentDomain
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public int MovieId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Content { get; set; }
        public List<string> LikedBy { get; set; } = new List<string>();
        [NotMapped]
        public string AuthorUsername { get; set; }
    }
}
