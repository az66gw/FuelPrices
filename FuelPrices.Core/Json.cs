using System.Text.Json;

namespace FuelPrices.Core;

public static class Json
{
  private static readonly JsonSerializerOptions Options = new()
  {
    WriteIndented = true,
    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    PropertyNameCaseInsensitive = true
  };

  public static T? Deserialize<T>(string json) => JsonSerializer.Deserialize<T>(json, Options);

  public static string Serialize<T>(T value) => JsonSerializer.Serialize(value, Options);

  public static async Task<T?> DeserializeAsync<T>(Stream stream) => await JsonSerializer.DeserializeAsync<T>(stream, Options);

  public static async Task SerializeAsync<T>(Stream stream, T value) => await JsonSerializer.SerializeAsync(stream, value, Options);
}
