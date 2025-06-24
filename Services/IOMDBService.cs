using Models;
namespace Services;

public interface IOMDbService
{
    Task<List<Movie>> GetMoviesAsync(string title, string year);
}