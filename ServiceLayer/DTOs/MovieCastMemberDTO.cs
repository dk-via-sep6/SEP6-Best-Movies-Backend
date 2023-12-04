namespace ServiceLayer.DTOs
{
    public class MovieCastMemberDTO
    {
        public int PersonId { get; set; }
        public int CastId { get; set; }
        public string CreditId { get; set; }
        public string Character { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string ProfilePath { get; set; }
        public override string ToString()
        {
            return Character + ": " + Name;
        }
    }
}
