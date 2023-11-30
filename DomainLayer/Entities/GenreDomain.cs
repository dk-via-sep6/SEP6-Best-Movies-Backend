namespace DomainLayer.Entities
{
    public class GenreDomain : IEqualityComparer<GenreDomain>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GenreDomain(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public GenreDomain()
        {
        }

        public override bool Equals(object obj)
        {
            if (!(obj is GenreDomain y))
            {
                return false;
            }

            return Equals(this, y);
        }

        public bool Equals(GenreDomain x, GenreDomain y)
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

        public int GetHashCode(GenreDomain obj)
        {
            return (17 * 23 + obj.Id.GetHashCode()) * 23 + obj.Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name} ({Id})";
        }
    }
}
