using System.Text.Json;

namespace Tasks;

public class Task8
{
    async Task GenerateCountryDataFiles()
    {
        using var client = new HttpClient();
        var response = await client.GetStringAsync("https://restcountries.com/v3.1/all");
        var countries = JsonDocument.Parse(response).RootElement;

        foreach (var country in countries.EnumerateArray())
        {
            var name = country.GetProperty("name").GetProperty("common").GetString();
            var region = country.TryGetProperty("region", out var r) ? r.GetString() : "N/A";
            var subregion = country.TryGetProperty("subregion", out var sr) ? sr.GetString() : "N/A";
            
            var latlng = "N/A";
            if (country.TryGetProperty("latlng", out var ll) && ll.ValueKind == JsonValueKind.Array)
                latlng = string.Join(", ", ll.EnumerateArray());

            var area = country.TryGetProperty("area", out var a) ? a.GetRawText() : "N/A";
            var population = country.TryGetProperty("population", out var p) ? p.GetRawText() : "N/A";

            var content = $"Region: {region}\nSubregion: {subregion}\nLatLng: {latlng}\nArea: {area}\nPopulation: {population}";
            
            var fileName = string.Join("_", name.Split(Path.GetInvalidFileNameChars())) + ".txt";
            await File.WriteAllTextAsync(fileName, content);
        }
    }
}