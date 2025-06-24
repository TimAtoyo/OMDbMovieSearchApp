using Models;
namespace Services;

public interface IOMDbService
{
    Task<List<Movie>> SearchMovies(string query);
}