namespace Models;

public class SearchResponse
{
    public List<Movie>? Search { get; set; }
    public string? Error { get; set; }
}