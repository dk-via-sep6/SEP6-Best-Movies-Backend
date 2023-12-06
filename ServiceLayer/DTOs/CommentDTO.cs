
namespace ServiceLayer.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public int MovieId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Content { get; set; }
        public List<string> LikedBy { get; set; }

        public string AuthorUsername { get; set; }
    }
}
