using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Player;

public class ASPConnector
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUri;

    public ASPConnector(string apiBaseUri)
    {
        _apiBaseUri = apiBaseUri.TrimEnd('/');
        _httpClient = new HttpClient();
    }
    public async Task<UserModel?> DataIsCorrect(string login, string password)
    {
        var request = new { login, password };
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{_apiBaseUri}/api/auth/login", content);

        if (!response.IsSuccessStatusCode) 
            return null;

        var jsonResult = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<UserModel>(jsonResult, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true });
    }
    public async Task<UserModel?> CreateNewAccount(string login, string password, string repeatPassword, string firstName, string lastName)
    {
        var request = new { login, password, repeatPassword, firstName, lastName };
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{_apiBaseUri}/api/auth/registration", content);

        if (!response.IsSuccessStatusCode) 
            return null;

        var jsonResult = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<UserModel>(jsonResult, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true });
    }

    public async Task<bool> DeleteAccount(string login)
    {
        var request = new { login };
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{_apiBaseUri}/api/auth/delete", content);

        if (!response.IsSuccessStatusCode) 
            return false;

        var jsonResult = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<bool>(jsonResult);
    }

    public async Task<UserModel?> UpdateAccount(string currentLogin, string login, string password, string firstName, string lastName)
    {
        var request = new { currentLogin, login, password, firstName, lastName };
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync($"{_apiBaseUri}/api/auth/update", content);

        if (!response.IsSuccessStatusCode) 
            return null;

        var jsonResult = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<UserModel>(jsonResult, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}
