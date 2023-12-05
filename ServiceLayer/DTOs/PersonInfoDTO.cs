namespace ServiceLayer.DTOs
{
    public class PersonInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdultFilmStar { get; set; }
        public IReadOnlyList<PersonInfoRoleDTO> KnownFor { get; set; }
        public string ProfilePath { get; set; }
        public double Popularity { get; set; }
        public PersonInfoDTO()
        {
            KnownFor = Array.Empty<PersonInfoRoleDTO>();
        }
    }
}
