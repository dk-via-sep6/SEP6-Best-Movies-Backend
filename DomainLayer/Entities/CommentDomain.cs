﻿
namespace DomainLayer.Entities
{
    public class CommentDomain
    {
        public int Id { get; set; } // Auto-generated by the database
        public string AuthorId { get; set; } // ID of the user who created the comment
        public int MovieId { get; set; } // ID of the movie the comment is related to
        public DateTime Timestamp { get; set; } // Timestamp of the comment
        public string Content { get; set; }
        public List<string> LikedBy { get; set; } =new List<string>();
    }
}
