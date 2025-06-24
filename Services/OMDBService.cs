using System.Text.Json;
using System.Text.Json.Serialization;
using Models;

namespace Services;

public class OMDbService : IOMDbService
{
    private readonly HttpClient _client;
    private readonly string ApiKey = "779067b";

    public OMDbService(HttpClient client)
    {
        _client = client;
    }
    public async Task<List<Movie>> GetMoviesAsync(string title, string year)
    {
        var response = await _client.GetFromJsonAsync<SearchResponse>($"http://www.omdbapi.com/?apikey={ApiKey}&s={title}&y={year}&plot=full");
        if (response?.Search != null)
        {
            return response.Search;
        }

        return new List<Movie>(); // Return empty if no results or error

    }
}