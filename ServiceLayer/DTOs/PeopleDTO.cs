namespace ServiceLayer.DTOs
{
    public class PeopleDTO
    {
        public int Page { get; set; }
        public List<PersonResultDTO> Results { get; set; }
        public int Total_Pages { get; set; }
        public int Total_Results { get; set; }
    }
}
