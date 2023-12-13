namespace ServiceLayer.DTOs
{
    public class WatchlistDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MovieDTO> Movies { get; set; } = new List<MovieDTO>();

        public string UserId { get; set; }
    }
}
