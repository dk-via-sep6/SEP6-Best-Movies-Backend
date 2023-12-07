namespace ServiceLayer.DTOs
{
    public class WatchlistDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Movies { get; set; } // IDs of the movies
        public string UserId { get; set; }
    }
}
