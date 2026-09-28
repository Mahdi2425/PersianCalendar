using System;
using System.IO;
using System.Threading.Tasks;

namespace PersianCalendar.Utils
{
    public class JsonFileReader
    {
        public async Task<T?> ReadJsonAsync<T>(string relativePath)
        {
            try
            {
                await using var stream = await FileSystem.OpenAppPackageFileAsync(relativePath).ConfigureAwait(false);
                using var reader = new StreamReader(stream);
                var json = await reader.ReadToEndAsync().ConfigureAwait(false);
                return System.Text.Json.JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"JsonFileReader failed for '{relativePath}': {ex.Message}");
                return default;
            }
        }
    }
}