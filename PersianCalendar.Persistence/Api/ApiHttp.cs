using System.Net.Http.Json;

namespace PersianCalendar.Persistence.Api
{
    internal static class ApiHttp
    {
        public static async Task<T?> GetOrDefault<T>(HttpClient http, string url)
        {
            using var response = await http.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return default;

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public static async Task<IReadOnlyList<T>> GetList<T>(HttpClient http, string url)
        {
            return await GetOrDefault<List<T>>(http, url) ?? [];
        }

        public static async Task<T> Post<T>(HttpClient http, string url, T body)
        {
            using var response = await http.PostAsJsonAsync(url, body);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>() ?? body;
        }

        public static async Task Put<T>(HttpClient http, string url, T body)
        {
            using var response = await http.PutAsJsonAsync(url, body);
            response.EnsureSuccessStatusCode();
        }

        public static async Task Delete(HttpClient http, string url)
        {
            using var response = await http.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
