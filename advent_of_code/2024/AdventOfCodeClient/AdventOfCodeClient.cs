using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


public class AdventOfCodeClient : IDisposable
{
    private const string BaseUrl = "https://adventofcode.com/";

    private HttpClient HttpClient { get; }

    public AdventOfCodeClient(string cookie)
    {
        var cookieContainer = new CookieContainer();
        
        cookieContainer.Add(new Uri(BaseUrl), new Cookie("session", cookie));

        var handler = new HttpClientHandler
        {
            CookieContainer = cookieContainer
        };
        
        HttpClient =  new HttpClient(handler);
    }
    
    public AdventOfCodeClient(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    public async Task<string> GetInput(int year, int day)
    {
        using var response = await HttpClient.GetAsync($"{BaseUrl}{year}/day/{day}/input");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
    
    public void Dispose()
    {
        HttpClient.Dispose();
    }
}