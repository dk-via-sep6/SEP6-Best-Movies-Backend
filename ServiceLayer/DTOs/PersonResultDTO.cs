namespace ServiceLayer.DTOs
{
    public class PersonResultDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Profile_Path { get; set; }
        public double Popularity { get; set; }
        public string TopKnownForTitles { get; set; }
    }
}
