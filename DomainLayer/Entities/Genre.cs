namespace DomainLayer.Entities
{
    public class Genre : IEqualityComparer<Genre>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Genre(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Genre()
        {
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Genre y))
            {
                return false;
            }

            return Equals(this, y);
        }

        public bool Equals(Genre x, Genre y)
        {
            if (x != null && y != null && x.Id == y.Id)
            {
                return x.Name == y.Name;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return GetHashCode(this);
        }

        public int GetHashCode(Genre obj)
        {
            return (17 * 23 + obj.Id.GetHashCode()) * 23 + obj.Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name} ({Id})";
        }
    }
}
