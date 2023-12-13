namespace DomainLayer.Entities
{
    public class WatchlistDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Movies { get; set; } = new List<int>();
        public string UserId { get; set; }

    }
}
