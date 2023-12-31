﻿using DM.MovieApi.MovieDb.People;

namespace ServiceLayer.Interfaces
{
    public interface ITheMovieDbWrapperPersonService
    {
        Task<Person> FindByIdAsync(int personId);
        Task<List<PersonInfo>> SearchByNameAsync(string name);
        Task<PersonMovieCredit> GetMovieCreditsAsync(int personId);
        Task<PersonTVCredit> GetTVCreditsAsync(int personId);
    }
}
