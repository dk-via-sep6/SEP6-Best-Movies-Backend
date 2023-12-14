
namespace DomainLayer.Entities
{
    public class RatingDomain
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public double Rating { get; set; }
    }
}
