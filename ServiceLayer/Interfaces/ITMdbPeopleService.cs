using DomainLayer.Entities;

namespace ServiceLayer.Interfaces
{
    public interface ITMdbPeopleService
    {
        Task<PeopleDomain> GetTrendingAsync();
    }
}
